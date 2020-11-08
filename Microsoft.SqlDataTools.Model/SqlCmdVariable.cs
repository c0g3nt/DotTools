using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Microsoft.SqlDataTools.Model
{
    public struct SqlCmdVariable 
    {
        public SqlCmdVariable(string name, string value)
        {
            Name = name;
            Value = value;
        }
        public string Name { get; set; }
        public string Value { get; set; }

        internal string AsCommandLineArgument()
        {
            return string.Concat("/v:", Name, "=", Value);
        }
        internal  XElement AsXElement()
        {
            var elem = new XElement(XName.Get("SqlCmdVariable"));
            elem.Add(new XAttribute(XName.Get("Include"), Name));
            elem.Add(new XElement(XName.Get("Value"), Value));
            return elem;
        }
        public  SqlCmdVariable Parse(XElement xElement)
        {
            if (xElement == null)
                return this;

            if (xElement.Name != "SqlCmdVariable")
                throw new ArgumentOutOfRangeException("The provided element does not have a valid signature");

            XAttribute xattrInclude;
            if ((xattrInclude = xElement.Attribute("Include")) == null)
                throw new ArgumentOutOfRangeException("The XElement doesnot have an Include attribute");

            XElement xelemValue;
            if ((xelemValue = xElement.Element("Value")) == null)
                throw new ArgumentOutOfRangeException("The XElement does not have a value element");

            this.Name = xattrInclude.Value;
            this.Value = xelemValue.Value;

            return this;
        }
    }
}
