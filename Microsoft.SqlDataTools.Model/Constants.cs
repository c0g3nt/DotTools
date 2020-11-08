using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Microsoft.SqlDataTools.Model
{
    public enum DacActionValue
    {
        /// <summary>
        /// A SqlPackage.exe publish operation incrementally updates the schema of a target database to match the structure of a source database. Publishing a deployment package that contains user data for all or a subset of tables update the table data in addition to the schema. Data deployment overwrites the schema and data in existing tables of the target database. Data deployment will not change existing schema or data in the target database for tables not included in the deployment package.
        /// </summary>
        [Description("A SqlPackage.exe publish operation incrementally updates the schema of a target database to match the structure of a source database. Publishing a deployment package that contains user data for all or a subset of tables update the table data in addition to the schema. Data deployment overwrites the schema and data in existing tables of the target database. Data deployment will not change existing schema or data in the target database for tables not included in the deployment package.")]
        Publish,
        /// <summary>
        /// A SqlPackage.exe report action creates an XML report of the changes that would be made by a publish action.
        /// </summary>
        [Description("A SqlPackage.exe report action creates an XML report of the changes that would be made by a publish action.")]
        DeployReport,
        /// <summary>
        /// A SqlPackage.exe Export action exports a live database from SQL Server or Azure SQL Database to a BACPAC package (.bacpac file). By default, data for all tables will be included in the .bacpac file. Optionally, you can specify only a subset of tables for which to export data. Validation for the Export action ensures Azure SQL Database compatibility for the complete targeted database even if a subset of tables is specified for the export.
        /// </summary>
        [Description("A SqlPackage.exe Export action exports a live database from SQL Server or Azure SQL Database to a BACPAC package (.bacpac file). By default, data for all tables will be included in the .bacpac file. Optionally, you can specify only a subset of tables for which to export data. Validation for the Export action ensures Azure SQL Database compatibility for the complete targeted database even if a subset of tables is specified for the export.")]
        Export,
        /// <summary>
        /// A SqlPackage.exe Extract action creates a schema of a live database from SQL Server or Azure SQL Database to a DACPAC package (.dacpac file). By default, data is not included in the .dacpac file. To include data, utilize the Export action.
        /// </summary>
        [Description("A SqlPackage.exe Extract action creates a schema of a live database from SQL Server or Azure SQL Database to a DACPAC package (.dacpac file). By default, data is not included in the .dacpac file. To include data, utilize the Export action.")]
        Extract,
        /// <summary>
        /// A SqlPackage.exe Import action imports the schema and table data from a BACPAC package - .bacpac file - into a new or empty database in SQL Server or Azure SQL Database. At the time, of the import operation to an existing database, the target database cannot contain any user-defined schema objects.
        /// </summary>
        [Description("A SqlPackage.exe Import action imports the schema and table data from a BACPAC package - .bacpac file - into a new or empty database in SQL Server or Azure SQL Database. At the time, of the import operation to an existing database, the target database cannot contain any user-defined schema objects.")]
        Import,
        /// <summary>
        /// A SqlPackage.exe report action creates an XML report of the changes that have been made to the registered database since it was last registered.
        /// </summary>
        [Description("A SqlPackage.exe report action creates an XML report of the changes that have been made to the registered database since it was last registered.")]
        DriftReport,
        /// <summary>
        /// A SqlPackage.exe script action creates a Transact-SQL incremental update script that updates the schema of a target database to match the schema of a source database.
        /// </summary>
        [Description("A SqlPackage.exe script action creates a Transact-SQL incremental update script that updates the schema of a target database to match the schema of a source database.")]
        Script
    }
    public enum AzureKeyVaultAuthMethodValue
    {
        Interactive,
        ClientIdSecret
    }
    public enum DatabaseEditionValue
    {
        Basic,
        Standard,
        Premium,
        DataWarehouse,
        GeneralPurpose,
        BusinessCritical,
        Hyperscale,
        Default
    }
    public enum StorageValue
    {
        File,
        Memory
    }

    public enum EngineVersionValue
    {
        Default,
        Latest,
        V11,
        V12
    }
    [Flags]
    public enum ObjectTypes
    {
        Aggregates, 
        ApplicationRoles, 
        Assemblies, 
        AsymmetricKeys, 
        BrokerPriorities, 
        Certificates, 
        ColumnEncryptionKeys, 
        ColumnMasterKeys, 
        Contracts, 
        DatabaseRoles, 
        DatabaseTriggers, 
        Defaults, 
        ExtendedProperties, 
        ExternalDataSources, 
        ExternalFileFormats, 
        ExternalTables, 
        Filegroups, 
        FileTables, 
        FullTextCatalogs, 
        FullTextStoplists, 
        MessageTypes, 
        PartitionFunctions, 
        PartitionSchemes, 
        Permissions, 
        Queues, 
        RemoteServiceBindings, 
        RoleMembership, 
        Rules, 
        ScalarValuedFunctions, 
        SearchPropertyLists, 
        SecurityPolicies, 
        Sequences, 
        Services, 
        Signatures, 
        StoredProcedures, 
        SymmetricKeys, 
        Synonyms, 
        Tables, 
        TableValuedFunctions, 
        UserDefinedDataTypes, 
        UserDefinedTableTypes, 
        ClrUserDefinedTypes, 
        Users, 
        Views, 
        XmlSchemaCollections, 
        Audits, 
        Credentials, 
        CryptographicProviders, 
        DatabaseAuditSpecifications, 
        DatabaseScopedCredentials, 
        Endpoints, 
        ErrorMessages, 
        EventNotifications, 
        EventSessions, 
        LinkedServerLogins, 
        LinkedServers, 
        Logins, 
        Routes, 
        ServerAuditSpecifications, 
        ServerRoleMembership, 
        ServerRoles, 
        ServerTriggers
    }
}
