using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Reflection;
namespace Microsoft.SqlDataTools.Model
{
    static class XElementizer
    {
        static XDocument GetDocument(DeployReportParameters deployReportParameters)
        {
            if (deployReportParameters == null)
                return null;

            XDocument xdoc = new XDocument(new XDeclaration("1.0", "utf-8", null));
            XElement root = xdoc.Root;
            xdoc.Root.Name = "Project";
           
            XAttribute toolsversAttr = new XAttribute(XName.Get(nameof(deployReportParameters.ToolsVersion)),deployReportParameters.ToolsVersion);
            root.Add(toolsversAttr);
            XAttribute xmlnsAttr = new XAttribute(XName.Get("xmlns"), "http://schemas.microsoft.com/developer/msbuild/2003");
            root.Add(xmlnsAttr);

            XElement propgroup = new XElement(XName.Get("PropertyGroup"));
            root.Add(propgroup);

            HashSet<string> exclusions = new HashSet<string>(new string[]
            {
                nameof(DeployReportParameters.ToolsVersion),
                nameof(DeployReportParameters.Properties),
                nameof(DeployReportParameters.Variables)
            });

            propgroup.Add(PropertiesToXElements<DeployReportParameters>(deployReportParameters).
                Where(elem => !exclusions.Contains(elem.Name.ToString())));
            propgroup.Add(PropertiesToXElements<DeployReportProperties>(deployReportParameters.Properties));

            XElement itemgroup = new XElement(XName.Get("ItemGroup"));
            root.Add(itemgroup);
            itemgroup.Add(AsXElements(deployReportParameters.Variables));
            
            return xdoc;
        }

        private static IEnumerable<XElement> AsXElements(IEnumerable<SqlCmdVariable> variables)
        {
            if (variables == null)
                return XElement.EmptySequence;
            return variables.Select(variab => new XElement(XName.Get(variab.Name), variab.Value));

        }
        private static IEnumerable<XElement> PropertiesToXElements<T>(T input)
        {
            if (input == null)
                return null;

            return typeof(T).
                GetProperties().
                 Select(prop => new
                 {
                     Name = prop.Name,
                     PropType = prop.PropertyType,
                     DefaultValueAttr = prop.GetCustomAttribute<DefaultValueAttribute>(),
                     InputValue = prop.GetValue(input)
                 }).
                 Where(elem => elem.DefaultValueAttr == null &&
                 IsTypeDefault(elem.PropType, elem.InputValue) ||
                 Equals(elem.DefaultValueAttr.Value, elem.InputValue)).
                 Select(elem=> new XElement(XName.Get(elem.Name),elem.InputValue));

        }
        private static bool IsTypeDefault(Type type,object value)
        {
            if (type == typeof(string))
                return string.IsNullOrEmpty(value as string);
            else if (type.IsByRef && value == null)
                return true;
            else
                return Activator.CreateInstance(type).Equals(value);

        }
    }
}
