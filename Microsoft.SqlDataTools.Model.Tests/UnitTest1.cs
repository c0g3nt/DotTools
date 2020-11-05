using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Microsoft.SqlDataTools.Model.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestAsXDocument()
        {
            var deployprops = new DeployReportProperties()
            {
                IncludeCompositeObjects = true,
                DropConstraintsNotInSource = false,
                DropObjectsNotInSource  = true
            };
            var variables = new SqlCmdVariable[]
            {
                new SqlCmdVariable("Hospital","Hospital"),
                new SqlCmdVariable("IncludedModules","ALL"),
                new SqlCmdVariable("ExcludedModules","NONE")
            };

             ISqlPackageParameters deployparams = new DeployReportParameters()
            {
                TargetServerName = "DEV20\\MAININSTANCE",
                TargetDatabaseName = "Hospital",
                DeployReportProperties = deployprops,
                Variables = variables
            };
            var doc = deployparams.AsXDocument();
          
            var outputfile = "output.xml";

            deployparams.SaveXml(outputfile);

            System.Diagnostics.Process.Start(
                "C:\\Program Files (x86)\\Notepad++\\notepad++.exe",
                outputfile);
        }

        [TestMethod]
        public void TestAsSqlCmdArgs()
        {
            var deployprops = new DeployReportProperties()
            {
                IncludeCompositeObjects = true,
                DropConstraintsNotInSource = false,
                DropObjectsNotInSource = true
            };
            var variables = new SqlCmdVariable[]
            {
                new SqlCmdVariable("Hospital","Hospital"),
                new SqlCmdVariable("IncludedModules","ALL"),
                new SqlCmdVariable("ExcludedModules","NONE")
            };

            ISqlPackageParameters deployparams = new DeployReportParameters()
            {
                TargetServerName = "DEV20\\MAININSTANCE",
                TargetDatabaseName = "Hospital",
                DeployReportProperties = deployprops,
                Variables = variables
            };
            var cmdargs = (deployparams as ISqlPackageParameters).AsCommandLineArgs().ToList();
            System.Diagnostics.Trace.WriteLine(string.Join(" ",cmdargs));
        }
    }
}
