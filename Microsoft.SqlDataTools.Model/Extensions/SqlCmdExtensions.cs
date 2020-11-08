using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Microsoft.SqlDataTools.Model
{
    public static class SqlCmdExtensions
    {
        public static IEnumerable<XElement> AsXElements(
            this IEnumerable<SqlCmdVariable> variables)
        {
            if (variables == null)
                return XElement.EmptySequence;
            return variables.Select(variab => variab.AsXElement());

        }
        public static  XElement AsXElement(this SqlCmdVariable sqlCmdVariable)
        {
            var elem = new XElement(XName.Get("SqlCmdVariable"));
            elem.Add(new XAttribute(XName.Get("Include"), sqlCmdVariable.Name));
            elem.Add(new XElement(XName.Get("Value"), sqlCmdVariable.Value));
            return elem;
        }
        public static  string AsCommandLineArgument(
            this SqlCmdVariable sqlCmdVariable)
        {
            return string.Concat(
                "/v:", 
                sqlCmdVariable.Name, 
                "=", 
                sqlCmdVariable.Value);
        }

        public static SqlCmdVariable Parse(
            this SqlCmdVariable sqlCmdVariable,
            XElement xElement)
        {
            if (xElement == null)
                return sqlCmdVariable;

            if (xElement.Name != "SqlCmdVariable")
                throw new ArgumentOutOfRangeException(
                    "The provided element does not have a valid signature");

            XAttribute xattrInclude;
            if ((xattrInclude = xElement.Attribute("Include")) == null)
                throw new ArgumentOutOfRangeException(
                    "The XElement doesnot have an Include attribute");

            XElement xelemValue;
            if ((xelemValue = xElement.Element("Value")) == null)
                throw new ArgumentOutOfRangeException(
                    "The XElement does not have a value element");

            sqlCmdVariable.Name = xattrInclude.Value;
            sqlCmdVariable.Value = xelemValue.Value;

            return sqlCmdVariable;
        }
    }
}
