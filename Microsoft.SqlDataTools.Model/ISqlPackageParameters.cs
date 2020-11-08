using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Xml.Linq;

namespace Microsoft.SqlDataTools.Model
{
    public interface ISqlPackageParameters
    {
        string ToolsVersion { get; set; } 
        ISqlPackageProperties Properties { get; set; }
        IEnumerable<SqlCmdVariable> Variables { get; set; }

        /// <summary>
        /// Specifies the action to be performed.
        /// </summary>
        [Description("Specifies the action to be performed.")]
        DacActionValue Action { get; set; }

    }

    [Flags]
    public enum FormattingOptions
    {
        IgnoreDefaults,
        SerializeAllProperties
    }
}
