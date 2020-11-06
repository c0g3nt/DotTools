using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Reflection;
using System.Collections;
using System.Runtime.CompilerServices;

namespace Microsoft.SqlDataTools.Model
{

    public static partial class Extensions
    {
        public enum UserDefinedProfileBehavior
        {
            PrioritizeUserDefined,
            Prioritize
        }


        public static XElement AsXElement(this SqlCmdVariable sqlCmdVariable)
        {
            var elem = new XElement(XName.Get("SqlCmdVariable"));
            elem.Add(new XAttribute(XName.Get("Include"), sqlCmdVariable.Name));
            elem.Add(new XElement(XName.Get("Value"), sqlCmdVariable.Value));
            return elem;
        }
        public static SqlCmdVariable Parse(this SqlCmdVariable sqlCmdVariable, XElement xElement)
        {
            if (xElement == null)
                return sqlCmdVariable;

            if (xElement.Name != "SqlCmdVariable")
                throw new ArgumentOutOfRangeException("The provided element does not have a valid signature");

            XAttribute xattrInclude;
            if ((xattrInclude = xElement.Attribute("Include")) == null)
                throw new ArgumentOutOfRangeException("The XElement doesnot have an Include attribute");

            XElement xelemValue;
            if ((xelemValue = xElement.Element("Value")) == null)
                throw new ArgumentOutOfRangeException("The XElement does not have a value element");

            sqlCmdVariable.Name = xattrInclude.Value;
            sqlCmdVariable.Value = xelemValue.Value;

            return sqlCmdVariable;
        }



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
                 Select(elem => new XElement(XName.Get(elem.Name), elem.InputValue)).
                 Where(elem => elem.IsEmpty == false);
        }
        private static bool IsTypeDefault(Type type, object value)
        {
            if (type == typeof(string))
                return string.IsNullOrEmpty(value as string);
            else if (type.IsPrimitive || type.IsValueType)
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

        public static IEnumerable<string> AsCommandLineArguments(
                   this ISqlPackageParameters param,
                   bool? useProfile = null,
                   bool? skipValuesDefinedInProfile = true)
        {
            var doc = AsXDocument(param, FormattingOptions.IgnoreDefaults);
            if (doc == null)
                throw new ArgumentOutOfRangeException();

            var parampropinfos = param.
                    GetType().
                    GetProperties();

            bool hasprofile =
                parampropinfos.Any(elem => elem.Name == "Profile");
            //if(hasprofile == false)
            //{
            var paramprops =
                new HashSet<XName>(
                    param.
                    GetType().
                    GetProperties().
                    Select(p => XName.Get(p.Name)));


            var propprops =
                new HashSet<XName>(
                    param.
                    Properties.
                    GetType().
                    GetProperties().
                    Select(p => XName.Get(p.Name)));

            return doc.Element("Project").
                Element("PropertyGroup").
                Elements().
                Select(elem =>
                    string.Concat(
                        "/",
                        paramprops.Contains(elem.Name) ? "" : "p:",
                        elem.Name.ToString(),
                        "=",
                        elem.Value)
                    )?.DefaultIfEmpty().
                    Concat(
                        doc.Root.Elements("ItemGroup").
                        SelectMany(elem => elem.Elements("SqlCmdVariable")).
                        Select(elem =>
                            string.Concat(
                                "/v:",
                                elem.Attribute("Include").Value,
                                "=",
                                elem.Element("Value").Value))).
                    Where(elem => string.IsNullOrWhiteSpace(elem) == false);
            //}
            //else
            //{
            //    return null;
            //}


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
                    vars.Add(Parse(new SqlCmdVariable(), item));
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
