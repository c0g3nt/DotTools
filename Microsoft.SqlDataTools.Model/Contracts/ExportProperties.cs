using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Microsoft.SqlDataTools.Model
{
    public class ExportProperties
    {

        /// <summary>
        /// Specifies the command timeout in seconds when executing queries against SQL Server.
        /// </summary>
        [Description("Specifies the command timeout in seconds when executing queries against SQL Server.")]
        [DefaultValue(60)]
        public int CommandTimeout { get; set; } = 60;

        /// <summary>
        /// Specifies the database lock timeout in seconds when executing queries against SQLServer. Use -1 to wait indefinitely.
        /// </summary>
        [Description("Specifies the database lock timeout in seconds when executing queries against SQLServer. Use -1 to wait indefinitely.")]
        [DefaultValue(60)]
        public int DatabaseLockTimeout { get; set; } = 60;

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
        /// Specifies what the target engine version is expected to be. This affects whether to allow objects supported by Azure SQL Database servers with V12 capabilities, such as memory-optimized tables, in the generated bacpac.
        /// </summary>
        [Description("Specifies what the target engine version is expected to be. This affects whether to allow objects supported by Azure SQL Database servers with V12 capabilities, such as memory-optimized tables, in the generated bacpac.")]
        [DefaultValue(EngineVersionValue.Latest)]
        public EngineVersionValue TargetEngineVersion { get; set; }

        /// <summary>
        /// Specifies whether the supported full-text document types for Microsoft Azure SQL Database v12 should be verified.
        /// </summary>
        [Description("Specifies whether the supported full-text document types for Microsoft Azure SQL Database v12 should be verified.")]
        [DefaultValue(typeof(bool?), null)]
        public bool? VerifyFullTextDocumentTypesSupported { get; set; }

    }
}
