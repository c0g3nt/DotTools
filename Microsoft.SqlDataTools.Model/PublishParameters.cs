using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Microsoft.SqlDataTools.Model
{
    /// <summary>
    /// A SqlPackage.exe publish operation incrementally updates the schema of a target database to match the structure of a source database. Publishing a deployment package that contains user data for all or a subset of tables update the table data in addition to the schema. Data deployment overwrites the schema and data in existing tables of the target database. Data deployment will not change existing schema or data in the target database for tables not included in the deployment package.
    /// </summary>
    [Description("A SqlPackage.exe publish operation incrementally updates the schema of a target database to match the structure of a source database. Publishing a deployment package that contains user data for all or a subset of tables update the table data in addition to the schema. Data deployment overwrites the schema and data in existing tables of the target database. Data deployment will not change existing schema or data in the target database for tables not included in the deployment package.")]
    public class PublishParameters : DeploymentParameters
    {
        private DacActionValue action;
        /// <summary>
        /// Specifies the action to be performed.
        /// </summary>
        [Description("Specifies the action to be performed.")]
        [DefaultValue(typeof(DacActionValue), nameof(DacActionValue.Publish))]
        public override DacActionValue Action { get => DacActionValue.Publish; set => this.action = value; }

        /// <summary>
        /// Specifies what authentication method is used for accessing Azure KeyVault if a publish operation includes modifications to an encrypted table/column.
        /// </summary>
        [Description("Specifies what authentication method is used for accessing Azure KeyVault if a publish operation includes modifications to an encrypted table/column.")]
        [DefaultValue(typeof(AzureKeyVaultAuthMethodValue?), null)]
        public AzureKeyVaultAuthMethodValue? AzureKeyVaultAuthMethod { get; set; }

        /// <summary>
        /// Specifies the Client ID to be used in authenticating against Azure KeyVault, when necessary
        /// </summary>
        [Description("Specifies the Client ID to be used in authenticating against Azure KeyVault, when necessary")]
        [DefaultValue(typeof(string), null)]
        public string ClientId { get; set; }

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
        /// Specifies the Client Secret to be used in authenticating against Azure KeyVault, when necessary
        /// </summary>
        [Description("Specifies the Client Secret to be used in authenticating against Azure KeyVault, when necessary")]
        [DefaultValue(typeof(string), null)]
        [ParameterCmdArgument(ShortForm = "secr")]
        public string Secret { get; set; }

    }
}
