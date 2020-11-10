using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Microsoft.SqlDataTools.Model
{
    /// <summary>
    /// Properties specific to the Import action
    /// </summary>
    [Description("Properties specific to the Import action")]
    public class ImportProperties
    {
        /// <summary>
        /// Specifies the command timeout in seconds when executing queries against SQL Server.
        /// </summary>
        [Description("Specifies the command timeout in seconds when executing queries against SQL Server.")]
        [DefaultValue(60)]
        public int CommandTimeout { get; set; } = 60;

        /// <summary>
        /// Defines the edition of an Azure SQL Database.
        /// </summary>
        [Description("Defines the edition of an Azure SQL Database.")]
        [DefaultValue(DatabaseEditionValue.Default)]
        public DatabaseEditionValue DatabaseEdition { get; set; } = DatabaseEditionValue.Default;

        /// <summary>
        /// Specifies the database lock timeout in seconds when executing queries against SQLServer. Use -1 to wait indefinitely.
        /// </summary>
        [Description("Specifies the database lock timeout in seconds when executing queries against SQLServer. Use -1 to wait indefinitely.")]
        [DefaultValue(60)]
        public int DatabaseLockTimeout { get; set; } = 60;

        /// <summary>
        /// Defines the maximum size in GB of an Azure SQL Database.
        /// </summary>
        [Description("Defines the maximum size in GB of an Azure SQL Database.")]
        [DefaultValue(typeof(int?), null)]
        public int? DatabaseMaximumSize { get; set; }

        /// <summary>
        /// Defines the performance level of an Azure SQL Database such as"P0" or "S1".
        /// </summary>
        [Description("Defines the performance level of an Azure SQL Database such as\"P0\" or \"S1\".")]
        [DefaultValue(typeof(string), null)]
        public string DatabaseServiceObjective { get; set; }

        /// <summary>
        /// Specifies deployment contributor arguments for the deployment contributors. This should be a semi-colon delimited list of values.
        /// </summary>
        [Description("Specifies deployment contributor arguments for the deployment contributors. This should be a semi-colon delimited list of values.")]
        [DefaultValue(typeof(string), null)]
        public string ImportContributorArguments { get; set; }

        /// <summary>
        /// Specifies the deployment contributors, which should run when the bacpac is imported. This should be a semi-colon delimited list of fully qualified build contributor names or IDs.
        /// </summary>
        [Description("Specifies the deployment contributors, which should run when the bacpac is imported. This should be a semi-colon delimited list of fully qualified build contributor names or IDs.")]
        [DefaultValue(typeof(string), null)]
        public string ImportContributors { get; set; }

        /// <summary>
        /// Specifies paths to load additional deployment contributors. This should be a semi-colon delimited list of values.
        /// </summary>
        [Description("Specifies paths to load additional deployment contributors. This should be a semi-colon delimited list of values.")]
        [DefaultValue(typeof(string), null)]
        public string ImportContributorPaths { get; set; }

        /// <summary>
        /// Specifies the long running command timeout in seconds when executing queries against SQL Server. Use 0 to wait indefinitely.
        /// </summary>
        [Description("Specifies the long running command timeout in seconds when executing queries against SQL Server. Use 0 to wait indefinitely.")]
        [DefaultValue(typeof(int?), null)]
        public int? LongRunningCommandTimeout { get; set; }

        /// <summary>
        /// Specifies how elements are stored when building the database model. For performance reasons the default is InMemory. For large databases, File backed storage is required.
        /// </summary>
        [Description("Specifies how elements are stored when building the database model. For performance reasons the default is InMemory. For large databases, File backed storage is required.")]
        [DefaultValue(StorageValue.Memory)]
        public StorageValue Storage { get; set; } = StorageValue.Memory;

    }
}
