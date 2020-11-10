using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Microsoft.SqlDataTools.Model
{
    /// <summary>
    /// A SqlPackage.exe Export action exports a live database from SQL Server or Azure SQL Database to a BACPAC package (.bacpac file). By default, data for all tables will be included in the .bacpac file. Optionally, you can specify only a subset of tables for which to export data. Validation for the Export action ensures Azure SQL Database compatibility for the complete targeted database even if a subset of tables is specified for the export.
    /// </summary>
    [Description("A SqlPackage.exe Export action exports a live database from SQL Server or Azure SQL Database to a BACPAC package (.bacpac file). By default, data for all tables will be included in the .bacpac file. Optionally, you can specify only a subset of tables for which to export data. Validation for the Export action ensures Azure SQL Database compatibility for the complete targeted database even if a subset of tables is specified for the export.")]
    public class ExportParameters
    {

        /// <summary>
        /// Specifies the action to be performed.
        /// </summary>
        [Description("Specifies the action to be performed.")]
        public DacActionValue Action { get => DacActionValue.Export; }

        /// <summary>
        /// Specifies the token based authentication access token to use when connect to the target database.
        /// </summary>
        [Description("Specifies the token based authentication access token to use when connect to the target database.")]
        [DefaultValue(typeof(string), null)]
        public string AccessToken { get; set; }

        /// <summary>
        /// Specifies whether diagnostic logging is output to the console. Defaults to False.
        /// </summary>
        [Description("Specifies whether diagnostic logging is output to the console. Defaults to False.")]
        [DefaultValue(false)]
        public bool Diagnostics { get; set; }

        /// <summary>
        /// Specifies a file to store diagnostic logs.
        /// </summary>
        [Description("Specifies a file to store diagnostic logs.")]
        [DefaultValue(typeof(string), null)]
        public string DiagnosticsFile { get; set; }

        /// <summary>
        /// Specifies the degree of parallelism for concurrent operations running against a database. The default value is 8.
        /// </summary>
        [Description("Specifies the degree of parallelism for concurrent operations running against a database. The default value is 8.")]
        [DefaultValue(8)]
        public int MaxParallelism { get; set; } = 8;

        /// <summary>
        /// Specifies if sqlpackage.exe should overwrite existing files. Specifying false causes sqlpackage.exe to abort action if an existing file is encountered. Default value is True.
        /// </summary>
        [Description("Specifies if sqlpackage.exe should overwrite existing files. Specifying false causes sqlpackage.exe to abort action if an existing file is encountered. Default value is True.")]
        [DefaultValue(true)]
        public bool OverwriteFiles { get; set; } = true;

        /// <summary>
        /// Specifies a name value pair for an action-specific property;{PropertyName}={Value}. Refer to the help for a specific action to see that action's property names. Example: sqlpackage.exe /Action:Export /?.
        /// </summary>
        [Description("Specifies a name value pair for an action-specific property;{PropertyName}={Value}. Refer to the help for a specific action to see that action's property names. Example: sqlpackage.exe /Action:Export /?.")]
        public ExportProperties Properties { get; set; }

        /// <summary>
        /// Specifies whether detailed feedback is suppressed. Defaults to False.
        /// </summary>
        [Description("Specifies whether detailed feedback is suppressed. Defaults to False.")]
        [DefaultValue(false)]
        public bool Quiet { get; set; }

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
        [DefaultValue(typeof(bool?), null)]
        public bool? SourceEncryptConnection { get; set; }

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
        /// Specifies a target file (that is, a .dacpac file) to be used as the target of action instead of a database. If this parameter is used, no other target parameter shall be valid. This parameter shall be invalid for actions that only support database targets.
        /// </summary>
        [Description("Specifies a target file (that is, a .dacpac file) to be used as the target of action instead of a database. If this parameter is used, no other target parameter shall be valid. This parameter shall be invalid for actions that only support database targets.")]
        [DefaultValue(typeof(string), null)]
        public string TargetFile { get; set; }

        /// <summary>
        /// Represents the Azure AD tenant ID or domain name. This option is required to support guest or imported Azure AD users as well as Microsoft accounts such as outlook.com, hotmail.com, or live.com. If this parameter is omitted, the default tenant ID for Azure AD will be used, assuming that the authenticated user is a native user for this AD. However, in this case any guest or imported users and/or Microsoft accounts hosted in this Azure AD are not supported and the operation will fail.
        /// </summary>
        [Description("Represents the Azure AD tenant ID or domain name. This option is required to support guest or imported Azure AD users as well as Microsoft accounts such as outlook.com, hotmail.com, or live.com. If this parameter is omitted, the default tenant ID for Azure AD will be used, assuming that the authenticated user is a native user for this AD. However, in this case any guest or imported users and/or Microsoft accounts hosted in this Azure AD are not supported and the operation will fail.")]
        [DefaultValue(typeof(string), null)]
        public string TenantId { get; set; }

        /// <summary>
        /// Specifies if Universal Authentication should be used. When set to True, the interactive authentication protocol is activated supporting MFA. This option can also be used for Azure AD authentication without MFA, using an interactive protocol requiring the user to enter their username and password or integrated authentication (Windows credentials). When /UniversalAuthentication is set to True, no Azure AD authentication can be specified in SourceConnectionString (/scs). When /UniversalAuthentication is set to False, Azure AD authentication must be specified in SourceConnectionString (/scs).For more information about Active Directory Universal Authentication, see Universal Authentication with SQL Database and Azure Synapse Analytics (SSMS support for MFA).
        /// </summary>
        [Description("Specifies if Universal Authentication should be used. When set to True, the interactive authentication protocol is activated supporting MFA. This option can also be used for Azure AD authentication without MFA, using an interactive protocol requiring the user to enter their username and password or integrated authentication (Windows credentials). When /UniversalAuthentication is set to True, no Azure AD authentication can be specified in SourceConnectionString (/scs). When /UniversalAuthentication is set to False, Azure AD authentication must be specified in SourceConnectionString (/scs).For more information about Active Directory Universal Authentication, see Universal Authentication with SQL Database and Azure Synapse Analytics (SSMS support for MFA).")]
        [DefaultValue(typeof(bool?), null)]
        public bool? UniversalAuthentication { get; set; }


    }
}
