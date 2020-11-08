using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Microsoft.SqlDataTools.Model
{
    /// <summary>
    /// A SqlPackage.exe script action creates a Transact-SQL incremental update script that updates the schema of a target database to match the schema of a source database.
    /// </summary>
    [Description("A SqlPackage.exe script action creates a Transact-SQL incremental update script that updates the schema of a target database to match the schema of a source database.")]
    public class ScriptParameters : DeploymentParameters
    {
        DacActionValue action;
        /// <summary>
        /// Specifies the action to be performed.
        /// </summary>
        [Description("Specifies the action to be performed.")]
        public override DacActionValue Action { get => DacActionValue.Script; set => action = value; }

        /// <summary>
        /// Specifies an optional file path to output the deployment script. For Azure deployments, if there are TSQL commands to create or modify the master database, a script will be written to the same path but with "Filename_Master.sql" as the output file name.
        /// </summary>
        [Description("Specifies an optional file path to output the deployment script. For Azure deployments, if there are TSQL commands to create or modify the master database, a script will be written to the same path but with \"Filename_Master.sql\" as the output file name.")]
        [DefaultValue(typeof(string), null)]
        public string DeployScriptPath { get; set; }

        /// <summary>
        /// Specifies an optional file path to output the deployment report xml file.
        /// </summary>
        [Description("Specifies an optional file path to output the deployment report xml file.")]
        [DefaultValue(typeof(string), null)]
        public string DeployReportPath { get; set; }

        /// <summary>
        /// Specifies the file path where the output files are generated.
        /// </summary>
        [Description("Specifies the file path where the output files are generated.")]
        [DefaultValue(typeof(string), null)]
        public string OutputPath { get; set; }

        /// <summary>
        /// Specifies a target file (that is, a .dacpac file) to be used as the target of action instead of a database. If this parameter is used, no other target parameter shall be valid. This parameter shall be invalid for actions that only support database targets.
        /// </summary>
        [Description("Specifies a target file (that is, a .dacpac file) to be used as the target of action instead of a database. If this parameter is used, no other target parameter shall be valid. This parameter shall be invalid for actions that only support database targets.")]
        [DefaultValue(typeof(string), null)]
        public string TargetFile { get; set; }

    }
}
