using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.SqlDataTools.Model.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
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
            var doc = (deployparams as ISqlPackageParameters).AsXDocument();
            var outputfile = "output.xml";
            (deployparams as ISqlPackageParameters).SaveXml(outputfile);
            System.Diagnostics.Process.Start(
                "C:\\Program Files (x86)\\Notepad++\\notepad++.exe",
                outputfile);
        }
    }
}
