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


  
    }

    [Flags]
    public enum FormattingOptions
    {
        IgnoreDefaults,
        SerializeAllProperties
    }
}
