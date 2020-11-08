using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Linq;

namespace Microsoft.SqlDataTools.Model
{
    public static class XmlExtensions
    {



        private static IEnumerable<XElement> AsXElements(IEnumerable<SqlCmdVariable> variables)
        {
            if (variables == null)
                return XElement.EmptySequence;
            return variables.Select(variab => variab.AsXElement());

        }
        private static IEnumerable<XElement> PropertiesToXElements(object input)
        {
            if (input == null)
                return null;

            return input.GetType().
                GetProperties().
                Where(p => typeof(DeploymentProperties).IsAssignableFrom(p.PropertyType) == false &&
                          typeof(IEnumerable<SqlCmdVariable>).IsAssignableFrom(p.PropertyType) == false).
                Select(p=> new { Property = p, Value = p.GetValue(input)}).
                Where(elem => DefaultChecker.IsDefault(elem.Value, elem.Property) == false).
                Select(elem => new XElement(XName.Get(elem.Property.Name), elem.Value)).
                Where(elem => elem.IsEmpty == false);
        }



        public static T Parse<T>(T sqlPackageParmas, XDocument xdoc) where T : ISqlPackageParameters
        {
            if (xdoc == null)
                return sqlPackageParmas;

            var projelem = xdoc.Element("Project");
            var propgroupelem = projelem.Element("PropertyGroup");
            if (propgroupelem != null)
            {
                var paramprops = typeof(T).GetProperties().ToDictionary(p => p.Name, p => p);
                var propprops = sqlPackageParmas.Properties.GetType().GetProperties().ToHashSet().ToDictionary(p => p.Name, p => p);

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
                        assignmenttarget = sqlPackageParmas.Properties;
                    }
                    else
                        continue;

                    prop.SetValue(sqlPackageParmas, item.Value);
                }
            }
            var itemgroupelem = projelem.Element("ItemGroup");
            if (itemgroupelem == null)
            {
                var vars = new List<SqlCmdVariable>();

                foreach (var item in itemgroupelem.Elements("SqlCmdVariable"))
                {
                    vars.Add(new SqlCmdVariable().Parse(item));
                }
            }
            return sqlPackageParmas;
        }
        public static XDocument AsXDocument(
            this ISqlPackageParameters deployReportParameters,
            FormattingOptions options = FormattingOptions.IgnoreDefaults)
        {
            if (deployReportParameters == null)
                return null;

            XDocument xdoc =
                new XDocument(
                    new XDeclaration("1.0", "utf-8", null));

            XElement root = new XElement(XName.Get("Project"));

            xdoc.Add(root);

            XAttribute toolsversAttr =
                new XAttribute(
                    XName.Get(nameof(DeployReportParameters.ToolsVersion)),
                    deployReportParameters.ToolsVersion);

            root.Add(toolsversAttr);

            XElement propgroup = new XElement(XName.Get("PropertyGroup"));
            root.Add(propgroup);

            HashSet<string> exclusions = new HashSet<string>(new string[]
            {
                nameof(ISqlPackageParameters.ToolsVersion),
                nameof(ISqlPackageParameters.Properties),
                nameof(ISqlPackageParameters.Variables)
            });

            propgroup.Add(PropertiesToXElements(deployReportParameters).
                Where(elem => !exclusions.Contains(elem.Name.ToString())));

            propgroup.Add(PropertiesToXElements(deployReportParameters.Properties));

            XElement itemgroup = new XElement(XName.Get("ItemGroup"));
            root.Add(itemgroup);
            itemgroup.Add(AsXElements(deployReportParameters.Variables));

            return xdoc;
        }
        public static void SaveXml(
            this ISqlPackageParameters param,
           string filename,
           FormattingOptions options = FormattingOptions.IgnoreDefaults) =>
            param.
            AsXDocument(options).
            Save(filename);
    }
}
