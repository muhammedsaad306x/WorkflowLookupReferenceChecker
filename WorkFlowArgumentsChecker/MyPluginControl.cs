using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk.Workflow.Activities;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XrmToolBox.Extensibility;
using Microsoft.Xrm.Sdk.Organization;
using System.Xml.Linq;
using System.Net;
using McTools.Xrm.Connection;
using System.Collections.Specialized;
using System.Text.RegularExpressions;
using System.IO;

namespace WorkFlowArgumentsChecker
{



    public partial class MyPluginControl : MultipleConnectionsPluginControlBase
    {
        public IOrganizationService TargetService { get; set; }
        public MyPluginControl()
        {
            InitializeComponent();

            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("WorkflowName", "Workflow Name");
            dataGridView1.Columns.Add("EntityName", "EntityName");
            dataGridView1.Columns.Add("DisplayLabel", "DisplayLabel");
            dataGridView1.Columns.Add("LookupType", "LookupType");
            dataGridView1.Columns.Add("ResolvedGuid", "ResolvedGuid");
            dataGridView1.Columns.Add("Status", "Status");


        }


        private void MyPluginControl_Load(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ExecuteMethod(LoadSolutions);

        }
        private void LoadSolutions()
        {
            if (Service == null)
            {
                MessageBox.Show("Please Connect to environment first.");
                return;
            }
            try
            {
                WorkAsync(new WorkAsyncInfo
                {
                    Message = "Loading Solutions ...",
                    Work = (worker, args) =>
                    {
                        // Simulate some work

                        // Do your work here
                        // You can use the worker.ReportProgress method to report progress
                        // and the args.Result property to store the result of your work
                        worker.WorkerReportsProgress = true;
                        var solutions = GetSolutions(Service);
                        args.Result = solutions;
                        worker.ReportProgress(100, "Solutions loaded");
                    },
                    PostWorkCallBack = (args) =>
                    {
                        // This method is called when the work is done
                        // You can use the args.Result property to get the result of your work
                        var solutions = ((List<Entity>)args.Result)
                        .Select(s => new CrmReferenceListItem
                        {
                            Label = s.GetAttributeValue<string>("friendlyname"),
                            Id = s.Id,
                            LogicalName = s.LogicalName,
                            Entity = s
                        })
                        .OrderBy(s => s.Label)
                        .ToList();
                        comboBox1.DataSource = solutions;
                        comboBox1.DisplayMember = "Label";
                        comboBox1.ValueMember = "Id";

                    },
                });
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Error:{ex.Message}");

            }
        }

        public List<Entity> GetSolutions(IOrganizationService svc)
        {
            var qe = new QueryExpression("solution")
            {
                ColumnSet = new ColumnSet("solutionid", "friendlyname", "version"),
                Criteria = new FilterExpression
                {
                    Conditions = {
                    new ConditionExpression("isvisible", ConditionOperator.Equal, true),
                    new ConditionExpression("ismanaged", ConditionOperator.Equal, false)
                    }
                }
            };
            return svc.RetrieveMultiple(qe).Entities.Select(e => e).ToList();
        }

        public List<Entity> GetWorkflows(IOrganizationService svc, Guid solutionId)
        {
            // 1. get component ids
            var compQ = new QueryExpression("solutioncomponent")
            {
                ColumnSet = new ColumnSet("objectid"),
                Criteria = new FilterExpression
                {
                    Conditions = {
                new ConditionExpression("solutionid", ConditionOperator.Equal, solutionId),
                new ConditionExpression("componenttype", ConditionOperator.Equal, 29) // 29 = workflow
            }
                }
            };
            var ids = (svc.RetrieveMultiple(compQ))
                      .Entities.Select(e => e.GetAttributeValue<Guid>("objectid")).ToArray();
            if (ids.Length < 1)
            {
                return new List<Entity>();
            }
            // 2. bulk retrieve workflows
            var wfQ = new QueryExpression("workflow")
            {
                ColumnSet = new ColumnSet("workflowid", "name", "type", "xaml"),
                Criteria = new FilterExpression
                {
                    Conditions = {
                new ConditionExpression("workflowid", ConditionOperator.In, ids),
                new ConditionExpression("category", ConditionOperator.Equal, 0) // 0 = workflow (vs. 1 = dialog, 2 = BP, etc.)
            }
                }
            };
            return (svc.RetrieveMultiple(wfQ)).Entities.Select(e => e).ToList();
        }


        void LoadChoices(CheckedListBox control, IEnumerable<object> choices, string displayMember, string valueMember)
        {
            control.BeginUpdate();            // no flicker
            control.Items.Clear();            // drop old items
            if (choices.Any())
            {
                control.Items.AddRange(choices.ToArray());   // fast bulk add
                control.DisplayMember = displayMember; // set display member
                control.ValueMember = valueMember;   // set value member 
            }

            //if (initiallyChecked != null)
            //{
            //    // restore check marks if you have to
            //    for (int i = 0; i < checkedListBox1.Items.Count; i++)
            //        checkedListBox1.SetItemChecked(
            //            i,
            //            initiallyChecked.Contains((string)checkedListBox1.Items[i]));
            //}
            control.EndUpdate();
        }


        private void toolStripButton2_Click_1(object sender, EventArgs e)
        {
            WorkflowEntityReferenceExtractor extractor = new WorkflowEntityReferenceExtractor();
            try
            {
                dataGridView1.Rows.Clear(); // Clear previous results

                foreach (CrmReferenceListItem item in checkedListBox1.CheckedItems)
                {
                    var workflow = item.Entity;
                    var xaml = workflow.GetAttributeValue<string>("xaml");

                    if (!string.IsNullOrEmpty(xaml))
                    {
                        var items = extractor.GetWorkflowReferences(xaml);


                        foreach (var arg in items)
                        {
                            dataGridView1.Rows.Add(
                                workflow.GetAttributeValue<string>("name"),
                                arg.EntityName ?? "(Unnamed)",
                                WebUtility.HtmlDecode(arg.DisplayLabel),
                                arg.LookupType,
                                arg.ResolvedGuid
                            );
                        }
                    }
                }

                if (dataGridView1.Rows.Count == 0)
                {
                    MessageBox.Show("No EntityReference arguments found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                var solutionCB = (ComboBox)sender;
                //textBox_debugBox.AppendText(solutionCB.SelectedValue.ToString());

                if (solutionCB.SelectedItem != null)
                {
                    var workflows = GetWorkflows(Service, ((CrmReferenceListItem)solutionCB.SelectedItem).Id);

                    //listBox1.Items.Clear();
                    var items = workflows.Select(w => new CrmReferenceListItem()
                    {
                        Id = w.Id,
                        Label = w.GetAttributeValue<string>("name"),
                        LogicalName = "workflow",
                        Entity = w

                    }).OrderBy(c => c.Label).ToList();
                    if (items.Any())
                    {
                        LoadChoices(checkedListBox1, items, "Label", "Id");
                        //checkedListBox1.DataSource = items;
                        //checkedListBox1.DisplayMember = "Label";
                        //checkedListBox1.ValueMember = "Id";
                    }
                    else
                    {
                        LoadChoices(checkedListBox1, new List<string>(), "Label", "Id");
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Error:{ex.Message}");
            }
        }


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, true);
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, false);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddAdditionalOrganization();

            LogInfo(Name, "AddAdditionalOrganization", "AddAdditionalOrganization", "AddAdditionalOrganization", "AddAdditionalOrganization");
        }

        private void toolStripButtonCheckTarget_Click(object sender, EventArgs e)
        {
            if (TargetService == null)
            {
                MessageBox.Show("Please select a target environment first.");
                return;
            }

            // Extract entity+ID pairs first to use in background thread
            var records = dataGridView1.Rows
                .Cast<DataGridViewRow>()
                .Where(row =>
                    Guid.TryParse(row.Cells["ResolvedGuid"].Value?.ToString(), out _) &&
                    !string.IsNullOrWhiteSpace(row.Cells["EntityName"].Value?.ToString()))
                .Select(row => new
                {
                    Row = row,
                    EntityName = row.Cells["EntityName"].Value.ToString(),
                    Id = Guid.Parse(row.Cells["ResolvedGuid"].Value.ToString())
                })
                .ToList();

            WorkAsync(new WorkAsyncInfo
            {
                Message = "Checking record existence in target environment...",
                Work = (worker, args) =>
                {
                    foreach (var record in records)
                    {
                        try
                        {
                            var exists = TargetService.Retrieve(record.EntityName, record.Id, new ColumnSet(false));
                            record.Row.Cells["Status"].Value = "Exist";
                            record.Row.Cells["Status"].Style.ForeColor = Color.Green;
                        }
                        catch
                        {
                            record.Row.Cells["Status"].Value = "Missing";
                            record.Row.Cells["Status"].Style.ForeColor = Color.Red;
                        }
                    }
                },
                PostWorkCallBack = (args) =>
                {
                    MessageBox.Show("Check completed.");
                },
                AsyncArgument = null,
                IsCancelable = false
            });
        }


        public override void UpdateConnection(IOrganizationService newService, ConnectionDetail detail, string actionName, object parameter)
        {
            base.UpdateConnection(newService, detail, actionName, parameter);
            //LogInfo(actionName, detail, parameter);
            if (actionName == "AdditionalOrganization")
            {
                if (newService != null)
                {
                    TargetService = newService;
                    label4.Text = detail.ConnectionName;
                    label4.ForeColor = Color.Green;
                }
                else
                {
                    label4.Text = "Unselected";
                    label4.ForeColor = Color.Red;
                }
            }
            else
            {
                label3.Text = detail.ConnectionName;
            }

            //if (mySettings != null && detail != null)
            //{
            //    mySettings.LastUsedOrganizationWebappUrl = detail.WebApplicationUrl;
            //    LogInfo("Connection has changed to: {0}", detail.WebApplicationUrl);
            //}
        }

        protected override void ConnectionDetailsUpdated(NotifyCollectionChangedEventArgs e)
        {
            LogInfo("ConnectionDetailsUpdated");
            LogInfo($"Action: {e.Action.ToString()}, NewStartingIndex: {e.NewStartingIndex}, OldStartingIndex: {e.OldStartingIndex}, Item Count: {AdditionalConnectionDetails.Count} ");

            //// update the list box with the connections
            //listBoxActiveConnections.DataSource = null;
            //listBoxActiveConnections.DataSource = AdditionalConnectionDetails.ToList();
            //listBoxActiveConnections.DisplayMember = "ConnectionName";
            //listBoxActiveConnections.ValueMember = "ConnectionId";
        }


        private void toolStripButtonGenerateFetch_Click(object sender, EventArgs e)
        {
            //DataGridViewSelectedRowCollection selectedRows = dataGridView1.SelectedRows;

            IEnumerable<DataGridViewRow> selectedRows = dataGridView1.Rows.Cast<DataGridViewRow>();

            if (radioButton2.Checked)
            {
                selectedRows = selectedRows.Where(r => r.Selected);
            }
            else if (radioButton3.Checked)
            {
                selectedRows = selectedRows.Where(r =>
                    r.Cells["Status"].Value?.ToString().Equals("Missing", StringComparison.OrdinalIgnoreCase) == true);
            }


            if (selectedRows.Count() == 0)
            {
                MessageBox.Show("Please select one or more full rows.");
                return;
            }

            var filters = new Dictionary<string, List<string>>();

            foreach (DataGridViewRow row in selectedRows)
            {
                string entityName = row.Cells["EntityName"].Value?.ToString();
                string guid = row.Cells["ResolvedGuid"].Value?.ToString();

                if (Guid.TryParse(guid, out _))
                {
                    if (!filters.ContainsKey(entityName))
                        filters[entityName] = new List<string>();

                    filters[entityName].Add(guid);
                }
            }

            if (filters.Count == 0)
            {
                richTextBox_debugBox.Text = "No valid GUIDs selected.";
                return;
            }

            var sb = new StringBuilder();
            foreach (var kvp in filters)
            {
                string entityName = kvp.Key;
                var values = kvp.Value;

                sb.AppendLine($"<entity name=\"{entityName}\">");
                sb.AppendLine($"  <filter>");
                sb.AppendLine($"    <condition attribute=\"{entityName}id\" operator=\"in\">");

                foreach (var id in values.Distinct())
                {
                    sb.AppendLine($"      <value>{id}</value>");
                }

                sb.AppendLine("    </condition>");
                sb.AppendLine("  </filter>");
                sb.AppendLine("</entity>");
                sb.AppendLine();
            }

            //richTextBox_debugBox.Text = sb.ToString();
            //tabControlRight.SelectedTab = tabPageDebug;

            FormatFetchXml(sb.ToString(), richTextBox_debugBox);
            tabControlRight.SelectedTab = tabPageDebug;
        }

        private void FormatFetchXml(string xml, RichTextBox rtb)
        {
            rtb.Clear();
            rtb.Font = new Font("Consolas", 10);
            rtb.ReadOnly = false;

            var tagRegex = new Regex(@"</?[^>]+?>");
            var attrRegex = new Regex(@"\b\w+=['\""][^'\""]+['\""]");

            using (var reader = new StringReader(xml))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    int start = rtb.TextLength;

                    rtb.AppendText(line + System.Environment.NewLine);


                    foreach (Match tag in tagRegex.Matches(line))
                    {
                        rtb.Select(start + tag.Index, tag.Length);
                        rtb.SelectionColor = Color.Blue;


                        foreach (Match attr in attrRegex.Matches(tag.Value))
                        {
                            int attrStart = start + tag.Index + tag.Value.IndexOf(attr.Value);
                            rtb.Select(attrStart, attr.Length);
                            rtb.SelectionColor = Color.Brown;
                        }
                    }
                }
            }

            rtb.SelectionLength = 0;
            rtb.SelectionColor = Color.Black;
            rtb.ReadOnly = true;
        }

    }


    public class CrmReferenceListItem
    {
        public string Label { get; set; }
        public Guid Id { get; set; }
        public string LogicalName { get; set; }
        public Entity Entity { get; set; }

        public override string ToString()
        {
            return $"{LogicalName}({Id})";
        }
    }
}
