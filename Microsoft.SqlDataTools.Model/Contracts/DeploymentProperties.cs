﻿using Microsoft.SqlDataTools.Model.Annotation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Xml.Linq;

namespace Microsoft.SqlDataTools.Model
{
    public class DeploymentProperties
    {
        /// <summary>
        /// Specifies additional deployment contributor arguments for the 
        /// deployment contributors. This should be a semi-colon delimited list of values.
        /// </summary>
        [Description("Specifies additional deployment contributor arguments for the " +
            "deployment contributors. This should be a semi-colon delimited list of values.")]
        [DefaultValue(typeof(string), null)]
        [SqlPackageCmdProp]
        public string AdditionalDeploymentContributorArguments { get; set; }

        /// <summary>
        /// Specifies additional deployment contributors, which should run when 
        /// the dacpac is deployed. This should be a semi-colon delimited list 
        /// of fully qualified build contributor names or IDs.
        /// </summary>
        [Description("Specifies additional deployment contributors, which should run when " +
            "the dacpac is deployed. This should be a semi-colon delimited list " +
            "of fully qualified build contributor names or IDs.")]
        [DefaultValue(typeof(string), null)]
        [SqlPackageCmdProp]
        public string AdditionalDeploymentContributors { get; set; }

        /// <summary>
        /// Specifies paths to load additional deployment contributors. 
        /// This should be a semi-colon delimited list of values.
        /// </summary>
        [Description("Specifies paths to load additional deployment contributors. " +
            "This should be a semi-colon delimited list of values.")]
        [DefaultValue(typeof(string), null)]
        [SqlPackageCmdProp]
        public string AdditionalDeploymentContributorPaths { get; set; }

        /// <summary>
        /// This property is used by SqlClr deployment to cause 
        /// any blocking assemblies to be dropped as part of the deployment plan. 
        /// By default, any blocking/referencing assemblies will block 
        /// an assembly update if the referencing assembly needs to be dropped.
        /// </summary>
        [Description("This property is used by SqlClr deployment to cause " +
            "any blocking assemblies to be dropped as part of the deployment plan. " +
            "By default, any blocking/referencing assemblies will block " +
            "an assembly update if the referencing assembly needs to be dropped.")]
        [DefaultValue(typeof(bool?), null)]
        [SqlPackageCmdProp]
        public bool? AllowDropBlockingAssemblies { get; set; }

        /// <summary>
        /// Specifies whether to attempt the action despite incompatible 
        /// SQL Server platforms.
        /// </summary>
        [Description("Specifies whether to attempt the action despite incompatible " +
            "SQL Server platforms.")]
        [DefaultValue(typeof(bool?), null)]
        [SqlPackageCmdProp]
        public bool? AllowIncompatiblePlatform { get; set; }

        /// <summary>
        /// Do not block data motion on a table that has Row Level Security 
        /// if this property is set to true. Default is false.
        /// </summary>
        [Description("Do not block data motion on a table that has Row Level Security " +
            "if this property is set to true. Default is false.")]
        [DefaultValue(false)]
        [SqlPackageCmdProp]
        public bool AllowUnsafeRowLevelSecurityDataMovement { get; set; }

        /// <summary>
        /// Backups the database before deploying any changes.
        /// </summary>
        [Description("Backups the database before deploying any changes.")]
        [DefaultValue(typeof(bool?), null)]
        [SqlPackageCmdProp]
        public bool? BackupDatabaseBeforeChanges { get; set; }

        /// <summary>
        /// Specifies that the publish episode should be terminated 
        /// if there is a possibility of data loss resulting from the publish.operation.
        /// </summary>
        [Description("Specifies that the publish episode should be terminated " +
            "if there is a possibility of data loss resulting from the publish.operation.")]
        [DefaultValue(true)]
        [SqlPackageCmdProp]
        public bool BlockOnPossibleDataLoss { get; set; } = true;

        /// <summary>
        /// Specifies whether to block updating a database whose schema 
        /// no longer matches its registration or is unregistered.
        /// </summary>
        [Description("Specifies whether to block updating a database whose schema " +
            "no longer matches its registration or is unregistered.")]
        [DefaultValue(true)]
        [SqlPackageCmdProp]
        public bool BlockWhenDriftDetected { get; set; } = true;

        /// <summary>
        /// Specifies the command timeout in seconds when executing 
        /// queries against SQL Server.
        /// </summary>
        [Description("Specifies the command timeout in seconds when executing " +
            "queries against SQL Server.")]
        [DefaultValue(60)]
        [SqlPackageCmdProp]
        public int CommandTimeout { get; set; } = 60;

        /// <summary>
        /// Specifies whether the declaration of SETVAR variables should be 
        /// commented out in the generated publish script. You might choose 
        /// to do this if you plan to specify the values on the command line 
        /// when you publish by using a tool such as SQLCMD.EXE.
        /// </summary>
        [Description("Specifies whether the declaration of SETVAR variables should be " +
            "commented out in the generated publish script. You might choose " +
            "to do this if you plan to specify the values on the command line " +
            "when you publish by using a tool such as SQLCMD.EXE.")]
        [DefaultValue(typeof(bool?), null)]
        [SqlPackageCmdProp]
        public bool? CommentOutSetVarDeclarations { get; set; }

        /// <summary>
        /// This setting dictates how the database's collation 
        /// is handled during deployment; by default the target database's 
        /// collation will be updated if it does not match the collation 
        /// specified by the source. When this option is set, the target 
        /// database's (or server's) collation should be used.
        /// </summary>
        [Description("This setting dictates how the database's collation " +
            "is handled during deployment; by default the target database's " +
            "collation will be updated if it does not match the collation " +
            "specified by the source. When this option is set, the target " +
            "database's (or server's) collation should be used.")]
        [DefaultValue(typeof(bool?), null)]
        [SqlPackageCmdProp]
        public bool? CompareUsingTargetCollation { get; set; }

        /// <summary>
        /// Specifies whether the target database should be updated or 
        /// whether it should be dropped and re-created when you publish 
        /// to a database.
        /// </summary>
        [Description("Specifies whether the target database should be updated " +
            "or whether it should be dropped and re-created when you publish " +
            "to a database.")]
        [DefaultValue(typeof(bool?), null)]
        [SqlPackageCmdProp]
        public bool? CreateNewDatabase { get; set; }

        /// <summary>
        /// Defines the edition of an Azure SQL Database.
        /// </summary>
        [Description("Defines the edition of an Azure SQL Database.")]
        [DefaultValue(DatabaseEditionValue.Default)]
        [SqlPackageCmdProp]
        public DatabaseEditionValue DatabaseEdition { get; set; } = 
            DatabaseEditionValue.Default;

        /// <summary>
        /// Specifies the database lock timeout in seconds when 
        /// executing queries against SQLServer. Use -1 to wait indefinitely.
        /// </summary>
        [Description("Specifies the database lock timeout in seconds when " +
            "executing queries against SQLServer. Use -1 to wait indefinitely.")]
        [DefaultValue(60)]
        [SqlPackageCmdProp]
        public int DatabaseLockTimeout { get; set; } = 60;

        /// <summary>
        /// Defines the maximum size in GB of an Azure SQL Database.
        /// </summary>
        [Description("Defines the maximum size in GB of an Azure SQL Database.")]
        [DefaultValue(typeof(int?), null)]
        [SqlPackageCmdProp]
        public int? DatabaseMaximumSize { get; set; }

        /// <summary>
        /// Defines the performance level of an Azure SQL Database 
        /// such as"P0" or "S1".
        /// </summary>
        [Description("Defines the performance level of an Azure SQL Database " +
            "such as\"P0\" or \"S1\".")]
        [DefaultValue(typeof(string), null)]
        [SqlPackageCmdProp]
        public string DatabaseServiceObjective { get; set; }

        /// <summary>
        /// if true, the database is set to Single User Mode 
        /// before deploying.
        /// </summary>
        [Description("if true, the database is set to Single User Mode " +
            "before deploying.")]
        [DefaultValue(typeof(bool?), null)]
        [SqlPackageCmdProp]
        public bool? DeployDatabaseInSingleUserMode { get; set; }

        /// <summary>
        /// Specifies whether Data Definition Language (DDL) triggers 
        /// are disabled at the beginning of the publish process and 
        /// re-enabled at the end of the publish action.
        /// </summary>
        [Description("Specifies whether Data Definition Language (DDL) triggers " +
            "are disabled at the beginning of the publish process and " +
            "re-enabled at the end of the publish action.")]
        [DefaultValue(true)]
        [SqlPackageCmdProp]
        public bool DisableAndReenableDdlTriggers { get; set; } = true;

        /// <summary>
        /// If true, Change Data Capture objects are not altered.
        /// </summary>
        [Description("If true, Change Data Capture objects are not altered.")]
        [DefaultValue(true)]
        [SqlPackageCmdProp]
        public bool DoNotAlterChangeDataCaptureObjects { get; set; } = true;

        /// <summary>
        /// Specifies whether objects that are replicated 
        /// are identified during verification.
        /// </summary>
        [Description("Specifies whether objects that are replicated " +
            "are identified during verification.")]
        [DefaultValue(true)]
        [SqlPackageCmdProp]
        public bool DoNotAlterReplicatedObjects { get; set; } = true;

        /// <summary>
        /// An object type that should not be dropped when 
        /// DropObjectsNotInSource is true. Valid object type names are  
        /// Aggregates, ApplicationRoles, Assemblies, AsymmetricKeys, 
        /// BrokerPriorities, Certificates, ColumnEncryptionKeys, 
        /// ColumnMasterKeys, Contracts, DatabaseRoles, DatabaseTriggers, 
        /// Defaults, ExtendedProperties, ExternalDataSources, ExternalFileFormats, 
        /// ExternalTables, Filegroups, FileTables, FullTextCatalogs, FullTextStoplists, 
        /// MessageTypes, PartitionFunctions, PartitionSchemes, Permissions, Queues, 
        /// RemoteServiceBindings, RoleMembership, Rules, ScalarValuedFunctions, 
        /// SearchPropertyLists, SecurityPolicies, Sequences, Services, Signatures, 
        /// StoredProcedures, SymmetricKeys, Synonyms, Tables, TableValuedFunctions, 
        /// UserDefinedDataTypes, UserDefinedTableTypes, ClrUserDefinedTypes, Users, 
        /// Views, XmlSchemaCollections, Audits, Credentials, CryptographicProviders, 
        /// DatabaseAuditSpecifications, DatabaseScopedCredentials, Endpoints, ErrorMessages, 
        /// EventNotifications, EventSessions, LinkedServerLogins, LinkedServers, Logins, 
        /// Routes, ServerAuditSpecifications, ServerRoleMembership, ServerRoles, ServerTriggers.
        /// </summary>
        [Description("An object type that should not be dropped when " +
            "DropObjectsNotInSource is true. Valid object type names are " +
            "Aggregates, ApplicationRoles, Assemblies, AsymmetricKeys, " +
            "BrokerPriorities, Certificates, ColumnEncryptionKeys, " +
            "ColumnMasterKeys, Contracts, DatabaseRoles, DatabaseTriggers, " +
            "Defaults, ExtendedProperties, ExternalDataSources, ExternalFileFormats, " +
            "ExternalTables, Filegroups, FileTables, FullTextCatalogs, FullTextStoplists, " +
            "MessageTypes, PartitionFunctions, PartitionSchemes, Permissions, Queues, " +
            "RemoteServiceBindings, RoleMembership, Rules, ScalarValuedFunctions, " +
            "SearchPropertyLists, SecurityPolicies, Sequences, Services, Signatures, " +
            "StoredProcedures, SymmetricKeys, Synonyms, Tables, TableValuedFunctions, " +
            "UserDefinedDataTypes, UserDefinedTableTypes, ClrUserDefinedTypes, Users, " +
            "Views, XmlSchemaCollections, Audits, Credentials, CryptographicProviders, " +
            "DatabaseAuditSpecifications, DatabaseScopedCredentials, Endpoints, ErrorMessages, " +
            "EventNotifications, EventSessions, LinkedServerLogins, LinkedServers, Logins, " +
            "Routes, ServerAuditSpecifications, ServerRoleMembership, ServerRoles, ServerTriggers.")]
        [DefaultValue(typeof(string), null)]
        [SqlPackageCmdProp]
        public string DoNotDropObjectType { get; set; }

        /// <summary>
        /// A semicolon-delimited list of object types that should not 
        /// be dropped when DropObjectsNotInSource is true. Valid object 
        /// type names are Aggregates, ApplicationRoles, Assemblies, AsymmetricKeys, 
        /// BrokerPriorities, Certificates, ColumnEncryptionKeys, ColumnMasterKeys, 
        /// Contracts, DatabaseRoles, DatabaseTriggers, Defaults, ExtendedProperties, 
        /// ExternalDataSources, ExternalFileFormats, ExternalTables, Filegroups, 
        /// FileTables, FullTextCatalogs, FullTextStoplists, MessageTypes, 
        /// PartitionFunctions, PartitionSchemes, Permissions, Queues, 
        /// RemoteServiceBindings, RoleMembership, Rules, ScalarValuedFunctions, 
        /// SearchPropertyLists, SecurityPolicies, Sequences, Services, Signatures, 
        /// StoredProcedures, SymmetricKeys, Synonyms, Tables, TableValuedFunctions, 
        /// UserDefinedDataTypes, UserDefinedTableTypes, ClrUserDefinedTypes, Users, 
        /// Views, XmlSchemaCollections, Audits, Credentials, CryptographicProviders, 
        /// DatabaseAuditSpecifications, DatabaseScopedCredentials, Endpoints, 
        /// ErrorMessages, EventNotifications, EventSessions, LinkedServerLogins, 
        /// LinkedServers, Logins, Routes, ServerAuditSpecifications, ServerRoleMembership, 
        /// ServerRoles, ServerTriggers.
        /// </summary>
        [Description("A semicolon-delimited list of object types that should not " +
            "be dropped when DropObjectsNotInSource is true. Valid object type " +
            "names are Aggregates, ApplicationRoles, Assemblies, AsymmetricKeys, " +
            "BrokerPriorities, Certificates, ColumnEncryptionKeys, ColumnMasterKeys, " +
            "Contracts, DatabaseRoles, DatabaseTriggers, Defaults, ExtendedProperties, " +
            "ExternalDataSources, ExternalFileFormats, ExternalTables, Filegroups, " +
            "FileTables, FullTextCatalogs, FullTextStoplists, MessageTypes, " +
            "PartitionFunctions, PartitionSchemes, Permissions, Queues, " +
            "RemoteServiceBindings, RoleMembership, Rules, ScalarValuedFunctions, " +
            "SearchPropertyLists, SecurityPolicies, Sequences, Services, Signatures, " +
            "StoredProcedures, SymmetricKeys, Synonyms, Tables, TableValuedFunctions, " +
            "UserDefinedDataTypes, UserDefinedTableTypes, ClrUserDefinedTypes, Users, " +
            "Views, XmlSchemaCollections, Audits, Credentials, CryptographicProviders, " +
            "DatabaseAuditSpecifications, DatabaseScopedCredentials, Endpoints, " +
            "ErrorMessages, EventNotifications, EventSessions, LinkedServerLogins, " +
            "LinkedServers, Logins, Routes, ServerAuditSpecifications, ServerRoleMembership, " +
            "ServerRoles, ServerTriggers.")]
        [DefaultValue(typeof(string), null)]
        [SqlPackageCmdProp]
        public string DoNotDropObjectTypes { get; set; }

        /// <summary>
        /// Specifies whether constraints that do not exist in the database 
        /// snapshot (.dacpac) file will be dropped from the target database when 
        /// you publish to a database.
        /// </summary>
        [Description("Specifies whether constraints that do not exist in the database " +
            "snapshot (.dacpac) file will be dropped from the target database when " +
            "you publish to a database.")]
        [DefaultValue(true)]
        [SqlPackageCmdProp]
        public bool DropConstraintsNotInSource { get; set; } = true;

        /// <summary>
        /// Specifies whether DML triggers that do not exist in the database 
        /// snapshot (.dacpac) file will be dropped from the target database 
        /// when you publish to a database.
        /// </summary>
        [Description("Specifies whether DML triggers that do not exist in the database " +
            "snapshot (.dacpac) file will be dropped from the target database " +
            "when you publish to a database.")]
        [DefaultValue(true)]
        [SqlPackageCmdProp]
        public bool DropDmlTriggersNotInSource { get; set; } = true;

        /// <summary>
        /// Specifies whether extended properties that do not 
        /// exist in the database snapshot (.dacpac) file will be dropped 
        /// from the target database when you publish to a database.
        /// </summary>
        [Description("Specifies whether extended properties that do not " +
            "exist in the database snapshot (.dacpac) file will be dropped " +
            "from the target database when you publish to a database.")]
        [DefaultValue(true)]
        [SqlPackageCmdProp]
        public bool DropExtendedPropertiesNotInSource { get; set; } = true;

        /// <summary>
        /// Specifies whether indexes that do not exist in 
        /// the database snapshot (.dacpac) file will be dropped 
        /// from the target database when you publish to a database.
        /// </summary>
        [Description("Specifies whether indexes that do not exist in " +
            "the database snapshot (.dacpac) file will be dropped " +
            "from the target database when you publish to a database.")]
        [DefaultValue(true)]
        [SqlPackageCmdProp]
        public bool DropIndexesNotInSource { get; set; } = true;

        /// <summary>
        /// Specifies whether objects that do not exist in 
        /// the database snapshot (.dacpac) file will be dropped 
        /// from the target database when you publish to a database. 
        /// This value takes precedence over DropExtendedProperties.
        /// </summary>
        [Description("Specifies whether objects that do not exist in " +
            "the database snapshot (.dacpac) file will be dropped " +
            "from the target database when you publish to a database. " +
            "This value takes precedence over DropExtendedProperties.")]
        [DefaultValue(typeof(bool?), null)]
        [SqlPackageCmdProp]
        public bool? DropObjectsNotInSource { get; set; }

        /// <summary>
        /// Specifies whether permissions that do not exist in 
        /// the database snapshot (.dacpac) file will be dropped 
        /// from the target database when you publish updates to a database.
        /// </summary>
        [Description("Specifies whether permissions that do not exist " +
            "in the database snapshot (.dacpac) file will be dropped " +
            "from the target database when you publish updates to a database.")]
        [DefaultValue(typeof(bool?), null)]
        [SqlPackageCmdProp]
        public bool? DropPermissionsNotInSource { get; set; }

        /// <summary>
        /// Specifies whether role members that are not defined in 
        /// the database snapshot (.dacpac) file will be dropped from 
        /// the target database when you publish updates to a database.
        /// </summary>
        [Description("Specifies whether role members that are not defined in " +
            "the database snapshot (.dacpac) file will be dropped from " +
            "the target database when you publish updates to a database.")]
        [DefaultValue(typeof(bool?), null)]
        [SqlPackageCmdProp]
        public bool? DropRoleMembersNotInSource { get; set; }

        /// <summary>
        /// Specifies whether statistics that do not exist 
        /// in the database snapshot (.dacpac) file will be dropped 
        /// from the target database when you publish to a database.
        /// </summary>
        [Description("Specifies whether statistics that do not exist " +
            "in the database snapshot (.dacpac) file will be dropped " +
            "from the target database when you publish to a database.")]
        [DefaultValue(true)]
        [SqlPackageCmdProp]
        public bool DropStatisticsNotInSource { get; set; } = true;

        /// <summary>
        /// An object type that should be ignored during deployment. 
        /// Valid object type names are Aggregates, ApplicationRoles, Assemblies, 
        /// AsymmetricKeys, BrokerPriorities, Certificates, ColumnEncryptionKeys, 
        /// ColumnMasterKeys, Contracts, DatabaseRoles, DatabaseTriggers, Defaults, 
        /// ExtendedProperties, ExternalDataSources, ExternalFileFormats, 
        /// ExternalTables, Filegroups, FileTables, FullTextCatalogs, 
        /// FullTextStoplists, MessageTypes, PartitionFunctions, PartitionSchemes, 
        /// Permissions, Queues, RemoteServiceBindings, RoleMembership, Rules, 
        /// ScalarValuedFunctions, SearchPropertyLists, SecurityPolicies, Sequences, 
        /// Services, Signatures, StoredProcedures, SymmetricKeys, Synonyms, Tables, 
        /// TableValuedFunctions, UserDefinedDataTypes, UserDefinedTableTypes, 
        /// ClrUserDefinedTypes, Users, Views, XmlSchemaCollections, Audits, 
        /// Credentials, CryptographicProviders, DatabaseAuditSpecifications, 
        /// DatabaseScopedCredentials, Endpoints, ErrorMessages, EventNotifications, 
        /// EventSessions, LinkedServerLogins, LinkedServers, Logins, Routes, 
        /// ServerAuditSpecifications, ServerRoleMembership, ServerRoles, ServerTriggers.
        /// </summary>
        [Description("An object type that should be ignored during deployment. " +
            "Valid object type names are Aggregates, ApplicationRoles, Assemblies, " +
            "AsymmetricKeys, BrokerPriorities, Certificates, ColumnEncryptionKeys, " +
            "ColumnMasterKeys, Contracts, DatabaseRoles, DatabaseTriggers, Defaults, " +
            "ExtendedProperties, ExternalDataSources, ExternalFileFormats, " +
            "ExternalTables, Filegroups, FileTables, FullTextCatalogs, " +
            "FullTextStoplists, MessageTypes, PartitionFunctions, PartitionSchemes, " +
            "Permissions, Queues, RemoteServiceBindings, RoleMembership, Rules, " +
            "ScalarValuedFunctions, SearchPropertyLists, SecurityPolicies, Sequences, " +
            "Services, Signatures, StoredProcedures, SymmetricKeys, Synonyms, Tables, " +
            "TableValuedFunctions, UserDefinedDataTypes, UserDefinedTableTypes, " +
            "ClrUserDefinedTypes, Users, Views, XmlSchemaCollections, Audits, " +
            "Credentials, CryptographicProviders, DatabaseAuditSpecifications, " +
            "DatabaseScopedCredentials, Endpoints, ErrorMessages, EventNotifications, " +
            "EventSessions, LinkedServerLogins, LinkedServers, Logins, Routes, " +
            "ServerAuditSpecifications, ServerRoleMembership, ServerRoles, ServerTriggers.")]
        [DefaultValue(typeof(string), null)]
        [SqlPackageCmdProp]
        public string ExcludeObjectType { get; set; }

        /// <summary>
        /// A semicolon-delimited list of object types that should 
        /// be ignored during deployment. Valid object type names are Aggregates, 
        /// ApplicationRoles, Assemblies, AsymmetricKeys, BrokerPriorities, 
        /// Certificates, ColumnEncryptionKeys, ColumnMasterKeys, Contracts, 
        /// DatabaseRoles, DatabaseTriggers, Defaults, ExtendedProperties, 
        /// ExternalDataSources, ExternalFileFormats, ExternalTables, Filegroups, 
        /// FileTables, FullTextCatalogs, FullTextStoplists, MessageTypes, 
        /// PartitionFunctions, PartitionSchemes, Permissions, Queues, 
        /// RemoteServiceBindings, RoleMembership, Rules, ScalarValuedFunctions, 
        /// SearchPropertyLists, SecurityPolicies, Sequences, Services, Signatures, 
        /// StoredProcedures, SymmetricKeys, Synonyms, Tables, TableValuedFunctions, 
        /// UserDefinedDataTypes, UserDefinedTableTypes, ClrUserDefinedTypes, Users, 
        /// Views, XmlSchemaCollections, Audits, Credentials, CryptographicProviders, 
        /// DatabaseAuditSpecifications, DatabaseScopedCredentials, Endpoints, ErrorMessages, 
        /// EventNotifications, EventSessions, LinkedServerLogins, LinkedServers, Logins, 
        /// Routes, ServerAuditSpecifications, ServerRoleMembership, ServerRoles, ServerTriggers.
        /// </summary>
        [Description("A semicolon-delimited list of object types that should " +
            "be ignored during deployment. Valid object type names are Aggregates, " +
            "ApplicationRoles, Assemblies, AsymmetricKeys, BrokerPriorities, " +
            "Certificates, ColumnEncryptionKeys, ColumnMasterKeys, Contracts, " +
            "DatabaseRoles, DatabaseTriggers, Defaults, ExtendedProperties, " +
            "ExternalDataSources, ExternalFileFormats, ExternalTables, Filegroups, " +
            "FileTables, FullTextCatalogs, FullTextStoplists, MessageTypes, " +
            "PartitionFunctions, PartitionSchemes, Permissions, Queues, " +
            "RemoteServiceBindings, RoleMembership, Rules, ScalarValuedFunctions, " +
            "SearchPropertyLists, SecurityPolicies, Sequences, Services, Signatures, " +
            "StoredProcedures, SymmetricKeys, Synonyms, Tables, TableValuedFunctions, " +
            "UserDefinedDataTypes, UserDefinedTableTypes, ClrUserDefinedTypes, Users, " +
            "Views, XmlSchemaCollections, Audits, Credentials, CryptographicProviders, " +
            "DatabaseAuditSpecifications, DatabaseScopedCredentials, Endpoints, ErrorMessages, " +
            "EventNotifications, EventSessions, LinkedServerLogins, LinkedServers, Logins, " +
            "Routes, ServerAuditSpecifications, ServerRoleMembership, ServerRoles, ServerTriggers.")]
        [DefaultValue(typeof(string), null)]
        [SqlPackageCmdProp]
        public string ExcludeObjectTypes { get; set; }

        /// <summary>
        /// Automatically provides a default value when updating 
        /// a table that contains data with a column that does not allow null values.
        /// </summary>
        [Description("Automatically provides a default value when updating " +
            "a table that contains data with a column that does not allow null values.")]
        [DefaultValue(typeof(bool?), null)]
        [SqlPackageCmdProp]
        public bool? GenerateSmartDefaults { get; set; }

        /// <summary>
        /// Specifies whether differences in the ANSI NULLS setting 
        /// should be ignored or updated when you publish to a database.
        /// </summary>
        [Description("Specifies whether differences in the ANSI NULLS setting " +
            "should be ignored or updated when you publish to a database.")]
        [DefaultValue(true)]
        [SqlPackageCmdProp]
        public bool IgnoreAnsiNulls { get; set; } = true;

        /// <summary>
        /// Specifies whether differences in the Authorizer should 
        /// be ignored or updated when you publish to a database.
        /// </summary>
        [Description("Specifies whether differences in the Authorizer should " +
            "be ignored or updated when you publish to a database.")]
        [DefaultValue(typeof(bool?), null)]
        [SqlPackageCmdProp]
        public bool? IgnoreAuthorizer { get; set; }

        /// <summary>
        /// Specifies whether differences in the column collations should 
        /// be ignored or updated when you publish to a database.
        /// </summary>
        [Description("Specifies whether differences in the column collations should " +
            "be ignored or updated when you publish to a database.")]
        [DefaultValue(typeof(bool?), null)]
        [SqlPackageCmdProp]
        public bool? IgnoreColumnCollation { get; set; }

        /// <summary>
        /// Specifies whether differences in table column order 
        /// should be ignored or updated when you publish to a database.
        /// </summary>
        [Description("Specifies whether differences in table column order " +
            "should be ignored or updated when you publish to a database.")]
        [DefaultValue(typeof(bool?), null)]
        [SqlPackageCmdProp]
        public bool? IgnoreColumnOrder { get; set; }

        /// <summary>
        /// Specifies whether differences in the comments should 
        /// be ignored or updated when you publish to a database.
        /// </summary>
        [Description("Specifies whether differences in the comments should " +
            "be ignored or updated when you publish to a database.")]
        [DefaultValue(typeof(bool?), null)]
        [SqlPackageCmdProp]
        public bool? IgnoreComments { get; set; }

        /// <summary>
        /// Specifies whether differences in the file path for 
        /// the cryptographic provider should be ignored or updated 
        /// when you publish to a database.
        /// </summary>
        [Description("Specifies whether differences in the file path for " +
            "the cryptographic provider should be ignored or updated " +
            "when you publish to a database.")]
        [DefaultValue(true)]
        [SqlPackageCmdProp]
        public bool IgnoreCryptographicProviderFilePath { get; set; } = true;

        /// <summary>
        /// Specifies whether differences in the order of 
        /// Data Definition Language (DDL) triggers should be ignored 
        /// or updated when you publish to a database or server.
        /// </summary>
        [Description("Specifies whether differences in the order of " +
            "Data Definition Language (DDL) triggers should be ignored " +
            "or updated when you publish to a database or server.")]
        [DefaultValue(typeof(bool?), null)]
        [SqlPackageCmdProp]
        public bool? IgnoreDdlTriggerOrder { get; set; }

        /// <summary>
        /// Specifies whether differences in the enabled or 
        /// disabled state of Data Definition Language (DDL) triggers 
        /// should be ignored or updated when you publish to a database.
        /// </summary>
        [Description("Specifies whether differences in the enabled or " +
            "disabled state of Data Definition Language (DDL) triggers " +
            "should be ignored or updated when you publish to a database.")]
        [DefaultValue(typeof(bool?), null)]
        [SqlPackageCmdProp]
        public bool? IgnoreDdlTriggerState { get; set; }

        /// <summary>
        /// Specifies whether differences in the default schema 
        /// should be ignored or updated when you publish to a database.
        /// </summary>
        [Description("Specifies whether differences in the default schema " +
            "should be ignored or updated when you publish to a database.")]
        [DefaultValue(typeof(bool?), null)]
        [SqlPackageCmdProp]
        public bool? IgnoreDefaultSchema { get; set; }

        /// <summary>
        /// Specifies whether differences in the order of 
        /// Data Manipulation Language (DML) triggers should be 
        /// ignored or updated when you publish to a database.
        /// </summary>
        [Description("Specifies whether differences in the order of " +
            "Data Manipulation Language (DML) triggers should be " +
            "ignored or updated when you publish to a database.")]
        [DefaultValue(typeof(bool?), null)]
        [SqlPackageCmdProp]
        public bool? IgnoreDmlTriggerOrder { get; set; }

        /// <summary>
        /// Specifies whether differences in the enabled or 
        /// disabled state of DML triggers should be ignored or 
        /// updated when you publish to a database.
        /// </summary>
        [Description("Specifies whether differences in the enabled or " +
            "disabled state of DML triggers should be ignored or " +
            "updated when you publish to a database.")]
        [DefaultValue(typeof(bool?), null)]
        [SqlPackageCmdProp]
        public bool? IgnoreDmlTriggerState { get; set; }

        /// <summary>
        /// Specifies whether differences in the extended 
        /// properties should be ignored or updated when you publish to a database.
        /// </summary>
        [Description("Specifies whether differences in the extended " +
            "properties should be ignored or updated when you publish to a database.")]
        [DefaultValue(typeof(bool?), null)]
        [SqlPackageCmdProp]
        public bool? IgnoreExtendedProperties { get; set; }

        /// <summary>
        /// Specifies whether differences in the paths for 
        /// files and log files should be ignored or updated 
        /// when you publish to a database.
        /// </summary>
        [Description("Specifies whether differences in the paths for " +
            "files and log files should be ignored or updated " +
            "when you publish to a database.")]
        [DefaultValue(true)]
        [SqlPackageCmdProp]
        public bool IgnoreFileAndLogFilePath { get; set; } = true;

        /// <summary>
        /// Specifies whether differences in the placement 
        /// of objects in FILEGROUPs should be ignored or updated 
        /// when you publish to a database.
        /// </summary>
        [Description("Specifies whether differences in the placement " +
            "of objects in FILEGROUPs should be ignored or updated " +
            "when you publish to a database.")]
        [DefaultValue(true)]
        [SqlPackageCmdProp]
        public bool IgnoreFilegroupPlacement { get; set; } = true;

        /// <summary>
        /// Specifies whether differences in the file sizes 
        /// should be ignored or whether a warning should be issued 
        /// when you publish to a database.
        /// </summary>
        [Description("Specifies whether differences in the file sizes " +
            "should be ignored or whether a warning should be issued " +
            "when you publish to a database.")]
        [DefaultValue(true)]
        [SqlPackageCmdProp]
        public bool IgnoreFileSize { get; set; } = true;

        /// <summary>
        /// Specifies whether differences in the fill factor 
        /// for index storage should be ignored or whether a warning 
        /// should be issued when you publish to a database.
        /// </summary>
        [Description("Specifies whether differences in the fill factor " +
            "for index storage should be ignored or whether a warning " +
            "should be issued when you publish to a database.")]
        [DefaultValue(true)]
        [SqlPackageCmdProp]
        public bool IgnoreFillFactor { get; set; } = true;

        /// <summary>
        /// Specifies whether differences in the file path 
        /// for the full-text catalog should be ignored or whether 
        /// a warning should be issued when you publish to a database.
        /// </summary>
        [Description("Specifies whether differences in the file path " +
            "for the full-text catalog should be ignored or whether " +
            "a warning should be issued when you publish to a database.")]
        [DefaultValue(true)]
        [SqlPackageCmdProp]
        public bool IgnoreFullTextCatalogFilePath { get; set; } = true;

        /// <summary>
        /// Specifies whether differences in the seed for 
        /// an identity column should be ignored or updated 
        /// when you publish updates to a database.
        /// </summary>
        [Description("Specifies whether differences in the seed for " +
            "an identity column should be ignored or updated " +
            "when you publish updates to a database.")]
        [DefaultValue(typeof(bool?), null)]
        [SqlPackageCmdProp]
        public bool? IgnoreIdentitySeed { get; set; }

        /// <summary>
        /// Specifies whether differences in the increment for 
        /// an identity column should be ignored or updated 
        /// when you publish to a database.
        /// </summary>
        [Description("Specifies whether differences in the increment for " +
            "an identity column should be ignored or updated " +
            "when you publish to a database.")]
        [DefaultValue(typeof(bool?), null)]
        [SqlPackageCmdProp]
        public bool? IgnoreIncrement { get; set; }

        /// <summary>
        /// Specifies whether differences in the index options 
        /// should be ignored or updated when you publish to a database.
        /// </summary>
        [Description("Specifies whether differences in the index options " +
            "should be ignored or updated when you publish to a database.")]
        [DefaultValue(typeof(bool?), null)]
        [SqlPackageCmdProp]
        public bool? IgnoreIndexOptions { get; set; }

        /// <summary>
        /// Specifies whether differences in the index padding 
        /// should be ignored or updated when you publish to a database.
        /// </summary>
        [Description("Specifies whether differences in the index padding " +
            "should be ignored or updated when you publish to a database.")]
        [DefaultValue(true)]
        [SqlPackageCmdProp]
        public bool IgnoreIndexPadding { get; set; } = true;

        /// <summary>
        /// Specifies whether differences in the casing of keywords 
        /// should be ignored or updated when you publish to a database.
        /// </summary>
        [Description("Specifies whether differences in the casing of keywords " +
            "should be ignored or updated when you publish to a database.")]
        [DefaultValue(true)]
        [SqlPackageCmdProp]
        public bool IgnoreKeywordCasing { get; set; } = true;

        /// <summary>
        /// Specifies whether differences in the lock hints on indexes 
        /// should be ignored or updated when you publish to a database.
        /// </summary>
        [Description("Specifies whether differences in the lock hints on indexes " +
            "should be ignored or updated when you publish to a database.")]
        [DefaultValue(typeof(bool?), null)]
        [SqlPackageCmdProp]
        public bool? IgnoreLockHintsOnIndexes { get; set; }

        /// <summary>
        /// Specifies whether differences in the security identification 
        /// number (SID) should be ignored or updated when you publish to a database.
        /// </summary>
        [Description("Specifies whether differences in the security identification " +
            "number (SID) should be ignored or updated when you publish to a database.")]
        [DefaultValue(true)]
        [SqlPackageCmdProp]
        public bool IgnoreLoginSids { get; set; } = true;

        /// <summary>
        /// Specifies whether the not for replication settings should be ignored 
        /// or updated when you publish to a database.
        /// </summary>
        [Description("Specifies whether the not for replication settings should be ignored " +
            "or updated when you publish to a database.")]
        [DefaultValue(typeof(bool?), null)]
        [SqlPackageCmdProp]
        public bool? IgnoreNotForReplication { get; set; }

        /// <summary>
        /// Specifies whether an object's placement on a partition scheme should be 
        /// ignored or updated when you publish to a database.
        /// </summary>
        [Description("Specifies whether an object's placement on a partition scheme should be " +
            "ignored or updated when you publish to a database.")]
        [DefaultValue(true)]
        [SqlPackageCmdProp]
        public bool IgnoreObjectPlacementOnPartitionScheme { get; set; } = true;

        /// <summary>
        /// Specifies whether differences in partition schemes and functions should be 
        /// ignored or updated when you publish to a database.
        /// </summary>
        [Description("Specifies whether differences in partition schemes and functions should be " +
            "ignored or updated when you publish to a database.")]
        [DefaultValue(typeof(bool?), null)]
        [SqlPackageCmdProp]
        public bool? IgnorePartitionSchemes { get; set; }

        /// <summary>
        /// Specifies whether differences in the permissions should be 
        /// ignored or updated when you publish to a database.
        /// </summary>
        [Description("Specifies whether differences in the permissions should be " +
            "ignored or updated when you publish to a database.")]
        [DefaultValue(typeof(bool?), null)]
        [SqlPackageCmdProp]
        public bool? IgnorePermissions { get; set; }

        /// <summary>
        /// Specifies whether differences in the quoted identifiers setting should be 
        /// ignored or updated when you publish to a database.
        /// </summary>
        [Description("Specifies whether differences in the quoted identifiers setting should be " +
            "ignored or updated when you publish to a database.")]
        [DefaultValue(true)]
        [SqlPackageCmdProp]
        public bool IgnoreQuotedIdentifiers { get; set; } = true;

        /// <summary>
        /// Specifies whether differences in the role membership of logins should be 
        /// ignored or updated when you publish to a database.
        /// </summary>
        [Description("Specifies whether differences in the role membership of logins should be " +
            "ignored or updated when you publish to a database.")]
        [DefaultValue(typeof(bool?), null)]
        [SqlPackageCmdProp]
        public bool? IgnoreRoleMembership { get; set; }

        /// <summary>
        /// Specifies whether differences in the amount of time that 
        /// SQL Server retains the route in the routing table should be 
        /// ignored or updated when you publish to a database.
        /// </summary>
        [Description("Specifies whether differences in the amount of time that " +
            "SQL Server retains the route in the routing table should be " +
            "ignored or updated when you publish to a database.")]
        [DefaultValue(true)]
        [SqlPackageCmdProp]
        public bool IgnoreRouteLifetime { get; set; } = true;

        /// <summary>
        /// Specifies whether differences in the semi-colons between 
        /// T-SQL statements will be ignored or updated when you publish to a database.
        /// </summary>
        [Description("Specifies whether differences in the semi-colons between " +
            "T-SQL statements will be ignored or updated when you publish to a database.")]
        [DefaultValue(true)]
        [SqlPackageCmdProp]
        public bool IgnoreSemicolonBetweenStatements { get; set; } = true;

        /// <summary>
        /// Specifies whether differences in the table options will be 
        /// ignored or updated when you publish to a database.
        /// </summary>
        [Description("Specifies whether differences in the table options will be " +
            "ignored or updated when you publish to a database.")]
        [DefaultValue(typeof(bool?), null)]
        [SqlPackageCmdProp]
        public bool? IgnoreTableOptions { get; set; }

        /// <summary>
        /// Specifies whether differences in the table partition options will be 
        /// ignored or updated when you publish to a database. This option applies only to Azure Synapse Analytics SQL pool (data warehouse) databases.
        /// </summary>
        [Description("Specifies whether differences in the table partition options will be " +
            "ignored or updated when you publish to a database. This option applies only to Azure Synapse Analytics SQL pool (data warehouse) databases.")]
        [DefaultValue(typeof(bool?), null)]
        [SqlPackageCmdProp]
        public bool? IgnoreTablePartitionOptions { get; set; }

        /// <summary>
        /// Specifies whether differences in the user settings objects will be 
        /// ignored or updated when you publish to a database.
        /// </summary>
        [Description("Specifies whether differences in the user settings objects will be " +
            "ignored or updated when you publish to a database.")]
        [DefaultValue(typeof(bool?), null)]
        [SqlPackageCmdProp]
        public bool? IgnoreUserSettingsObjects { get; set; }

        /// <summary>
        /// Specifies whether differences in white space will be 
        /// ignored or updated when you publish to a database.
        /// </summary>
        [Description("Specifies whether differences in white space will be " +
            "ignored or updated when you publish to a database.")]
        [DefaultValue(true)]
        [SqlPackageCmdProp]
        public bool IgnoreWhitespace { get; set; } = true;

        /// <summary>
        /// Specifies whether differences in the value of the WITH NOCHECK clause 
        /// for check constraints will be ignored or updated when you publish.
        /// </summary>
        [Description("Specifies whether differences in the value of the WITH NOCHECK clause " +
            "for check constraints will be ignored or updated when you publish.")]
        [DefaultValue(typeof(bool?), null)]
        [SqlPackageCmdProp]
        public bool? IgnoreWithNocheckOnCheckConstraints { get; set; }

        /// <summary>
        /// Specifies whether differences in the value of the WITH NOCHECK clause 
        /// for foreign keys will be ignored or updated when you publish to a database.
        /// </summary>
        [Description("Specifies whether differences in the value of the WITH NOCHECK clause " +
            "for foreign keys will be ignored or updated when you publish to a database.")]
        [DefaultValue(typeof(bool?), null)]
        [SqlPackageCmdProp]
        public bool? IgnoreWithNocheckOnForeignKeys { get; set; }

        /// <summary>
        /// Include all composite elements as part of a single publish operation.
        /// </summary>
        [Description("Include all composite elements as part of a single publish operation.")]
        [DefaultValue(typeof(bool?), null)]
        [SqlPackageCmdProp]
        public bool? IncludeCompositeObjects { get; set; }

        /// <summary>
        /// Specifies whether transactional statements should be used 
        /// where possible when you publish to a database.
        /// </summary>
        [Description("Specifies whether transactional statements should be used " +
            "where possible when you publish to a database.")]
        [DefaultValue(typeof(bool?), null)]
        [SqlPackageCmdProp]
        public bool? IncludeTransactionalScripts { get; set; }

        /// <summary>
        /// Specifies the long running command timeout in seconds when e
        /// xecuting queries against SQL Server. Use 0 to wait indefinitely.
        /// </summary>
        [Description("Specifies the long running command timeout in seconds when " +
            "executing queries against SQL Server. Use 0 to wait indefinitely.")]
        [DefaultValue(typeof(int?), null)]
        [SqlPackageCmdProp]
        public int? LongRunningCommandTimeout { get; set; }

        /// <summary>
        /// Specifies that publish should always drop and re-create an 
        /// assembly if there is a difference instead of issuing an ALTER ASSEMBLY statement.
        /// </summary>
        [Description("Specifies that publish should always drop and re-create an " +
            "assembly if there is a difference instead of issuing an ALTER ASSEMBLY statement.")]
        [DefaultValue(typeof(bool?), null)]
        [SqlPackageCmdProp]
        public bool? NoAlterStatementsToChangeClrTypes { get; set; }

        /// <summary>
        /// Specifies whether a new file is also created when a new 
        /// FileGroup is created in the target database.
        /// </summary>
        [Description("Specifies whether a new file is also created when a new " +
            "FileGroup is created in the target database.")]
        [DefaultValue(true)]
        [SqlPackageCmdProp]
        public bool PopulateFilesOnFileGroups { get; set; } = true;

        /// <summary>
        /// Specifies whether the schema is registered with the database server.
        /// </summary>
        [Description("Specifies whether the schema is registered with the database server.")]
        [DefaultValue(typeof(bool?), null)]
        [SqlPackageCmdProp]
        public bool? RegisterDataTierApplication { get; set; }

        /// <summary>
        /// Specifies whether DeploymentPlanExecutor contributors 
        /// should be run when other operations are executed.
        /// </summary>
        [Description("Specifies whether DeploymentPlanExecutor contributors " +
            "should be run when other operations are executed.")]
        [DefaultValue(typeof(bool?), null)]
        [SqlPackageCmdProp]
        public bool? RunDeploymentPlanExecutors { get; set; }

        /// <summary>
        /// Specifies whether differences in the database 
        /// collation should be ignored or updated when you publish to a database.
        /// </summary>
        [Description("Specifies whether differences in the database " +
            "collation should be ignored or updated when you publish to a database.")]
        [DefaultValue(typeof(bool?), null)]
        [SqlPackageCmdProp]
        public bool? ScriptDatabaseCollation { get; set; }

        /// <summary>
        /// Specifies whether differences in the database 
        /// compatibility should be ignored or updated when 
        /// you publish to a database.
        /// </summary>
        [Description("Specifies whether differences in the database " +
            "compatibility should be ignored or updated when " +
            "you publish to a database.")]
        [DefaultValue(typeof(bool?), null)]
        [SqlPackageCmdProp]
        public bool? ScriptDatabaseCompatibility { get; set; }

        /// <summary>
        /// Specifies whether target database properties should 
        /// be set or updated as part of the publish action.
        /// </summary>
        [Description("Specifies whether target database properties should " +
            "be set or updated as part of the publish action.")]
        [DefaultValue(true)]
        [SqlPackageCmdProp]
        public bool ScriptDatabaseOptions { get; set; } = true;

        /// <summary>
        /// Specifies whether statements are generated in 
        /// the publish script to verify that the database name 
        /// and server name match the names specified in the database project.
        /// </summary>
        [Description("Specifies whether statements are generated in " +
            "the publish script to verify that the database name " +
            "and server name match the names specified in the database project.")]
        [DefaultValue(typeof(bool?), null)]
        [SqlPackageCmdProp]
        public bool? ScriptDeployStateChecks { get; set; }

        /// <summary>
        /// Controls whether size is specified when adding a file to a filegroup.
        /// </summary>
        [Description("Controls whether size is specified when adding a file to a filegroup.")]
        [DefaultValue(typeof(bool?), null)]
        [SqlPackageCmdProp]
        public bool? ScriptFileSize { get; set; }

        /// <summary>
        /// At the end of publish all of the constraints 
        /// will be verified as one set, avoiding data errors 
        /// caused by a check or foreign key constraint in the middle 
        /// of publish. If set to False, your constraints are published 
        /// without checking the corresponding data.
        /// </summary>
        [Description("At the end of publish all of the constraints " +
            "will be verified as one set, avoiding data errors " +
            "caused by a check or foreign key constraint in the middle " +
            "of publish. If set to False, your constraints are published " +
            "without checking the corresponding data.")]
        [DefaultValue(true)]
        [SqlPackageCmdProp]
        public bool ScriptNewConstraintValidation { get; set; } = true;

        /// <summary>
        /// Include refresh statements at the end of the publish script.
        /// </summary>
        [Description("Include refresh statements at the end of the publish script.")]
        [DefaultValue(true)]
        [SqlPackageCmdProp]
        public bool ScriptRefreshModule { get; set; } = true;

        /// <summary>
        /// Specifies how elements are stored when building 
        /// the database model. For performance reasons the default is InMemory. 
        /// For large databases, File backed storage is required.
        /// </summary>
        [Description("Specifies how elements are stored when building " +
            "the database model. For performance reasons the default is InMemory. " +
            "For large databases, File backed storage is required.")]
        [DefaultValue(StorageValue.Memory)]
        [SqlPackageCmdProp]
        public StorageValue Storage { get; set; } = StorageValue.Memory;

        /// <summary>
        /// Specifies whether errors encountered during publish 
        /// verification should be treated as warnings. The check is performed 
        /// against the generated deployment plan before the plan is executed 
        /// against your target database. Plan verification detects problems 
        /// such as the loss of target-only objects (such as indexes) that must 
        /// be dropped to make a change. Verification will also detect situations 
        /// where dependencies (such as a table or view) exist because of a reference 
        /// to a composite project, but do not exist in the target database. You might 
        /// choose to do this to get a complete list of all issues, instead of having 
        /// the publish action stop on the first error.
        /// </summary>
        [Description("Specifies whether errors encountered during publish " +
            "verification should be treated as warnings. The check is performed " +
            "against the generated deployment plan before the plan is executed " +
            "against your target database. Plan verification detects problems " +
            "such as the loss of target-only objects (such as indexes) that must " +
            "be dropped to make a change. Verification will also detect situations " +
            "where dependencies (such as a table or view) exist because of a reference " +
            "to a composite project, but do not exist in the target database. You might " +
            "choose to do this to get a complete list of all issues, instead of having " +
            "the publish action stop on the first error.")]
        [DefaultValue(typeof(bool?), null)]
        [SqlPackageCmdProp]
        public bool? TreatVerificationErrorsAsWarnings { get; set; }

        /// <summary>
        /// Specifies whether warnings should be generated 
        /// when differences are found in objects that cannot be modified, 
        /// for example, if the file size or file paths were different for a file.
        /// </summary>
        [Description("Specifies whether warnings should be generated " +
            "when differences are found in objects that cannot be modified, " +
            "for example, if the file size or file paths were different for a file.")]
        [DefaultValue(true)]
        [SqlPackageCmdProp]
        public bool UnmodifiableObjectWarnings { get; set; } = true;

        /// <summary>
        /// Specifies whether collation compatibility is verified.
        /// </summary>
        [Description("Specifies whether collation compatibility is verified.")]
        [DefaultValue(true)]
        [SqlPackageCmdProp]
        public bool VerifyCollationCompatibility { get; set; } = true;

        /// <summary>
        /// Specifies whether checks should be performed 
        /// before publishing that will stop the publish action 
        /// if issues are present that might block successful publishing. 
        /// For example, your publish action might stop if you have 
        /// foreign keys on the target database that do not exist in 
        /// the database project, and that causes errors when you publish.
        /// </summary>
        [Description("Specifies whether checks should be performed " +
            "before publishing that will stop the publish action " +
            "if issues are present that might block successful publishing. " +
            "For example, your publish action might stop if you have " +
            "foreign keys on the target database that do not exist in " +
            "the database project, and that causes errors when you publish.")]
        [DefaultValue(true)]
        [SqlPackageCmdProp]
        public bool VerifyDeployment { get; set; } = true;

    }
}
