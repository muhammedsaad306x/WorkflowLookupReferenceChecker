using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Interfaces;

namespace WorkFlowArgumentsChecker
{
    [Export(typeof(IXrmToolBoxPlugin)),
      ExportMetadata("Name", "WorkFlow Arguments Checker "),
      ExportMetadata("Description", "To find lookups used as arguments in given workflow "),
      // Please specify the base64 content of a 32x32 pixels image
      ExportMetadata("SmallImageBase64", null),
      // Please specify the base64 content of a 80x80 pixels image
      ExportMetadata("BigImageBase64", null),
      ExportMetadata("BackgroundColor", "Lavender"),
      ExportMetadata("PrimaryFontColor", "Black"),
      ExportMetadata("SecondaryFontColor", "Gray")]
    public class WorkFlowArgumentsCheckerPlugin : PluginBase
    {
        public override IXrmToolBoxPluginControl GetControl()
        {
            return new MyPluginControl(); 
        }
    }
}
