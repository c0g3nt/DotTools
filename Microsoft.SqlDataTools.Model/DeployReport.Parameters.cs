using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace Microsoft.SqlDataTools.Model
{

    public struct DeployReportParameters : ISqlPackageParameters
    {

        #region BackingFields
        private bool? diagnostics;
        private int? maxParallelism;
        private bool? overwriteFiles;
        private bool? quiet;
        private bool? sourceEncryptConnection;
        private string toolsVersion;
        #endregion

        public string ToolsVersion { get => toolsVersion ?? "Current"; set => toolsVersion = value; }

        /// <summary>
        /// Specifies the action to be performed.
        /// </summary>
        [Description("Specifies the action to be performed.")]
        [ShortForm("a")]
        public DacActionValue Action { get => DacActionValue.DeployReport; }

        /// <summary>
        /// Specifies the token based authentication access token to use when connect to the target database.
        /// </summary>
        [Description("Specifies the token based authentication access token to use when connect to the target database.")]
        [DefaultValue(typeof(string), null)]
        [ShortForm("at")]
        public string AccessToken { get; set; }

        /// <summary>
        /// Specifies whether diagnostic logging is output to the console. Defaults to False.
        /// </summary>
        [Description("Specifies whether diagnostic logging is output to the console. Defaults to False.")]
        [DefaultValue(false)]
        [ShortForm("/d")]
        public bool? Diagnostics { get => diagnostics ?? false; set => diagnostics = value; }

        /// <summary>
        /// Specifies a file to store diagnostic logs.
        /// </summary>
        [Description("Specifies a file to store diagnostic logs.")]
        [DefaultValue(typeof(string), null)]
        [ShortForm("df")]
        public string DiagnosticsFile { get; set; }

        /// <summary>
        /// Specifies the degree of parallelism for concurrent operations running against a database. The default value is 8.
        /// </summary>
        [Description("Specifies the degree of parallelism for concurrent operations running against a database. The default value is 8.")]
        [DefaultValue(typeof(int?), "8")]
        [ShortForm("mp")]
        public int? MaxParallelism { get => maxParallelism ?? 8; set => maxParallelism = value; }

        /// <summary>
        /// Specifies the file path where the output files are generated.
        /// </summary>
        [Description("Specifies the file path where the output files are generated.")]
        [DefaultValue(typeof(string), null)]
        [ShortForm("op")]
        public string OutputPath { get; set; }

        /// <summary>
        /// Specifies if sqlpackage.exe should overwrite existing files. Specifying false causes sqlpackage.exe to abort action if an existing file is encountered. Default value is True.
        /// </summary>
        [Description("Specifies if sqlpackage.exe should overwrite existing files. Specifying false causes sqlpackage.exe to abort action if an existing file is encountered. Default value is True.")]
        [DefaultValue(typeof(bool?), "true")]
        [ShortForm("of")]
        public bool? OverwriteFiles { get => overwriteFiles ?? true; set => overwriteFiles = value; }

        /// <summary>
        /// Specifies the file path to a DAC Publish Profile. The profile defines a collection of properties and variables to use when generating outputs.
        /// </summary>
        [Description("Specifies the file path to a DAC Publish Profile. The profile defines a collection of properties and variables to use when generating outputs.")]
        [DefaultValue(typeof(string), null)]
        [ShortForm("pr")]
        public string Profile { get; set; }

        /// <summary>
        /// Specifies a name value pair for an action-specific property; {PropertyName}={Value}. Refer to the help for a specific action to see that action's property names. Example: sqlpackage.exe /Action:DeployReport /?.
        /// </summary>
        [Description("Specifies a name value pair for an action-specific property; {PropertyName}={Value}. Refer to the help for a specific action to see that action's property names. Example: sqlpackage.exe /Action:DeployReport /?.")]
        public DeployReportProperties DeployReportProperties { get; set; }

        ISqlPackageProperties ISqlPackageParameters.Properties
        {
            get => (ISqlPackageProperties)DeployReportProperties;
            set => DeployReportProperties = (DeployReportProperties)value;
        }
        /// <summary>
        /// Specifies whether detailed feedback is suppressed. Defaults to False.
        /// </summary>
        [Description("Specifies whether detailed feedback is suppressed. Defaults to False.")]
        [DefaultValue(false)]
        public bool? Quiet { get => quiet ?? false; set => quiet = value; }

        /// <summary>
        /// Specifies a valid SQL Server/Azure connection string to the source database. If this parameter is specified, it shall be used exclusively of all other source parameters.
        /// </summary>
        [Description("Specifies a valid SQL Server/Azure connection string to the source database. If this parameter is specified, it shall be used exclusively of all other source parameters.")]
        [DefaultValue(typeof(string), null)]
        public string SourceConnectionString { get; set; }

        /// <summary>
        /// Defines the name of the source database.
        /// </summary>
        [Description("Defines the name of the source database.")]
        [DefaultValue(typeof(string), null)]
        public string SourceDatabaseName { get; set; }

        /// <summary>
        /// Specifies if SQL encryption should be used for the source database connection.
        /// </summary>
        [Description("Specifies if SQL encryption should be used for the source database connection.")]
        [DefaultValue(false)]
        public bool? SourceEncryptConnection { get => sourceEncryptConnection ?? false; set => sourceEncryptConnection = value; }

        /// <summary>
        /// Specifies a source file to be used as the source of action instead of a database. If this parameter is used, no other source parameter shall be valid.
        /// </summary>
        [Description("Specifies a source file to be used as the source of action instead of a database. If this parameter is used, no other source parameter shall be valid.")]
        [DefaultValue(typeof(string), null)]
        public string SourceFile { get; set; }

        /// <summary>
        /// For SQL Server Auth scenarios, defines the password to use to access the source database.
        /// </summary>
        [Description("For SQL Server Auth scenarios, defines the password to use to access the source database.")]
        [DefaultValue(typeof(string), null)]
        public string SourcePassword { get; set; }

        /// <summary>
        /// Defines the name of the server hosting the source database.
        /// </summary>
        [Description("Defines the name of the server hosting the source database.")]
        [DefaultValue(typeof(string), null)]
        public string SourceServerName { get; set; }

        /// <summary>
        /// Specifies the timeout for establishing a connection to the source database in seconds.
        /// </summary>
        [Description("Specifies the timeout for establishing a connection to the source database in seconds.")]
        [DefaultValue(typeof(int?), null)]
        public int? SourceTimeout { get; set; }

        /// <summary>
        /// Specifies whether to use TLS to encrypt the source database connection and bypass walking the certificate chain to validate trust.
        /// </summary>
        [Description("Specifies whether to use TLS to encrypt the source database connection and bypass walking the certificate chain to validate trust.")]
        [DefaultValue(typeof(bool?), null)]
        public bool? SourceTrustServerCertificate { get; set; }

        /// <summary>
        /// For SQL Server Auth scenarios, defines the SQL Server user to use to access the source database.
        /// </summary>
        [Description("For SQL Server Auth scenarios, defines the SQL Server user to use to access the source database.")]
        [DefaultValue(typeof(string), null)]
        public string SourceUser { get; set; }

        /// <summary>
        /// Specifies a valid SQL Server/Azure connection string to the target database. If this parameter is specified, it shall be used exclusively of all other target parameters.
        /// </summary>
        [Description("Specifies a valid SQL Server/Azure connection string to the target database. If this parameter is specified, it shall be used exclusively of all other target parameters.")]
        [DefaultValue(typeof(string), null)]
        public string TargetConnectionString { get; set; }

        /// <summary>
        /// Specifies an override for the name of the database that is the target of sqlpackage.exe Action.
        /// </summary>
        [Description("Specifies an override for the name of the database that is the target of sqlpackage.exe Action.")]
        [DefaultValue(typeof(string), null)]
        public string TargetDatabaseName { get; set; }

        /// <summary>
        /// Specifies if SQL encryption should be used for the target database connection.
        /// </summary>
        [Description("Specifies if SQL encryption should be used for the target database connection.")]
        [DefaultValue(typeof(bool?), null)]
        public bool? TargetEncryptConnection { get; set; }

        /// <summary>
        /// Specifies a target file (that is, a .dacpac file) to be used as the target of action instead of a database. If this parameter is used, no other target parameter shall be valid. This parameter shall be invalid for actions that only support database targets.
        /// </summary>
        [Description("Specifies a target file (that is, a .dacpac file) to be used as the target of action instead of a database. If this parameter is used, no other target parameter shall be valid. This parameter shall be invalid for actions that only support database targets.")]
        [DefaultValue(typeof(string), null)]
        public string TargetFile { get; set; }

        /// <summary>
        /// For SQL Server Auth scenarios, defines the password to use to access the target database.
        /// </summary>
        [Description("For SQL Server Auth scenarios, defines the password to use to access the target database.")]
        [DefaultValue(typeof(string), null)]
        public string TargetPassword { get; set; }

        /// <summary>
        /// Defines the name of the server hosting the target database.
        /// </summary>
        [Description("Defines the name of the server hosting the target database.")]
        [DefaultValue(typeof(string), null)]
        public string TargetServerName { get; set; }

        /// <summary>
        /// Specifies the timeout for establishing a connection to the target database in seconds. For Azure AD, it is recommended that this value be greater than or equal to 30 seconds.
        /// </summary>
        [Description("Specifies the timeout for establishing a connection to the target database in seconds. For Azure AD, it is recommended that this value be greater than or equal to 30 seconds.")]
        [DefaultValue(typeof(int?), null)]
        public int? TargetTimeout { get; set; }

        /// <summary>
        /// Specifies whether to use TLS to encrypt the target database connection and bypass walking the certificate chain to validate trust.
        /// </summary>
        [Description("Specifies whether to use TLS to encrypt the target database connection and bypass walking the certificate chain to validate trust.")]
        [DefaultValue(typeof(bool?), null)]
        public bool? TargetTrustServerCertificate { get; set; }

        /// <summary>
        /// For SQL Server Auth scenarios, defines the SQL Server user to use to access the target database.
        /// </summary>
        [Description("For SQL Server Auth scenarios, defines the SQL Server user to use to access the target database.")]
        [DefaultValue(typeof(string), null)]
        public string TargetUser { get; set; }

        /// <summary>
        /// Represents the Azure AD tenant ID or domain name. This option is required to support guest or imported Azure AD users as well as Microsoft accounts such as outlook.com, hotmail.com, or live.com. If this parameter is omitted, the default tenant ID for Azure AD will be used, assuming that the authenticated user is a native user for this AD. However, in this case any guest or imported users and/or Microsoft accounts hosted in this Azure AD are not supported and the operation will fail.
        /// </summary>
        [Description("Represents the Azure AD tenant ID or domain name. This option is required to support guest or imported Azure AD users as well as Microsoft accounts such as outlook.com, hotmail.com, or live.com. If this parameter is omitted, the default tenant ID for Azure AD will be used, assuming that the authenticated user is a native user for this AD. However, in this case any guest or imported users and/or Microsoft accounts hosted in this Azure AD are not supported and the operation will fail.")]
        [DefaultValue(typeof(string), null)]
        public string TenantId { get; set; }
        /// <summary>
        /// Specifies if Universal Authentication should be used. When set to True, the interactive authentication protocol is activated supporting MFA. This option can also be used for Azure AD authentication without MFA, using an interactive protocol requiring the user to enter their username and password or integrated authentication (Windows credentials). When /UniversalAuthentication is set to True, no Azure AD authentication can be specified in SourceConnectionString (/scs). When /UniversalAuthentication is set to False, Azure AD authentication must be specified in SourceConnectionString (/scs).
        /// </summary>
        [Description("Specifies if Universal Authentication should be used. When set to True, the interactive authentication protocol is activated supporting MFA. This option can also be used for Azure AD authentication without MFA, using an interactive protocol requiring the user to enter their username and password or integrated authentication (Windows credentials). When /UniversalAuthentication is set to True, no Azure AD authentication can be specified in SourceConnectionString (/scs). When /UniversalAuthentication is set to False, Azure AD authentication must be specified in SourceConnectionString (/scs).")]
        [DefaultValue(typeof(bool?), null)]
        public bool? UniversalAuthentication { get; set; }

        /// <summary>
        /// Specifies a name value pair for an action-specific variable;
        ///{ VariableName}={ Value}. The DACPAC file contains the list of valid SQLCMD variables. An error results if a value is not provided for every variable.
        /// </summary>
        [Description("Specifies a name value pair for an action-specific variable;{ VariableName}={ Value}. The DACPAC file contains the list of valid SQLCMD variables. An error results if a value is not provided for every variable.")]
        public IEnumerable<SqlCmdVariable> Variables { get; set; }

    }
}
