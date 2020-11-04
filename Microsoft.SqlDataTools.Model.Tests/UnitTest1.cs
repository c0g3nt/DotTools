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

            var deployparams = new DeployReportParameters()
            {
                TargetServerName = "DEV20\\MAININSTANCE",
                TargetDatabaseName = "Hospital",
                Properties = deployprops,
                Variables = variables
            };
            var doc = XElementizer.GetDocument(deployparams);
            var outputfile = "output.xml";
            doc.Save(outputfile);
            System.Diagnostics.Process.Start(
                "C:\\Program Files (x86)\\Notepad++\\notepad++.exe",
                outputfile);
        }
    }
}
