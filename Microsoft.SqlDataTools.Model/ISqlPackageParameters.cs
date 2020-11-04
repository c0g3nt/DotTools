using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Microsoft.SqlDataTools.Model
{
    public interface ISqlPackageParameters
    {
        string ToolsVersion { get; set; } 
        ISqlPackageProperties Properties { get; set; }
        IEnumerable<SqlCmdVariable> Variables { get; set; }
         XDocument AsXDocument(
            FormattingOptions options = FormattingOptions.IgnoreDefaults) =>
            SqlPackageParametersFormatter.AsXDocument(this, options);

         void SaveXml(
            string filename,
            FormattingOptions options = FormattingOptions.IgnoreDefaults) =>
            AsXDocument(options).Save(filename);
    }

    [Flags]
    public enum FormattingOptions
    {
        IgnoreDefaults,
        SerializeAllProperties
    }
}
