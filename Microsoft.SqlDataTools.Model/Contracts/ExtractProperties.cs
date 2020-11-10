using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Microsoft.SqlDataTools.Model
{
    public class ExtractProperties
    {

        /// <summary>
        /// Specifies the command timeout in seconds when executing queries against SQL Server.
        /// </summary>
        [Description("Specifies the command timeout in seconds when executing queries against SQL Server.")]
        [DefaultValue(60)]
        public int CommandTimeout { get; set; } = 60;

        /// <summary>
        /// Defines the Application description to be stored in the DACPAC metadata.
        /// </summary>
        [Description("Defines the Application description to be stored in the DACPAC metadata.")]
        [DefaultValue(typeof(string), null)]
        public string DacApplicationDescription { get; set; }

        /// <summary>
        /// Defined the Application name to be stored in the DACPAC metadata. The default value is the database name.
        /// </summary>
        [Description("Defined the Application name to be stored in the DACPAC metadata. The default value is the database name.")]
        [DefaultValue(typeof(string), null)]
        public string DacApplicationName { get; set; }

        /// <summary>
        /// Defines the major version to be stored in the DACPAC metadata.
        /// </summary>
        [Description("Defines the major version to be stored in the DACPAC metadata.")]
        [DefaultValue(1)]
        public int DacMajorVersion { get; set; } = 1;

        /// <summary>
        /// Defines the minor version to be stored in the DACPAC metadata.
        /// </summary>
        [Description("Defines the minor version to be stored in the DACPAC metadata.")]
        [DefaultValue(0)]
        public int DacMinorVersion { get; set; } = 0;

        /// <summary>
        /// Specifies the database lock timeout in seconds when executing queries against SQLServer. Use -1 to wait indefinitely.
        /// </summary>
        [Description("Specifies the database lock timeout in seconds when executing queries against SQLServer. Use -1 to wait indefinitely.")]
        [DefaultValue(60)]
        public int DatabaseLockTimeout { get; set; } = 60;

        /// <summary>
        /// Indicates whether data from all user tables is extracted. If 'true', data from all user tables is extracted, and you cannot specify individual user tables for extracting data. If 'false', specify one or more user tables to extract data from.
        /// </summary>
        [Description("Indicates whether data from all user tables is extracted. If 'true', data from all user tables is extracted, and you cannot specify individual user tables for extracting data. If 'false', specify one or more user tables to extract data from.")]
        [DefaultValue(typeof(bool?), null)]
        public bool? ExtractAllTableData { get; set; }

        /// <summary>
        /// If true, only extract application-scoped objects for the specified source. If false, extract all objects for the specified source.
        /// </summary>
        [Description("If true, only extract application-scoped objects for the specified source. If false, extract all objects for the specified source.")]
        [DefaultValue(true)]
        public bool ExtractApplicationScopedObjectsOnly { get; set; } = true;

        /// <summary>
        /// If true, extract login, server audit, and credential objects referenced by source database objects.
        /// </summary>
        [Description("If true, extract login, server audit, and credential objects referenced by source database objects.")]
        [DefaultValue(true)]
        public bool ExtractReferencedServerScopedElements { get; set; } = true;

        /// <summary>
        /// Specifies whether usage properties, such as table row count and index size, will be extracted from the database.
        /// </summary>
        [Description("Specifies whether usage properties, such as table row count and index size, will be extracted from the database.")]
        [DefaultValue(typeof(bool?), null)]
        public bool? ExtractUsageProperties { get; set; }

        /// <summary>
        /// Specifies whether extended properties should be ignored.
        /// </summary>
        [Description("Specifies whether extended properties should be ignored.")]
        [DefaultValue(typeof(bool?), null)]
        public bool? IgnoreExtendedProperties { get; set; }

        /// <summary>
        /// Specifies whether permissions should be ignored.
        /// </summary>
        [Description("Specifies whether permissions should be ignored.")]
        [DefaultValue(true)]
        public bool IgnorePermissions { get; set; } = true;

        /// <summary>
        /// Specifies whether relationships between users and logins are ignored.
        /// </summary>
        [Description("Specifies whether relationships between users and logins are ignored.")]
        [DefaultValue(typeof(bool?), null)]
        public bool? IgnoreUserLoginMappings { get; set; }

        /// <summary>
        /// Specifies the long running command timeout in seconds when executing queries against SQL Server. Use 0 to wait indefinitely.
        /// </summary>
        [Description("Specifies the long running command timeout in seconds when executing queries against SQL Server. Use 0 to wait indefinitely.")]
        [DefaultValue(typeof(int?), null)]
        public int? LongRunningCommandTimeout { get; set; }

        /// <summary>
        /// Specifies the type of backing storage for the schema model used during extraction.
        /// </summary>
        [Description("Specifies the type of backing storage for the schema model used during extraction.")]
        [DefaultValue(StorageValue.File)]
        public StorageValue Storage { get; set; } = StorageValue.File;

        /// <summary>
        /// Indicates the table from which data will be extracted. Specify the table name with or without the brackets surrounding the name parts in the following format: schema_name.table_identifier. This option may be specified multiple times.
        /// </summary>
        [Description("Indicates the table from which data will be extracted. Specify the table name with or without the brackets surrounding the name parts in the following format: schema_name.table_identifier. This option may be specified multiple times.")]
        [DefaultValue(typeof(string), null)]
        public string TableData { get; set; }

        /// <summary>
        /// Specifies the temporary directory used to buffer table data before being written to the package file.
        /// </summary>
        [Description("Specifies the temporary directory used to buffer table data before being written to the package file.")]
        [DefaultValue(typeof(string), null)]
        public string TempDirectoryForTableData { get; set; }

        /// <summary>
        /// Specifies whether the extracted dacpac should be verified.
        /// </summary>
        [Description("Specifies whether the extracted dacpac should be verified.")]
        [DefaultValue(typeof(bool?), null)]
        public bool? VerifyExtraction { get; set; }


    }

}
