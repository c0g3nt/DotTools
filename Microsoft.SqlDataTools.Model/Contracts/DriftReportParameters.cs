using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Microsoft.SqlDataTools.Model.Contracts
{
    /// <summary>
    /// A SqlPackage.exe report action creates an XML report of the changes that have been made to the registered database since it was last registered
    /// </summary>
    [Description("A SqlPackage.exe report action creates an XML report of the changes that have been made to the registered database since it was last registered")]
    public class DriftReportParameters
    {
        /// <summary>
        /// Specifies the action to be performed.
        /// </summary>
        [Description("Specifies the action to be performed.")]
        public DacActionValue Action { get => DacActionValue.DriftReport; }

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
        /// Specifies the file path where the output files are generated.
        /// </summary>
        [Description("Specifies the file path where the output files are generated.")]
        [DefaultValue(typeof(string), null)]
        public string OutputPath { get; set; }

        /// <summary>
        /// Specifies if sqlpackage.exe should overwrite existing files. Specifying false causes sqlpackage.exe to abort action if an existing file is encountered. Default value is True.
        /// </summary>
        [Description("Specifies if sqlpackage.exe should overwrite existing files. Specifying false causes sqlpackage.exe to abort action if an existing file is encountered. Default value is True.")]
        [DefaultValue(true)]
        public bool OverwriteFiles { get; set; } = true;

        /// <summary>
        /// Specifies whether detailed feedback is suppressed. Defaults to False.
        /// </summary>
        [Description("Specifies whether detailed feedback is suppressed. Defaults to False.")]
        [DefaultValue(false)]
        public bool Quiet { get; set; }

        /// <summary>
        /// Specifies a valid SQL Server/Azure connection string to the target database. If this parameter is specified, it shall be used exclusively of all other target parameters.
        /// </summary>
        [Description("Specifies a valid SQL Server/Azure connection string to the target database. If this parameter is specified, it shall be used exclusively of all other target parameters.")]
        [DefaultValue(typeof(string), null)]
        public string TargetConnectionString { get; set; }

        /// <summary>
        /// Specifies an override for the name of the database that is the target ofsqlpackage.exe Action.
        /// </summary>
        [Description("Specifies an override for the name of the database that is the target ofsqlpackage.exe Action.")]
        [DefaultValue(typeof(string), null)]
        public string TargetDatabaseName { get; set; }

        /// <summary>
        /// Specifies if SQL encryption should be used for the target database connection.
        /// </summary>
        [Description("Specifies if SQL encryption should be used for the target database connection.")]
        [DefaultValue(typeof(bool?), null)]
        public bool? TargetEncryptConnection { get; set; }

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

    }
}
