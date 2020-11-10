using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Linq;

namespace Microsoft.SqlDataTools.Model
{
    public static class SqlPackageParametersExtensions
    {
        public static T LoadXml<T>(
            this T sqlPackageParmas, 
            XDocument xdoc) 
            where T : ISqlPackageParameters
        {
            if (xdoc == null)
                return sqlPackageParmas;

            var projelem = 
                xdoc.Element("Project");

            var propgroupelem = 
                projelem.Element("PropertyGroup");

            if (propgroupelem != null)
            {
                var paramprops = 
                    typeof(T).
                    GetProperties().
                    ToDictionary(
                        p => p.Name, 
                        p => p);

                var propprops =
                    sqlPackageParmas.
                    Properties.
                    GetType().
                    GetProperties().
                    ToDictionary(
                        p => p.Name, 
                        p => p);

                PropertyInfo prop = null;
                string itemname = null;
                object assignmenttarget = null;

                foreach (var item in propgroupelem.Elements())
                {
                    itemname = item.Name.ToString();

                    if (paramprops.ContainsKey(itemname))
                    {
                        prop = paramprops[itemname];
                        assignmenttarget = sqlPackageParmas;
                    }
                    else if (propprops.ContainsKey(itemname))
                    {
                        prop = propprops[itemname];
                        assignmenttarget = 
                            sqlPackageParmas.Properties;
                    }
                    else
                        continue;

                    prop.SetValue(
                        sqlPackageParmas, 
                        item.Value);
                }
            }

            var itemgroupelem = 
                projelem.Element("ItemGroup");

            if (itemgroupelem == null)
            {
                var vars = new List<SqlCmdVariable>();

                foreach (var item in itemgroupelem.
                                     Elements("SqlCmdVariable"))
                {
                    vars.
                        Add(new SqlCmdVariable().
                        Load(item));
                }
            }

            return sqlPackageParmas;
        }

        /// <summary>
        /// Creates an XDocument which is compatible with SqlPackage Profile.
        /// </summary>
        /// <param name="deployReportParameters"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static XDocument AsXDocument(
            this ISqlPackageParameters deployReportParameters,
            FormattingOptions options = 
                FormattingOptions.IgnoreDefaults)
        {
            if (deployReportParameters == null)
                return null;

            XDocument xdoc =
                new XDocument(
                    new XDeclaration("1.0", "utf-8", null));

            xdoc.Add(deployReportParameters.AsXElement(options));

            return xdoc;
        }

        public static XElement AsXElement(
        this ISqlPackageParameters deployReportParameters,
        FormattingOptions options = 
            FormattingOptions.IgnoreDefaults)
        {
            if (deployReportParameters == null)
                return null;

            XElement root = 
                new XElement(XName.Get("Project"));


            XAttribute toolsversAttr =
                new XAttribute(
                    XName.Get(
                        nameof(
                            DeployReportParameters.
                            ToolsVersion)),
                    deployReportParameters.ToolsVersion);

            root.Add(toolsversAttr);

            XElement propgroup = 
                new XElement(XName.Get("PropertyGroup"));

            root.Add(propgroup);

            HashSet<string> exclusions = 
                new HashSet<string>(new string[]
            {
                nameof(ISqlPackageParameters.ToolsVersion),
                nameof(ISqlPackageParameters.Properties),
                nameof(ISqlPackageParameters.Variables)
            });

            propgroup.Add(
                XmlHelper.PropertiesToProfileXElements(
                    deployReportParameters).
                Where(
                    elem => !exclusions.Contains(
                                elem.Name.ToString())));

            propgroup.Add(
                XmlHelper.PropertiesToProfileXElements(
                    deployReportParameters.Properties));

            XElement itemgroup = 
                new XElement(XName.Get("ItemGroup"));

            root.Add(itemgroup);

            itemgroup.Add(
                deployReportParameters.Variables.
                AsXElements());

            return root;
        }

        public static IEnumerable<string> AsSqlPackageCmdArgs(
           this ISqlPackageParameters param,
           bool? useProfile = null,
           bool? skipValuesDefinedInProfile = true)
        {
            if (param == null)
                return null;

            var paramargs =
                CommandLineArgumentHelper.PropertiesToSqlCmdArgs(param);

            var propargs =
                CommandLineArgumentHelper.PropertiesToSqlCmdArgs(
                    param.Properties);

            var varargs =
                param.Variables?.Select(
                    v => v.AsCommandLineArgument());

            return paramargs.DefaultIfEmpty().
                Concat(propargs.DefaultIfEmpty()).
                Concat(varargs.DefaultIfEmpty());
        }

        public static void SaveXml(
            this ISqlPackageParameters param,
           string filename,
           FormattingOptions options = 
            FormattingOptions.IgnoreDefaults) =>
            param.
            AsXDocument(options).
            Save(filename);
    }
}
