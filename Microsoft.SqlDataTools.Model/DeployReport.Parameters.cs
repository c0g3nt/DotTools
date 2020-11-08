using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace Microsoft.SqlDataTools.Model
{

    public class DeployReportParameters : DeploymentParameters
    {

        private DacActionValue action;
        public override DacActionValue Action { get => DacActionValue.DeployReport; set => action = value; }


        /// <summary>
        /// Specifies the file path where the output files are generated.
        /// </summary>
        [Description("Specifies the file path where the output files are generated.")]
        [DefaultValue(typeof(string), null)]
        [SqlCmdArgument("op")]
        public string OutputPath { get; set; }

        /// <summary>
        /// Specifies a target file (that is, a .dacpac file) to be used as the target of action instead of a database. If this parameter is used, no other target parameter shall be valid. This parameter shall be invalid for actions that only support database targets.
        /// </summary>
        [Description("Specifies a target file (that is, a .dacpac file) to be used as the target of action instead of a database. If this parameter is used, no other target parameter shall be valid. This parameter shall be invalid for actions that only support database targets.")]
        [DefaultValue(typeof(string), null)]
        public string TargetFile { get; set; }


    }
}
