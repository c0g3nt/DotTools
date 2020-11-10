using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using static Microsoft.SqlDataTools.Model.DefaultValueHelper;

namespace Microsoft.SqlDataTools.Model.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestAsXDocument()
        {
            var deployprops = new DeploymentProperties()
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
                Properties = deployprops,
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
            var deployprops = new DeploymentProperties()
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
                Properties = deployprops,
                Variables = variables
            };
            var cmdargs = (deployparams as ISqlPackageParameters).AsSqlPackageCmdArgs().ToList();
            System.Diagnostics.Trace.WriteLine(string.Join(" ",cmdargs));
        }
        [TestMethod]
        public void ExtractCommonProperties()
        {
            var paramtypes = new Type[]
            {
                typeof(DeploymentParameters),
                typeof(ScriptParameters),
                typeof(PublishParameters),
                typeof(ImportParameters),
                typeof(ExportParameters),
                typeof(ExtractParameters)
            };
            var proptypes = new Type[]
            {
                typeof(DeploymentProperties),
                typeof(ImportProperties),
                typeof(ExportProperties),
                typeof(ExtractProperties)
            };

            var commonparams =
                paramtypes.
                SelectMany(paramtype => paramtype.GetProperties().
                    Select(p => new { Type = paramtype, Property = p }).
                    ToArray()).
                GroupBy(elem=> elem.Property.Name).
                ToArray();

            var commonprops =
                paramtypes.
                SelectMany(paramtype => paramtype.GetProperties().
                    Select(p => new { Type = paramtype, Property = p }).
                    ToArray()).
                GroupBy(elem => elem.Property.Name).
                ToArray();

            string operationname;

          
       
            Trace.WriteLine("Parameters:");

            foreach (var item in commonparams.
                OrderBy(grp=>grp.Key).
                Where(grp=> grp.Count() > 1))
            {

                IEnumerable<string> outputlist;
                string outputname;
                if (item.Count() < (paramtypes.Length / 2))
                {
                    outputname = "Include";
                    outputlist =
                         item.
                         Select(elem => elem.Type.Name).
                         OrderBy(elem => elem);
                }
                else
                {
                    outputname = "Exclude";
                    outputlist =
                        paramtypes.Except(item.Select(itm => itm.Type)).
                        Select(elem => elem.Name).
                        OrderBy(elem => elem);
                }
                string outputliststr = string.Join(";", outputlist);

                Trace.WriteLine($"{item.Key}:{outputname}={outputliststr}");
            }

            Trace.WriteLine("Properties:");
            foreach (var item in commonprops.OrderBy(grp => grp.Key))
            {
                Trace.WriteLine(
                    $"{item.Key}:" +
                    $"{string.Join(";", item.Select(elem => elem.Type.Name).OrderBy(elem => elem))}");
            }
        }
    }
}
