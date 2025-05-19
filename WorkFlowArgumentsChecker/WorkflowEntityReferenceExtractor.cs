using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using WorkFlowArgumentsChecker;


using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using Microsoft.Xrm.Sdk;

namespace WorkFlowArgumentsChecker
{

    public class EntityReferenceInfo
    {
        public string EntityName { get; set; }
        public string DisplayLabel { get; set; }
        public string LookupType { get; set; }
        public string ResolvedGuid { get; set; }
    }

    public class WorkflowEntityReferenceExtractor
    {

        public List<EntityReferenceInfo> GetWorkflowReferences(string xml)
        {
            //string xamlFilePath = "WF-AccreditationRequest-01OnStudyActions-402BD7C4-B677-4806-A6C5-F1CBD5B38CBF.xaml";
            //if (!File.Exists(xamlFilePath))
            //{
            //    Console.WriteLine("File not found: " + xamlFilePath);
            //    return new List<EntityReferenceInfo> ();
            //}

            // Load the XAML
            XDocument doc = XDocument.Parse(xml);

            // Step 1: Build a dictionary of varName -> GUID for all EvaluateExpression calls 
            //         that produce a GUID via WorkflowPropertyType.Guid.

            // We’ll call this dictionary guidDictionary.
            var guidDictionary = new Dictionary<string, string>();

            // We’ll find all <ActivityReference> elements
            var activityReferences = doc
                .Descendants()
                .Where(e => e.Name.LocalName == "ActivityReference")
                .ToList();

            foreach (var activityRef in activityReferences)
            {
                // Check if EvaluateExpression
                string aqn = activityRef.Attribute("AssemblyQualifiedName")?.Value ?? "";
                if (!aqn.Contains("Microsoft.Crm.Workflow.Activities.EvaluateExpression"))
                    continue;

                // Check if ExpressionOperator == "CreateCrmType"
                var expressionOperatorNode = activityRef
                    .Descendants()
                    .FirstOrDefault(e =>
                        e.Name.LocalName == "InArgument"
                        && e.Attributes().Any(a => a.Name.LocalName == "Key" && a.Value == "ExpressionOperator")
                    );

                if (expressionOperatorNode == null || expressionOperatorNode.Value != "CreateCrmType")
                    continue;

                // Check the Parameters node for WorkflowPropertyType.Guid
                var parametersNode = activityRef
                    .Descendants()
                    .FirstOrDefault(e =>
                        e.Name.LocalName == "InArgument"
                        && e.Attributes().Any(a => a.Name.LocalName == "Key" && a.Value == "Parameters")
                    );

                if (parametersNode == null || string.IsNullOrWhiteSpace(parametersNode.Value))
                    continue;

                string paramText = parametersNode.Value.Trim();

                // If it doesn't contain WorkflowPropertyType.Guid, skip
                if (!paramText.Contains("WorkflowPropertyType.Guid"))
                    continue;

                // We want to parse the GUID from something like:
                //   [New Object() { Microsoft.Xrm.Sdk.Workflow.WorkflowPropertyType.Guid, "819e9b5f-243d-ef11-9150-005056978a77", "UniqueIdentifier" }]
                // We'll do a quick Regex to get that second argument if it’s a plain string GUID.

                // Example pattern: [New Object() { Microsoft.Xrm.Sdk.Workflow.WorkflowPropertyType.Guid, "SOME-GUID", "UniqueIdentifier" }]
                var guidMatch = Regex.Match(
                    paramText,
                    @"\[New Object\(\)\s*\{\s*Microsoft\.Xrm\.Sdk\.Workflow\.WorkflowPropertyType\.Guid\s*,\s*""([^""]+)""",
                    RegexOptions.IgnoreCase
                );

                if (!guidMatch.Success)
                    continue;

                string guidValue = guidMatch.Groups[1].Value;

                // Next, we need to see which variable is assigned that GUID. 
                // Typically that’s in an <OutArgument x:Key="Result"> or something similar 
                // inside the same <ActivityReference> block.

                var outArg = activityRef
                    .Descendants()
                    .FirstOrDefault(e =>
                        e.Name.LocalName == "OutArgument"
                        && e.Attributes().Any(a => a.Name.LocalName == "Key" && a.Value == "Result")
                    );
                if (outArg != null)
                {
                    // The text might look like: [ConditionBranchStep13_15]
                    // We'll parse the bracketed content.
                    var outArgText = outArg.Value.Trim();
                    // Typically "[ConditionBranchStep13_15]" but might differ
                    // We'll remove leading/trailing brackets if present
                    string varName = outArgText;
                    if (varName.StartsWith("[") && varName.EndsWith("]"))
                    {
                        varName = varName.Substring(1, varName.Length - 2).Trim();
                    }

                    // We'll store varName -> guidValue
                    if (!string.IsNullOrEmpty(varName))
                    {
                        guidDictionary[varName] = guidValue;
                    }
                }
            }

            // Step 2: Parse for WorkflowPropertyType.EntityReference. If the GUID is 
            //         a variable name, we look it up in guidDictionary.

            var entityReferences = new List<EntityReferenceInfo>();

            // We can re-check the same EvaluateExpression nodes or filter them differently.
            // Let’s just do it again, focusing on "EntityReference" this time.

            foreach (var activityRef in activityReferences)
            {
                string aqn = activityRef.Attribute("AssemblyQualifiedName")?.Value ?? "";
                if (!aqn.Contains("Microsoft.Crm.Workflow.Activities.EvaluateExpression"))
                    continue;

                var expressionOperatorNode = activityRef
                    .Descendants()
                    .FirstOrDefault(e =>
                        e.Name.LocalName == "InArgument"
                        && e.Attributes().Any(a => a.Name.LocalName == "Key" && a.Value == "ExpressionOperator")
                    );

                if (expressionOperatorNode == null || expressionOperatorNode.Value != "CreateCrmType")
                    continue;

                var parametersNode = activityRef
                    .Descendants()
                    .FirstOrDefault(e =>
                        e.Name.LocalName == "InArgument"
                        && e.Attributes().Any(a => a.Name.LocalName == "Key" && a.Value == "Parameters")
                    );

                if (parametersNode == null || string.IsNullOrWhiteSpace(parametersNode.Value))
                    continue;

                string paramText = parametersNode.Value.Trim();
                if (!paramText.Contains("WorkflowPropertyType.EntityReference"))
                    continue;

                // Regex approach: 
                // Looking for something like:
                //   [New Object() { Microsoft.Xrm.Sdk.Workflow.WorkflowPropertyType.EntityReference, 
                //                   "chi_actiontype", 
                //                   "Some Label", 
                //                   ConditionBranchStep13_15 OR "SOME_GUID", 
                //                   "Lookup" }]
                // 
                // We do a capturing group for that 4th item which might be a direct GUID or a variable reference.

                var match = Regex.Match(
                    paramText,
                    @"\[New Object\(\)\s*\{\s*Microsoft\.Xrm\.Sdk\.Workflow\.WorkflowPropertyType\.EntityReference\s*,\s*""([^""]+)""\s*,\s*""([^""]+)""\s*,\s*([^,]+)\s*,\s*""([^""]+)""\s*\}\]",
                    RegexOptions.IgnoreCase
                );

                if (!match.Success)
                    continue;

                string entityName = match.Groups[1].Value;  // e.g. chi_actiontype
                string entityLabel = match.Groups[2].Value;  // e.g. "Some Label"
                string guidOrVariable = match.Groups[3].Value.Trim();
                string lookupType = match.Groups[4].Value;  // e.g. "Lookup"

                // Remove brackets if present
                if (guidOrVariable.StartsWith("[") && guidOrVariable.EndsWith("]"))
                {
                    guidOrVariable = guidOrVariable.Substring(1, guidOrVariable.Length - 2).Trim();
                }

                // Attempt to resolve the real GUID
                //  - If it is already in a standard GUID format, keep it.
                //  - Otherwise, check if it matches a variable name in guidDictionary.

                string finalGuid = null;
                // Basic check: if it looks like a GUID
                if (Guid.TryParse(guidOrVariable, out Guid parsedGuid))
                {
                    finalGuid = parsedGuid.ToString();
                }
                else
                {
                    // Possibly a variable name, e.g. ConditionBranchStep13_15
                    if (guidDictionary.ContainsKey(guidOrVariable))
                    {
                        finalGuid = guidDictionary[guidOrVariable];
                    }
                    else
                    {
                        // We have no matching dictionary entry, so we can't resolve it. 
                        // We'll just store the variable name as-is.
                        finalGuid = $"(Unresolved variable: {guidOrVariable})";
                    }
                }

                entityReferences.Add(new EntityReferenceInfo
                {
                    EntityName = entityName,
                    DisplayLabel = entityLabel,
                    LookupType = lookupType,
                    ResolvedGuid = finalGuid
                });
            }
            return entityReferences;
        }

    }






    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        // Path to your XAML file


    //        // Print results
    //        //Console.WriteLine($"Found {entityReferences.Count} EntityReference items:");

    //        //foreach (var info in entityReferences)
    //        //{
    //        //    Console.WriteLine("---------------------------------------");
    //        //    Console.WriteLine(" Entity Name:    " + info.EntityName);
    //        //    Console.WriteLine(" Display Label:  " + info.DisplayLabel);
    //        //    Console.WriteLine(" Lookup Type:    " + info.LookupType);
    //        //    Console.WriteLine(" Resolved GUID:  " + info.ResolvedGuid);
    //        //}

    //        //Console.WriteLine();
    //        //Console.WriteLine("Done. Press any key to exit.");
    //        //Console.ReadKey();
    //    }

    //    // Simple data class to hold the final info about an EntityReference.

    //}

}
