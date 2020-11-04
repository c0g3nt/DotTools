using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Reflection;
using System.Collections;

namespace Microsoft.SqlDataTools.Model
{
   public  static class SqlPackageParametersFormatter
    {
        public static XDocument AsXDocument(ISqlPackageParameters deployReportParameters, FormattingOptions options)
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
                    XName.Get(nameof(deployReportParameters.ToolsVersion)),
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

        private static IEnumerable<XElement> AsXElements(IEnumerable<SqlCmdVariable> variables)
        {
            if (variables == null)
                return XElement.EmptySequence;
            return variables.Select(variab =>
            {
                var elem = new XElement(XName.Get("SqlCmdVariable"));
                elem.Add(new XAttribute(XName.Get("Include"), variab.Name));
                elem.Add(new XElement(XName.Get("Value"), variab.Value));
                return elem;
            });

        }
        private static IEnumerable<XElement> PropertiesToXElements(object input)
        {
            if (input == null)
                return null;

            return input.GetType().
                GetProperties().
                 Select(prop => new
                 {
                     Name = prop.Name,
                     PropType = prop.PropertyType,
                     DefaultValueAttr = prop.GetCustomAttribute<DefaultValueAttribute>(),
                     InputValue = prop.GetValue(input)
                 }).
                 Where(elem => (elem.DefaultValueAttr == null &&
                 !IsTypeDefault(elem.PropType, elem.InputValue)) ||
                 (elem.DefaultValueAttr != null &&
                 !Equals(elem.DefaultValueAttr.Value, elem.InputValue))).
                 Select(elem=> new XElement(XName.Get(elem.Name),elem.InputValue)).
                 Where(elem=> elem.IsEmpty == false);

        }
        private static bool IsTypeDefault(Type type,object value)
        {
            if (type == typeof(string))
                return string.IsNullOrEmpty(value as string);
            else if(type.IsPrimitive || type.IsValueType)
                return Activator.CreateInstance(type).Equals(value);
            else if (typeof(IEnumerable).IsAssignableFrom(type))
                return value == null || 
                    (value as IEnumerable).GetEnumerator().MoveNext();
            else if (type.IsAbstract)
                return value == null;
            else if (type.IsClass == true ||
                    type.IsInterface == true &&
                    value == null)
                return true;
            else
                return Activator.CreateInstance(type).Equals(value);

        }
    }
}
