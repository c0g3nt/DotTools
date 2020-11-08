using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
namespace Microsoft.SqlDataTools.Model
{
    public struct DeployReportProperties : ISqlPackageProperties
    {
        #region BackingFields

        private bool? allowDropBlockingAssemblies;
        private bool? allowIncompatiblePlatform;
        private bool? allowUnsafeRowLevelSecurityDataMovement;
        private bool? blockOnPossibleDataLoss;
        private bool? blockWhenDriftDetected;
        private int? commandTimeout;
        private bool? commentOutSetVarDeclarations;
        private bool? compareUsingTargetCollation;
        private bool? createNewDatabase;
        private bool? deployDatabaseInSingleUserMode;
        private bool? dropObjectsNotInSource;
        private bool? dropPermissionsNotInSource;
        private bool? dropRoleMembersNotInSource;
        private DatabaseEditionValue? databaseEdition;
        private int? databaseLockTimeout;
        private bool? disableAndReenableDdlTriggers;
        private bool? doNotAlterChangeDataCaptureObjects;
        private bool? doNotAlterReplicatedObjects;
        private bool? dropConstraintsNotInSource;
        private bool? dropDmlTriggersNotInSource;
        private bool? dropExtendedPropertiesNotInSource;
        private bool? dropIndexesNotInSource;
        private bool? dropStatisticsNotInSource;
        private bool? generateSmartDefaults;
        private bool? ignoreAnsiNulls;
        private bool? ignoreCryptographicProviderFilePath;
        private bool? ignoreFileAndLogFilePath;
        private bool? ignoreFilegroupPlacement;
        private bool? ignoreFileSize;
        private bool? ignoreFillFactor;
        private bool? ignoreFullTextCatalogFilePath;
        private bool? ignoreIndexPadding;
        private bool? ignoreKeywordCasing;
        private bool? ignoreLoginSids;
        private bool? ignoreObjectPlacementOnPartitionScheme;
        private bool? ignoreQuotedIdentifiers;
        private bool? ignoreRouteLifetime;
        private bool? ignoreSemicolonBetweenStatements;
        private bool? ignoreWhitespace;
        private bool? ignoreAuthorizer;
        private bool? ignoreColumnCollation;
        private bool? ignoreColumnOrder;
        private bool? ignoreComments;
        private bool? ignoreDdlTriggerOrder;
        private bool? ignoreDdlTriggerState;
        private bool? ignoreDefaultSchema;
        private bool? ignoreDmlTriggerOrder;
        private bool? ignoreDmlTriggerState;
        private bool? ignoreExtendedProperties;
        private bool? ignoreIdentitySeed;
        private bool? ignoreIncrement;
        private bool? ignoreIndexOptions;
        private bool? ignoreLockHintsOnIndexes;
        private bool? ignoreNotForReplication;
        private bool? ignorePartitionSchemes;
        private bool? ignorePermissions;
        private bool? ignoreRoleMembership;
        private bool? ignoreTableOptions;
        private bool? ignoreTablePartitionOptions;
        private bool? ignoreUserSettingsObjects;
        private bool? ignoreWithNocheckOnCheckConstraints;
        private bool? ignoreWithNocheckOnForeignKeys;
        private bool? includeCompositeObjects;
        private bool? includeTransactionalScripts;
        private int? longRunningCommandTimeout;
        private bool? noAlterStatementsToChangeClrTypes;
        private bool? populateFilesOnFileGroups;
        private bool? scriptDatabaseOptions;
        private bool? scriptNewConstraintValidation;
        private bool? scriptRefreshModule;
        private StorageValue? storage;
        private bool? registerDataTierApplication;
        private bool? runDeploymentPlanExecutors;
        private bool? scriptDatabaseCollation;
        private bool? scriptDatabaseCompatibility;
        private bool? scriptDeployStateChecks;
        private bool? scriptFileSize;
        private bool? treatVerificationErrorsAsWarnings;
        private bool? unmodifiableObjectWarnings;
        private bool? verifyCollationCompatibility;
        private bool? verifyDeployment;
        #endregion

        /// <summary>
        /// Specifies additional deployment contributor arguments for the deployment contributors. This should be a semi-colon delimited list of values.
        /// </summary>
        [Description("Specifies additional deployment contributor arguments for the deployment contributors. This should be a semi-colon delimited list of values.")]
        [DefaultValue(typeof(string), null)]
        public string AdditionalDeploymentContributorArguments { get; set; }

        /// <summary>
        /// Specifies additional deployment contributors, which should run when the dacpac is deployed. This should be a semi-colon delimited list of fully qualified build contributor names or IDs.
        /// </summary>
        [Description("Specifies additional deployment contributors, which should run when the dacpac is deployed. This should be a semi-colon delimited list of fully qualified build contributor names or IDs.")]
        [DefaultValue(typeof(string), null)]
        public string AdditionalDeploymentContributors { get; set; }

        /// <summary>
        /// Specifies paths to load additional deployment contributors. This should be a semi-colon delimited list of values.
        /// </summary>
        [Description("Specifies paths to load additional deployment contributors. This should be a semi-colon delimited list of values.")]
        [DefaultValue(typeof(string), null)]
        public string AdditionalDeploymentContributorPaths { get; set; }

        /// <summary>
        /// This property is used by SqlClr deployment to cause any blocking assemblies to be dropped as part of the deployment plan. By default, any blocking/referencing assemblies will block an assembly update if the referencing assembly needs to be dropped.
        /// </summary>
        [Description("This property is used by SqlClr deployment to cause any blocking assemblies to be dropped as part of the deployment plan. By default, any blocking/referencing assemblies will block an assembly update if the referencing assembly needs to be dropped.")]
        [DefaultValue(typeof(bool), "false")]
        public bool? AllowDropBlockingAssemblies { get => allowDropBlockingAssemblies ?? false; set => allowDropBlockingAssemblies = value; }

        /// <summary>
        /// Specifies whether to attempt the action despite incompatible SQL Server platforms.
        /// </summary>
        [Description("Specifies whether to attempt the action despite incompatible SQL Server platforms.")]
        [DefaultValue(typeof(bool), "false")]
        public bool? AllowIncompatiblePlatform { get => allowIncompatiblePlatform ?? false; set => allowIncompatiblePlatform = value; }

        /// <summary>
        /// Do not block data motion on a table that has Row Level Security if this property is set to true. Default is false.
        /// </summary>
        [Description("Do not block data motion on a table that has Row Level Security if this property is set to true. Default is false.")]
        [DefaultValue(typeof(bool), "false")]
        public bool? AllowUnsafeRowLevelSecurityDataMovement { get => allowUnsafeRowLevelSecurityDataMovement ?? false; set => allowUnsafeRowLevelSecurityDataMovement = value; }

        /// <summary>
        /// Backups the database before deploying any changes.
        /// </summary>
        [Description("Backups the database before deploying any changes.")]
        [DefaultValue(typeof(bool), "false")]
        public bool? BackupDatabaseBeforeChanges { get; set; }

        /// <summary>
        /// Specifies that the publish episode should be terminated if there is a possibility of data loss resulting from the publish.operation.
        /// </summary>
        [Description("Specifies that the publish episode should be terminated if there is a possibility of data loss resulting from the publish.operation.")]
        [DefaultValue(typeof(bool?), "true")]
        public bool? BlockOnPossibleDataLoss { get => blockOnPossibleDataLoss ?? true; set => blockOnPossibleDataLoss = value; }

        /// <summary>
        /// Specifies whether to block updating a database whose schema no longer matches its registration or is unregistered.
        /// </summary>
        [Description("Specifies whether to block updating a database whose schema no longer matches its registration or is unregistered.")]
        [DefaultValue(typeof(bool?), "true")]
        public bool? BlockWhenDriftDetected { get => blockWhenDriftDetected ?? true; set => blockWhenDriftDetected = value; }

        /// <summary>
        /// Specifies the command timeout in seconds when executing queries against SQL Server.
        /// </summary>
        [Description("Specifies the command timeout in seconds when executing queries against SQL Server.")]
        [DefaultValue(typeof(int?), "60")]
        public int? CommandTimeout { get => commandTimeout ?? 60; set => commandTimeout = value; }

        /// <summary>
        /// Specifies whether the declaration of SETVAR variables should be commented out in the generated publish script. You might choose to do this if you plan to specify the values on the command line when you publish by using a tool such as SQLCMD.EXE.
        /// </summary>
        [Description("Specifies whether the declaration of SETVAR variables should be commented out in the generated publish script. You might choose to do this if you plan to specify the values on the command line when you publish by using a tool such as SQLCMD.EXE.")]
        [DefaultValue(typeof(bool), "false")]
        public bool? CommentOutSetVarDeclarations { get => commentOutSetVarDeclarations ?? false; set => commentOutSetVarDeclarations = value; }

        /// <summary>
        /// This setting dictates how the database's collation is handled during deployment; by default the target database's collation will be updated if it does not match the collation specified by the source. When this option is set, the target database's (or server's) collation should be used.
        /// </summary>
        [Description("This setting dictates how the database's collation is handled during deployment; by default the target database's collation will be updated if it does not match the collation specified by the source. When this option is set, the target database's (or server's) collation should be used.")]
        [DefaultValue(typeof(bool), "false")]
        public bool? CompareUsingTargetCollation { get => compareUsingTargetCollation ?? false; set => compareUsingTargetCollation = value; }

        /// <summary>
        /// Specifies whether the target database should be updated or whether it should be dropped and re-created when you publish to a database.
        /// </summary>
        [Description("Specifies whether the target database should be updated or whether it should be dropped and re-created when you publish to a database.")]
        [DefaultValue(typeof(bool), "false")]
        public bool? CreateNewDatabase { get => createNewDatabase ?? false; set => createNewDatabase = value; }

        /// <summary>
        /// Defines the edition of an Azure SQL Database.
        /// </summary>
        [Description("Defines the edition of an Azure SQL Database.")]
        [DefaultValue(typeof(DatabaseEditionValue?), nameof(DatabaseEditionValue.Default))]
        public DatabaseEditionValue? DatabaseEdition { get => databaseEdition ?? DatabaseEditionValue.Default; set => databaseEdition = value; }

        /// <summary>
        /// Specifies the database lock timeout in seconds when executing queries against SQLServer. Use -1 to wait indefinitely.
        /// </summary>
        [Description("Specifies the database lock timeout in seconds when executing queries against SQLServer. Use -1 to wait indefinitely.")]
        [DefaultValue(typeof(int?), "60")]
        public int? DatabaseLockTimeout { get => databaseLockTimeout ?? 60; set => databaseLockTimeout = value; }

        /// <summary>
        /// Defines the maximum size in GB of an Azure SQL Database.
        /// </summary>
        [Description("Defines the maximum size in GB of an Azure SQL Database.")]
        [DefaultValue(typeof(int?), null)]
        public int? DatabaseMaximumSize { get; set; }

        /// <summary>
        /// Defines the performance level of an Azure SQL Database such as "P0" or "S1".
        /// </summary>
        [Description("Defines the performance level of an Azure SQL Database such as \"P0\" or \"S1\".")]
        [DefaultValue(typeof(string), null)]
        public string DatabaseServiceObjective { get; set; }

        /// <summary>
        /// if true, the database is set to Single User Mode before deploying.
        /// </summary>
        [Description("if true, the database is set to Single User Mode before deploying.")]
        [DefaultValue(typeof(bool), "false")]
        public bool? DeployDatabaseInSingleUserMode { get => deployDatabaseInSingleUserMode ?? false; set => deployDatabaseInSingleUserMode = value; }

        /// <summary>
        /// Specifies whether Data Definition Language (DDL) triggers are disabled at the beginning of the publish process and re-enabled at the end of the publish action.
        /// </summary>
        [Description("Specifies whether Data Definition Language (DDL) triggers are disabled at the beginning of the publish process and re-enabled at the end of the publish action.")]
        [DefaultValue(typeof(bool?), "true")]
        public bool? DisableAndReenableDdlTriggers { get => disableAndReenableDdlTriggers ?? true; set => disableAndReenableDdlTriggers = value; }

        /// <summary>
        /// If true, Change Data Capture objects are not altered.
        /// </summary>
        [Description("If true, Change Data Capture objects are not altered.")]
        [DefaultValue(typeof(bool?), "true")]
        public bool? DoNotAlterChangeDataCaptureObjects { get => doNotAlterChangeDataCaptureObjects ?? true; set => doNotAlterChangeDataCaptureObjects = value; }

        /// <summary>
        /// Specifies whether objects that are replicated are identified during verification.
        /// </summary>
        [Description("Specifies whether objects that are replicated are identified during verification.")]
        [DefaultValue(typeof(bool?), "true")]
        public bool? DoNotAlterReplicatedObjects { get => doNotAlterReplicatedObjects ?? true; set => doNotAlterReplicatedObjects = value; }

        /// <summary>
        /// An object type that should not be dropped when DropObjectsNotInSource is true. Valid object type names are Aggregates, ApplicationRoles, Assemblies, AsymmetricKeys, BrokerPriorities, Certificates, ColumnEncryptionKeys, ColumnMasterKeys, Contracts, DatabaseRoles, DatabaseTriggers, Defaults, ExtendedProperties, ExternalDataSources, ExternalFileFormats, ExternalTables, Filegroups, FileTables, FullTextCatalogs, FullTextStoplists, MessageTypes, PartitionFunctions, PartitionSchemes, Permissions, Queues, RemoteServiceBindings, RoleMembership, Rules, ScalarValuedFunctions, SearchPropertyLists, SecurityPolicies, Sequences, Services, Signatures, StoredProcedures, SymmetricKeys, Synonyms, Tables, TableValuedFunctions, UserDefinedDataTypes, UserDefinedTableTypes, ClrUserDefinedTypes, Users, Views, XmlSchemaCollections, Audits, Credentials, CryptographicProviders, DatabaseAuditSpecifications, DatabaseScopedCredentials, Endpoints, ErrorMessages, EventNotifications, EventSessions, LinkedServerLogins, LinkedServers, Logins, Routes, ServerAuditSpecifications, ServerRoleMembership, ServerRoles, ServerTriggers.
        /// </summary>
        [Description("An object type that should not be dropped when DropObjectsNotInSource is true. Valid object type names are Aggregates, ApplicationRoles, Assemblies, AsymmetricKeys, BrokerPriorities, Certificates, ColumnEncryptionKeys, ColumnMasterKeys, Contracts, DatabaseRoles, DatabaseTriggers, Defaults, ExtendedProperties, ExternalDataSources, ExternalFileFormats, ExternalTables, Filegroups, FileTables, FullTextCatalogs, FullTextStoplists, MessageTypes, PartitionFunctions, PartitionSchemes, Permissions, Queues, RemoteServiceBindings, RoleMembership, Rules, ScalarValuedFunctions, SearchPropertyLists, SecurityPolicies, Sequences, Services, Signatures, StoredProcedures, SymmetricKeys, Synonyms, Tables, TableValuedFunctions, UserDefinedDataTypes, UserDefinedTableTypes, ClrUserDefinedTypes, Users, Views, XmlSchemaCollections, Audits, Credentials, CryptographicProviders, DatabaseAuditSpecifications, DatabaseScopedCredentials, Endpoints, ErrorMessages, EventNotifications, EventSessions, LinkedServerLogins, LinkedServers, Logins, Routes, ServerAuditSpecifications, ServerRoleMembership, ServerRoles, ServerTriggers.")]
        [DefaultValue(typeof(string), null)]
        public string DoNotDropObjectType { get; set; }

        /// <summary>
        /// A semicolon-delimited list of object types that should not be dropped when DropObjectsNotInSource is true. Valid object type names are Aggregates, ApplicationRoles, Assemblies, AsymmetricKeys, BrokerPriorities, Certificates, ColumnEncryptionKeys, ColumnMasterKeys, Contracts, DatabaseRoles, DatabaseTriggers, Defaults, ExtendedProperties, ExternalDataSources, ExternalFileFormats, ExternalTables, Filegroups, FileTables, FullTextCatalogs, FullTextStoplists, MessageTypes, PartitionFunctions, PartitionSchemes, Permissions, Queues, RemoteServiceBindings, RoleMembership, Rules, ScalarValuedFunctions, SearchPropertyLists, SecurityPolicies, Sequences, Services, Signatures, StoredProcedures, SymmetricKeys, Synonyms, Tables, TableValuedFunctions, UserDefinedDataTypes, UserDefinedTableTypes, ClrUserDefinedTypes, Users, Views, XmlSchemaCollections, Audits, Credentials, CryptographicProviders, DatabaseAuditSpecifications, DatabaseScopedCredentials, Endpoints, ErrorMessages, EventNotifications, EventSessions, LinkedServerLogins, LinkedServers, Logins, Routes, ServerAuditSpecifications, ServerRoleMembership, ServerRoles, ServerTriggers.
        /// </summary>
        [Description("A semicolon-delimited list of object types that should not be dropped when DropObjectsNotInSource is true. Valid object type names are Aggregates, ApplicationRoles, Assemblies, AsymmetricKeys, BrokerPriorities, Certificates, ColumnEncryptionKeys, ColumnMasterKeys, Contracts, DatabaseRoles, DatabaseTriggers, Defaults, ExtendedProperties, ExternalDataSources, ExternalFileFormats, ExternalTables, Filegroups, FileTables, FullTextCatalogs, FullTextStoplists, MessageTypes, PartitionFunctions, PartitionSchemes, Permissions, Queues, RemoteServiceBindings, RoleMembership, Rules, ScalarValuedFunctions, SearchPropertyLists, SecurityPolicies, Sequences, Services, Signatures, StoredProcedures, SymmetricKeys, Synonyms, Tables, TableValuedFunctions, UserDefinedDataTypes, UserDefinedTableTypes, ClrUserDefinedTypes, Users, Views, XmlSchemaCollections, Audits, Credentials, CryptographicProviders, DatabaseAuditSpecifications, DatabaseScopedCredentials, Endpoints, ErrorMessages, EventNotifications, EventSessions, LinkedServerLogins, LinkedServers, Logins, Routes, ServerAuditSpecifications, ServerRoleMembership, ServerRoles, ServerTriggers.")]
        [DefaultValue(typeof(string), null)]
        public string DoNotDropObjectTypes { get; set; }

        /// <summary>
        /// Specifies whether constraints that do not exist in the database snapshot (.dacpac) file will be dropped from the target database when you publish to a database.
        /// </summary>
        [Description("Specifies whether constraints that do not exist in the database snapshot (.dacpac) file will be dropped from the target database when you publish to a database.")]
        [DefaultValue(typeof(bool?), "true")]
        public bool? DropConstraintsNotInSource { get => dropConstraintsNotInSource ?? true; set => dropConstraintsNotInSource = value; }

        /// <summary>
        /// Specifies whether DML triggers that do not exist in the database snapshot (.dacpac) file will be dropped from the target database when you publish to a database.
        /// </summary>
        [Description("Specifies whether DML triggers that do not exist in the database snapshot (.dacpac) file will be dropped from the target database when you publish to a database.")]
        [DefaultValue(typeof(bool?), "true")]
        public bool? DropDmlTriggersNotInSource { get => dropDmlTriggersNotInSource ?? true; set => dropDmlTriggersNotInSource = value; }

        /// <summary>
        /// Specifies whether extended properties that do not exist in the database snapshot (.dacpac) file will be dropped from the target database when you publish to a database.
        /// </summary>
        [Description("Specifies whether extended properties that do not exist in the database snapshot (.dacpac) file will be dropped from the target database when you publish to a database.")]
        [DefaultValue(typeof(bool?), "true")]
        public bool? DropExtendedPropertiesNotInSource { get => dropExtendedPropertiesNotInSource ?? true; set => dropExtendedPropertiesNotInSource = value; }

        /// <summary>
        /// Specifies whether indexes that do not exist in the database snapshot (.dacpac) file will be dropped from the target database when you publish to a database.
        /// </summary>
        [Description("Specifies whether indexes that do not exist in the database snapshot (.dacpac) file will be dropped from the target database when you publish to a database.")]
        [DefaultValue(typeof(bool?), "true")]
        public bool? DropIndexesNotInSource { get => dropIndexesNotInSource ?? true; set => dropIndexesNotInSource = value; }

        /// <summary>
        /// Specifies whether objects that do not exist in the database snapshot (.dacpac) file will be dropped from the target database when you publish to a database. This value takes precedence over DropExtendedProperties.
        /// </summary>
        [Description("Specifies whether objects that do not exist in the database snapshot (.dacpac) file will be dropped from the target database when you publish to a database. This value takes precedence over DropExtendedProperties.")]
        [DefaultValue(typeof(bool), "false")]
        public bool? DropObjectsNotInSource { get => dropObjectsNotInSource ?? false; set => dropObjectsNotInSource = value; }

        /// <summary>
        /// Specifies whether permissions that do not exist in the database snapshot (.dacpac) file will be dropped from the target database when you publish updates to a database.
        /// </summary>
        [Description("Specifies whether permissions that do not exist in the database snapshot (.dacpac) file will be dropped from the target database when you publish updates to a database.")]
        [DefaultValue(typeof(bool), "false")]
        public bool? DropPermissionsNotInSource { get => dropPermissionsNotInSource ?? false; set => dropPermissionsNotInSource = value; }

        /// <summary>
        /// Specifies whether role members that are not defined in the database snapshot (.dacpac) file will be dropped from the target database when you publish updates to a database.
        /// </summary>
        [Description("Specifies whether role members that are not defined in the database snapshot (.dacpac) file will be dropped from the target database when you publish updates to a database.")]
        [DefaultValue(typeof(bool), "false")]
        public bool? DropRoleMembersNotInSource { get => dropRoleMembersNotInSource ?? false; set => dropRoleMembersNotInSource = value; }

        /// <summary>
        /// Specifies whether statistics that do not exist in the database snapshot (.dacpac) file will be dropped from the target database when you publish to a database.
        /// </summary>
        [Description("Specifies whether statistics that do not exist in the database snapshot (.dacpac) file will be dropped from the target database when you publish to a database.")]
        [DefaultValue(typeof(bool?), "true")]
        public bool? DropStatisticsNotInSource { get => dropStatisticsNotInSource ?? true; set => dropStatisticsNotInSource = value; }

        /// <summary>
        /// An object type that should be ignored during deployment. Valid object type names are Aggregates, ApplicationRoles, Assemblies, AsymmetricKeys, BrokerPriorities, Certificates, ColumnEncryptionKeys, ColumnMasterKeys, Contracts, DatabaseRoles, DatabaseTriggers, Defaults, ExtendedProperties, ExternalDataSources, ExternalFileFormats, ExternalTables, Filegroups, FileTables, FullTextCatalogs, FullTextStoplists, MessageTypes, PartitionFunctions, PartitionSchemes, Permissions, Queues, RemoteServiceBindings, RoleMembership, Rules, ScalarValuedFunctions, SearchPropertyLists, SecurityPolicies, Sequences, Services, Signatures, StoredProcedures, SymmetricKeys, Synonyms, Tables, TableValuedFunctions, UserDefinedDataTypes, UserDefinedTableTypes, ClrUserDefinedTypes, Users, Views, XmlSchemaCollections, Audits, Credentials, CryptographicProviders, DatabaseAuditSpecifications, DatabaseScopedCredentials, Endpoints, ErrorMessages, EventNotifications, EventSessions, LinkedServerLogins, LinkedServers, Logins, Routes, ServerAuditSpecifications, ServerRoleMembership, ServerRoles, ServerTriggers.
        /// </summary>
        [Description("An object type that should be ignored during deployment. Valid object type names are Aggregates, ApplicationRoles, Assemblies, AsymmetricKeys, BrokerPriorities, Certificates, ColumnEncryptionKeys, ColumnMasterKeys, Contracts, DatabaseRoles, DatabaseTriggers, Defaults, ExtendedProperties, ExternalDataSources, ExternalFileFormats, ExternalTables, Filegroups, FileTables, FullTextCatalogs, FullTextStoplists, MessageTypes, PartitionFunctions, PartitionSchemes, Permissions, Queues, RemoteServiceBindings, RoleMembership, Rules, ScalarValuedFunctions, SearchPropertyLists, SecurityPolicies, Sequences, Services, Signatures, StoredProcedures, SymmetricKeys, Synonyms, Tables, TableValuedFunctions, UserDefinedDataTypes, UserDefinedTableTypes, ClrUserDefinedTypes, Users, Views, XmlSchemaCollections, Audits, Credentials, CryptographicProviders, DatabaseAuditSpecifications, DatabaseScopedCredentials, Endpoints, ErrorMessages, EventNotifications, EventSessions, LinkedServerLogins, LinkedServers, Logins, Routes, ServerAuditSpecifications, ServerRoleMembership, ServerRoles, ServerTriggers.")]
        [DefaultValue(typeof(string), null)]
        public string ExcludeObjectType { get; set; }

        /// <summary>
        /// A semicolon-delimited list of object types that should be ignored during deployment. Valid object type names are Aggregates, ApplicationRoles, Assemblies, AsymmetricKeys, BrokerPriorities, Certificates, ColumnEncryptionKeys, ColumnMasterKeys, Contracts, DatabaseRoles, DatabaseTriggers, Defaults, ExtendedProperties, ExternalDataSources, ExternalFileFormats, ExternalTables, Filegroups, FileTables, FullTextCatalogs, FullTextStoplists, MessageTypes, PartitionFunctions, PartitionSchemes, Permissions, Queues, RemoteServiceBindings, RoleMembership, Rules, ScalarValuedFunctions, SearchPropertyLists, SecurityPolicies, Sequences, Services, Signatures, StoredProcedures, SymmetricKeys, Synonyms, Tables, TableValuedFunctions, UserDefinedDataTypes, UserDefinedTableTypes, ClrUserDefinedTypes, Users, Views, XmlSchemaCollections, Audits, Credentials, CryptographicProviders, DatabaseAuditSpecifications, DatabaseScopedCredentials, Endpoints, ErrorMessages, EventNotifications, EventSessions, LinkedServerLogins, LinkedServers, Logins, Routes, ServerAuditSpecifications, ServerRoleMembership, ServerRoles, ServerTriggers.
        /// </summary>
        [Description("A semicolon-delimited list of object types that should be ignored during deployment. Valid object type names are Aggregates, ApplicationRoles, Assemblies, AsymmetricKeys, BrokerPriorities, Certificates, ColumnEncryptionKeys, ColumnMasterKeys, Contracts, DatabaseRoles, DatabaseTriggers, Defaults, ExtendedProperties, ExternalDataSources, ExternalFileFormats, ExternalTables, Filegroups, FileTables, FullTextCatalogs, FullTextStoplists, MessageTypes, PartitionFunctions, PartitionSchemes, Permissions, Queues, RemoteServiceBindings, RoleMembership, Rules, ScalarValuedFunctions, SearchPropertyLists, SecurityPolicies, Sequences, Services, Signatures, StoredProcedures, SymmetricKeys, Synonyms, Tables, TableValuedFunctions, UserDefinedDataTypes, UserDefinedTableTypes, ClrUserDefinedTypes, Users, Views, XmlSchemaCollections, Audits, Credentials, CryptographicProviders, DatabaseAuditSpecifications, DatabaseScopedCredentials, Endpoints, ErrorMessages, EventNotifications, EventSessions, LinkedServerLogins, LinkedServers, Logins, Routes, ServerAuditSpecifications, ServerRoleMembership, ServerRoles, ServerTriggers.")]
        [DefaultValue(typeof(string), null)]
        public string ExcludeObjectTypes { get; set; }

        /// <summary>
        /// Automatically provides a default value when updating a table that contains data with a column that does not allow null values.
        /// </summary>
        [Description("Automatically provides a default value when updating a table that contains data with a column that does not allow null values.")]
        [DefaultValue(typeof(bool), "false")]
        public bool? GenerateSmartDefaults { get => generateSmartDefaults ?? false; set => generateSmartDefaults = value; }

        /// <summary>
        /// Specifies whether differences in the ANSI NULLS setting should be ignored or updated when you publish to a database.
        /// </summary>
        [Description("Specifies whether differences in the ANSI NULLS setting should be ignored or updated when you publish to a database.")]
        [DefaultValue(typeof(bool?), "true")]
        public bool? IgnoreAnsiNulls { get => ignoreAnsiNulls ?? true; set => ignoreAnsiNulls = value; }

        /// <summary>
        /// Specifies whether differences in the Authorizer should be ignored or updated when you publish to a database.
        /// </summary>
        [Description("Specifies whether differences in the Authorizer should be ignored or updated when you publish to a database.")]
        [DefaultValue(typeof(bool), "false")]
        public bool? IgnoreAuthorizer { get => ignoreAuthorizer ?? false; set => ignoreAuthorizer = value; }

        /// <summary>
        /// Specifies whether differences in the column collations should be ignored or updated when you publish to a database.
        /// </summary>
        [Description("Specifies whether differences in the column collations should be ignored or updated when you publish to a database.")]
        [DefaultValue(typeof(bool), "false")]
        public bool? IgnoreColumnCollation { get => ignoreColumnCollation ?? false; set => ignoreColumnCollation = value; }

        /// <summary>
        /// Specifies whether differences in table column order should be ignored or updated when you publish to a database.
        /// </summary>
        [Description("Specifies whether differences in table column order should be ignored or updated when you publish to a database.")]
        [DefaultValue(typeof(bool), "false")]
        public bool? IgnoreColumnOrder { get => ignoreColumnOrder ?? false; set => ignoreColumnOrder = value; }

        /// <summary>
        /// Specifies whether differences in the comments should be ignored or updated when you publish to a database.
        /// </summary>
        [Description("Specifies whether differences in the comments should be ignored or updated when you publish to a database.")]
        [DefaultValue(typeof(bool), "false")]
        public bool? IgnoreComments { get => ignoreComments ?? false; set => ignoreComments = value; }

        /// <summary>
        /// Specifies whether differences in the file path for the cryptographic provider should be ignored or updated when you publish to a database.
        /// </summary>
        [Description("Specifies whether differences in the file path for the cryptographic provider should be ignored or updated when you publish to a database.")]
        [DefaultValue(typeof(bool?), "true")]
        public bool? IgnoreCryptographicProviderFilePath { get => ignoreCryptographicProviderFilePath ?? true; set => ignoreCryptographicProviderFilePath = value; }

        /// <summary>
        /// Specifies whether differences in the order of Data Definition Language (DDL) triggers should be ignored or updated when you publish to a database or server.
        /// </summary>
        [Description("Specifies whether differences in the order of Data Definition Language (DDL) triggers should be ignored or updated when you publish to a database or server.")]
        [DefaultValue(typeof(bool), "false")]
        public bool? IgnoreDdlTriggerOrder { get => ignoreDdlTriggerOrder ?? false; set => ignoreDdlTriggerOrder = value; }

        /// <summary>
        /// Specifies whether differences in the enabled or disabled state of Data Definition Language (DDL) triggers should be ignored or updated when you publish to a database.
        /// </summary>
        [Description("Specifies whether differences in the enabled or disabled state of Data Definition Language (DDL) triggers should be ignored or updated when you publish to a database.")]
        [DefaultValue(typeof(bool), "false")]
        public bool? IgnoreDdlTriggerState { get => ignoreDdlTriggerState ?? false; set => ignoreDdlTriggerState = value; }

        /// <summary>
        /// Specifies whether differences in the default schema should be ignored or updated when you publish to a database.
        /// </summary>
        [Description("Specifies whether differences in the default schema should be ignored or updated when you publish to a database.")]
        [DefaultValue(typeof(bool), "false")]
        public bool? IgnoreDefaultSchema { get => ignoreDefaultSchema ?? false; set => ignoreDefaultSchema = value; }

        /// <summary>
        /// Specifies whether differences in the order of Data Manipulation Language (DML) triggers should be ignored or updated when you publish to a database.
        /// </summary>
        [Description("Specifies whether differences in the order of Data Manipulation Language (DML) triggers should be ignored or updated when you publish to a database.")]
        [DefaultValue(typeof(bool), "false")]
        public bool? IgnoreDmlTriggerOrder { get => ignoreDmlTriggerOrder ?? false; set => ignoreDmlTriggerOrder = value; }

        /// <summary>
        /// Specifies whether differences in the enabled or disabled state of DML triggers should be ignored or updated when you publish to a database.
        /// </summary>
        [Description("Specifies whether differences in the enabled or disabled state of DML triggers should be ignored or updated when you publish to a database.")]
        [DefaultValue(typeof(bool), "false")]
        public bool? IgnoreDmlTriggerState { get => ignoreDmlTriggerState ?? false; set => ignoreDmlTriggerState = value; }

        /// <summary>
        /// Specifies whether differences in the extended properties should be ignored or updated when you publish to a database.
        /// </summary>
        [Description("Specifies whether differences in the extended properties should be ignored or updated when you publish to a database.")]
        [DefaultValue(typeof(bool), "false")]
        public bool? IgnoreExtendedProperties { get => ignoreExtendedProperties ?? false; set => ignoreExtendedProperties = value; }

        /// <summary>
        /// Specifies whether differences in the paths for files and log files should be ignored or updated when you publish to a database.
        /// </summary>
        [Description("Specifies whether differences in the paths for files and log files should be ignored or updated when you publish to a database.")]
        [DefaultValue(typeof(bool?), "true")]
        public bool? IgnoreFileAndLogFilePath { get => ignoreFileAndLogFilePath ?? true; set => ignoreFileAndLogFilePath = value; }

        /// <summary>
        /// Specifies whether differences in the placement of objects in FILEGROUPs should be ignored or updated when you publish to a database.
        /// </summary>
        [Description("Specifies whether differences in the placement of objects in FILEGROUPs should be ignored or updated when you publish to a database.")]
        [DefaultValue(typeof(bool?), "true")]
        public bool? IgnoreFilegroupPlacement { get => ignoreFilegroupPlacement ?? true; set => ignoreFilegroupPlacement = value; }

        /// <summary>
        /// Specifies whether differences in the file sizes should be ignored or whether a warning should be issued when you publish to a database.
        /// </summary>
        [Description("Specifies whether differences in the file sizes should be ignored or whether a warning should be issued when you publish to a database.")]
        [DefaultValue(typeof(bool?), "true")]
        public bool? IgnoreFileSize { get => ignoreFileSize ?? true; set => ignoreFileSize = value; }

        /// <summary>
        /// Specifies whether differences in the fill factor for index storage should be ignored or whether a warning should be issued when you publish to a database
        /// </summary>
        [Description("Specifies whether differences in the fill factor for index storage should be ignored or whether a warning should be issued when you publish to a database")]
        [DefaultValue(typeof(bool?), "true")]
        public bool? IgnoreFillFactor { get => ignoreFillFactor ?? true; set => ignoreFillFactor = value; }

        /// <summary>
        /// Specifies whether differences in the file path for the full-text catalog should be ignored or whether a warning should be issued when you publish to a database.
        /// </summary>
        [Description("Specifies whether differences in the file path for the full-text catalog should be ignored or whether a warning should be issued when you publish to a database.")]
        [DefaultValue(typeof(bool?), "true")]
        public bool? IgnoreFullTextCatalogFilePath { get => ignoreFullTextCatalogFilePath ?? true; set => ignoreFullTextCatalogFilePath = value; }

        /// <summary>
        /// Specifies whether differences in the seed for an identity column should be ignored or updated when you publish updates to a database.
        /// </summary>
        [Description("Specifies whether differences in the seed for an identity column should be ignored or updated when you publish updates to a database.")]
        [DefaultValue(typeof(bool), "false")]
        public bool? IgnoreIdentitySeed { get => ignoreIdentitySeed ?? false; set => ignoreIdentitySeed = value; }

        /// <summary>
        /// Specifies whether differences in the increment for an identity column should be ignored or updated when you publish to a database.
        /// </summary>
        [Description("Specifies whether differences in the increment for an identity column should be ignored or updated when you publish to a database.")]
        [DefaultValue(typeof(bool), "false")]
        public bool? IgnoreIncrement { get => ignoreIncrement ?? false; set => ignoreIncrement = value; }

        /// <summary>
        /// Specifies whether differences in the index options should be ignored or updated when you publish to a database.
        /// </summary>
        [Description("Specifies whether differences in the index options should be ignored or updated when you publish to a database.")]
        [DefaultValue(typeof(bool), "false")]
        public bool? IgnoreIndexOptions { get => ignoreIndexOptions ?? false; set => ignoreIndexOptions = value; }

        /// <summary>
        /// Specifies whether differences in the index padding should be ignored or updated when you publish to a database.
        /// </summary>
        [Description("Specifies whether differences in the index padding should be ignored or updated when you publish to a database.")]
        [DefaultValue(typeof(bool?), "true")]
        public bool? IgnoreIndexPadding { get => ignoreIndexPadding ?? true; set => ignoreIndexPadding = value; }

        /// <summary>
        /// Specifies whether differences in the casing of keywords should be ignored or updated when you publish to a database.
        /// </summary>
        [Description("Specifies whether differences in the casing of keywords should be ignored or updated when you publish to a database.")]
        [DefaultValue(typeof(bool?), "true")]
        public bool? IgnoreKeywordCasing { get => ignoreKeywordCasing ?? true; set => ignoreKeywordCasing = value; }

        /// <summary>
        /// Specifies whether differences in the lock hints on indexes should be ignored or updated when you publish to a database.
        /// </summary>
        [Description("Specifies whether differences in the lock hints on indexes should be ignored or updated when you publish to a database.")]
        [DefaultValue(typeof(bool), "false")]
        public bool? IgnoreLockHintsOnIndexes { get => ignoreLockHintsOnIndexes ?? false; set => ignoreLockHintsOnIndexes = value; }

        /// <summary>
        /// Specifies whether differences in the security identification number (SID) should be ignored or updated when you publish to a database.
        /// </summary>
        [Description("Specifies whether differences in the security identification number (SID) should be ignored or updated when you publish to a database.")]
        [DefaultValue(typeof(bool?), "true")]
        public bool? IgnoreLoginSids { get => ignoreLoginSids ?? true; set => ignoreLoginSids = value; }

        /// <summary>
        /// Specifies whether the not for replication settings should be ignored or updated when you publish to a database.
        /// </summary>
        [Description("Specifies whether the not for replication settings should be ignored or updated when you publish to a database.")]
        [DefaultValue(typeof(bool), "false")]
        public bool? IgnoreNotForReplication { get => ignoreNotForReplication ?? false; set => ignoreNotForReplication = value; }

        /// <summary>
        /// Specifies whether an object's placement on a partition scheme should be ignored or updated when you publish to a database.
        /// </summary>
        [Description("Specifies whether an object's placement on a partition scheme should be ignored or updated when you publish to a database.")]
        [DefaultValue(typeof(bool?), "true")]
        public bool? IgnoreObjectPlacementOnPartitionScheme { get => ignoreObjectPlacementOnPartitionScheme ?? true; set => ignoreObjectPlacementOnPartitionScheme = value; }

        /// <summary>
        /// Specifies whether differences in partition schemes and functions should be ignored or updated when you publish to a database.
        /// </summary>
        [Description("Specifies whether differences in partition schemes and functions should be ignored or updated when you publish to a database.")]
        [DefaultValue(typeof(bool), "false")]
        public bool? IgnorePartitionSchemes { get => ignorePartitionSchemes ?? false; set => ignorePartitionSchemes = value; }

        /// <summary>
        /// Specifies whether differences in the permissions should be ignored or updated when you publish to a database.
        /// </summary>
        [Description("Specifies whether differences in the permissions should be ignored or updated when you publish to a database.")]
        [DefaultValue(typeof(bool), "false")]
        public bool? IgnorePermissions { get => ignorePermissions ?? false; set => ignorePermissions = value; }

        /// <summary>
        /// Specifies whether differences in the quoted identifiers setting should be ignored or updated when you publish to a database.
        /// </summary>
        [Description("Specifies whether differences in the quoted identifiers setting should be ignored or updated when you publish to a database.")]
        [DefaultValue(typeof(bool?), "true")]
        public bool? IgnoreQuotedIdentifiers { get => ignoreQuotedIdentifiers ?? true; set => ignoreQuotedIdentifiers = value; }

        /// <summary>
        /// Specifies whether differences in the role membership of logins should be ignored or updated when you publish to a database.
        /// </summary>
        [Description("Specifies whether differences in the role membership of logins should be ignored or updated when you publish to a database.")]
        [DefaultValue(typeof(bool), "false")]
        public bool? IgnoreRoleMembership { get => ignoreRoleMembership ?? false; set => ignoreRoleMembership = value; }

        /// <summary>
        /// Specifies whether differences in the amount of time that SQL Server retains the route in the routing table should be ignored or updated when you publish to a database
        /// </summary>
        [Description("Specifies whether differences in the amount of time that SQL Server retains the route in the routing table should be ignored or updated when you publish to a database")]
        [DefaultValue(typeof(bool?), "true")]
        public bool? IgnoreRouteLifetime { get => ignoreRouteLifetime ?? true; set => ignoreRouteLifetime = value; }

        /// <summary>
        /// Specifies whether differences in the semi-colons between T-SQL statements will be ignored or updated when you publish to a database.
        /// </summary>
        [Description("Specifies whether differences in the semi-colons between T-SQL statements will be ignored or updated when you publish to a database.")]
        [DefaultValue(typeof(bool?), "true")]
        public bool? IgnoreSemicolonBetweenStatements { get => ignoreSemicolonBetweenStatements ?? true; set => ignoreSemicolonBetweenStatements = value; }

        /// <summary>
        /// Specifies whether differences in the table options will be ignored or updated when you publish to a database.
        /// </summary>
        [Description("Specifies whether differences in the table options will be ignored or updated when you publish to a database.")]
        [DefaultValue(typeof(bool), "false")]
        public bool? IgnoreTableOptions { get => ignoreTableOptions ?? false; set => ignoreTableOptions = value; }

        /// <summary>
        /// Specifies whether differences in the table partition options will be ignored or updated when you publish to a database. This option applies only to Azure Synapse Analytics data warehouse databases.
        /// </summary>
        [Description("Specifies whether differences in the table partition options will be ignored or updated when you publish to a database. This option applies only to Azure Synapse Analytics data warehouse databases.")]
        [DefaultValue(typeof(bool), "false")]
        public bool? IgnoreTablePartitionOptions { get => ignoreTablePartitionOptions ?? false; set => ignoreTablePartitionOptions = value; }

        /// <summary>
        /// Specifies whether differences in the user settings objects will be ignored or updated when you publish to a database.
        /// </summary>
        [Description("Specifies whether differences in the user settings objects will be ignored or updated when you publish to a database.")]
        [DefaultValue(typeof(bool), "false")]
        public bool? IgnoreUserSettingsObjects { get => ignoreUserSettingsObjects ?? false; set => ignoreUserSettingsObjects = value; }

        /// <summary>
        /// Specifies whether differences in white space will be ignored or updated when you publish to a database.
        /// </summary>
        [Description("Specifies whether differences in white space will be ignored or updated when you publish to a database.")]
        [DefaultValue(typeof(bool?), "true")]
        public bool? IgnoreWhitespace { get => ignoreWhitespace ?? true; set => ignoreWhitespace = value; }

        /// <summary>
        /// Specifies whether differences in the value of the WITH NOCHECK clause for check constraints will be ignored or updated when you publish to a database.
        /// </summary>
        [Description("Specifies whether differences in the value of the WITH NOCHECK clause for check constraints will be ignored or updated when you publish to a database.")]
        [DefaultValue(typeof(bool), "false")]
        public bool? IgnoreWithNocheckOnCheckConstraints { get => ignoreWithNocheckOnCheckConstraints ?? false; set => ignoreWithNocheckOnCheckConstraints = value; }

        /// <summary>
        /// Specifies whether differences in the value of the WITH NOCHECK clause for foreign keys will be ignored or updated when you publish to a database.
        /// </summary>
        [Description("Specifies whether differences in the value of the WITH NOCHECK clause for foreign keys will be ignored or updated when you publish to a database.")]
        [DefaultValue(typeof(bool), "false")]
        public bool? IgnoreWithNocheckOnForeignKeys { get => ignoreWithNocheckOnForeignKeys ?? false; set => ignoreWithNocheckOnForeignKeys = value; }

        /// <summary>
        /// Include all composite elements as part of a single publish operation.
        /// </summary>
        [Description("Include all composite elements as part of a single publish operation.")]
        [DefaultValue(typeof(bool), "false")]
        public bool? IncludeCompositeObjects { get => includeCompositeObjects ?? false; set => includeCompositeObjects = value; }

        /// <summary>
        /// Specifies whether transactional statements should be used where possible when you publish to a database.
        /// </summary>
        [Description("Specifies whether transactional statements should be used where possible when you publish to a database.")]
        [DefaultValue(typeof(bool), "false")]
        public bool? IncludeTransactionalScripts { get => includeTransactionalScripts ?? false; set => includeTransactionalScripts = value; }

        /// <summary>
        /// Specifies the long running command timeout in seconds when executing queries against SQL Server. Use 0 to wait indefinitely.
        /// </summary>
        [Description("Specifies the long running command timeout in seconds when executing queries against SQL Server. Use 0 to wait indefinitely.")]
        [DefaultValue(typeof(int?), "60")]
        public int? LongRunningCommandTimeout { get => longRunningCommandTimeout ?? 60; set => longRunningCommandTimeout = value; }

        /// <summary>
        /// Specifies that publish should always drop and re-create an assembly if there is a difference instead of issuing an ALTER ASSEMBLY statement.
        /// </summary>
        [Description("Specifies that publish should always drop and re-create an assembly if there is a difference instead of issuing an ALTER ASSEMBLY statement.")]
        [DefaultValue(typeof(bool), "false")]
        public bool? NoAlterStatementsToChangeClrTypes { get => noAlterStatementsToChangeClrTypes ?? false; set => noAlterStatementsToChangeClrTypes = value; }

        /// <summary>
        /// Specifies whether a new file is also created when a new FileGroup is created in the target database.
        /// </summary>
        [Description("Specifies whether a new file is also created when a new FileGroup is created in the target database.")]
        [DefaultValue(typeof(bool?), "true")]
        public bool? PopulateFilesOnFileGroups { get => populateFilesOnFileGroups ?? true; set => populateFilesOnFileGroups = value; }

        /// <summary>
        /// Specifies whether the schema is registered with the database server.
        /// </summary>
        [Description("Specifies whether the schema is registered with the database server.")]
        [DefaultValue(typeof(bool), "false")]
        public bool? RegisterDataTierApplication { get => registerDataTierApplication ?? false; set => registerDataTierApplication = value; }

        /// <summary>
        /// Specifies whether DeploymentPlanExecutor contributors should be run when other operations are executed.
        /// </summary>
        [Description("Specifies whether DeploymentPlanExecutor contributors should be run when other operations are executed.")]
        [DefaultValue(typeof(bool), "false")]
        public bool? RunDeploymentPlanExecutors { get => runDeploymentPlanExecutors ?? false; set => runDeploymentPlanExecutors = value; }

        /// <summary>
        /// Specifies whether differences in the database collation should be ignored or updated when you publish to a database.
        /// </summary>
        [Description("Specifies whether differences in the database collation should be ignored or updated when you publish to a database.")]
        [DefaultValue(typeof(bool), "false")]
        public bool? ScriptDatabaseCollation { get => scriptDatabaseCollation ?? false; set => scriptDatabaseCollation = value; }

        /// <summary>
        /// Specifies whether differences in the database compatibility should be ignored or updated when you publish to a database.
        /// </summary>
        [Description("Specifies whether differences in the database compatibility should be ignored or updated when you publish to a database.")]
        [DefaultValue(typeof(bool), "false")]
        public bool? ScriptDatabaseCompatibility { get => scriptDatabaseCompatibility ?? false; set => scriptDatabaseCompatibility = value; }

        /// <summary>
        /// Specifies whether target database properties should be set or updated as part of the publish action.
        /// </summary>
        [Description("Specifies whether target database properties should be set or updated as part of the publish action.")]
        [DefaultValue(typeof(bool?), "true")]
        public bool? ScriptDatabaseOptions { get => scriptDatabaseOptions ?? true; set => scriptDatabaseOptions = value; }

        /// <summary>
        /// Specifies whether statements are generated in the publish script to verify that the database name and server name match the names specified in the database project.
        /// </summary>
        [Description("Specifies whether statements are generated in the publish script to verify that the database name and server name match the names specified in the database project.")]
        [DefaultValue(typeof(bool), "false")]
        public bool? ScriptDeployStateChecks { get => scriptDeployStateChecks ?? false; set => scriptDeployStateChecks = value; }
        /// <summary>
        /// Controls whether size is specified when adding a file to a filegroup.
        /// </summary>
        [Description("Controls whether size is specified when adding a file to a filegroup.")]
        [DefaultValue(typeof(bool), "false")]
        public bool? ScriptFileSize { get => scriptFileSize ?? false; set => scriptFileSize = value; }

        /// <summary>
        /// At the end of publish all of the constraints will be verified as one set, avoiding data errors caused by a check or foreign key constraint in the middle of publish. If set to False, your constraints are published without checking the corresponding data.
        /// </summary>
        [Description("At the end of publish all of the constraints will be verified as one set, avoiding data errors caused by a check or foreign key constraint in the middle of publish. If set to False, your constraints are published without checking the corresponding data.")]
        [DefaultValue(typeof(bool?), "true")]
        public bool? ScriptNewConstraintValidation { get => scriptNewConstraintValidation ?? true; set => scriptNewConstraintValidation = value; }

        /// <summary>
        /// Include refresh statements at the end of the publish script.
        /// </summary>
        [Description("Include refresh statements at the end of the publish script.")]
        [DefaultValue(typeof(bool?), "true")]
        public bool? ScriptRefreshModule { get => scriptRefreshModule ?? true; set => scriptRefreshModule = value; }

        /// <summary>
        /// Specifies how elements are stored when building the database model. For performance reasons the default is InMemory. For large databases, File backed storage is required.
        /// </summary>
        [Description("Specifies how elements are stored when building the database model. For performance reasons the default is InMemory. For large databases, File backed storage is required.")]
        [DefaultValue(typeof(StorageValue), nameof(StorageValue.Memory))]
        public StorageValue? Storage { get => storage ?? StorageValue.Memory; set => storage = value; }

        /// <summary>
        /// Specifies whether errors encountered during publish verification should be treated as warnings. The check is performed against the generated deployment plan before the plan is executed against your target database. Plan verification detects problems such as the loss of target-only objects (such as indexes) that must be dropped to make a change. Verification will also detect situations where dependencies (such as a table or view) exist because of a reference to a composite project, but do not exist in the target database. You might choose to do this to get a complete list of all issues, instead of having the publish action stop on the first error.
        /// </summary>
        [Description("Specifies whether errors encountered during publish verification should be treated as warnings. The check is performed against the generated deployment plan before the plan is executed against your target database. Plan verification detects problems such as the loss of target-only objects (such as indexes) that must be dropped to make a change. Verification will also detect situations where dependencies (such as a table or view) exist because of a reference to a composite project, but do not exist in the target database. You might choose to do this to get a complete list of all issues, instead of having the publish action stop on the first error.")]
        [DefaultValue(typeof(bool), "false")]
        public bool? TreatVerificationErrorsAsWarnings { get => treatVerificationErrorsAsWarnings ?? false; set => treatVerificationErrorsAsWarnings = value; }

        /// <summary>
        /// Specifies whether warnings should be generated when differences are found in objects that cannot be modified, for example, if the file size or file paths were different for a file.
        /// </summary>
        [Description("Specifies whether warnings should be generated when differences are found in objects that cannot be modified, for example, if the file size or file paths were different for a file.")]
        [DefaultValue(typeof(bool), "true")]
        public bool? UnmodifiableObjectWarnings { get => unmodifiableObjectWarnings ?? true; set => unmodifiableObjectWarnings = value; }

        /// <summary>
        /// Specifies whether collation compatibility is verified.
        /// </summary>
        [Description("Specifies whether collation compatibility is verified.")]
        [DefaultValue(typeof(bool), "true")]
        public bool? VerifyCollationCompatibility { get => verifyCollationCompatibility ?? true; set => verifyCollationCompatibility = value; }

        /// <summary>
        /// Specifies whether checks should be performed before publishing that will stop the publish action if issues are present that might block successful publishing. For example, your publish action might stop if you have foreign keys on the target database that do not exist in the database project, and that causes errors when you publish.
        /// </summary>
        [Description("Specifies whether checks should be performed before publishing that will stop the publish action if issues are present that might block successful publishing. For example, your publish action might stop if you have foreign keys on the target database that do not exist in the database project, and that causes errors when you publish.")]
        [DefaultValue(typeof(bool), "true")]
        public bool? VerifyDeployment { get => verifyDeployment ?? true; set => verifyDeployment = value; }

    }
}
