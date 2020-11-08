using Microsoft.SqlDataTools.Model.Annotation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Linq;

namespace Microsoft.SqlDataTools.Model
{
    internal static class XHelper
    {
        public static IEnumerable<XElement> PropertiesToProfileXElements(
            object input)
        {
            if (input == null)
                return null;

            return input.GetType().
                GetProperties().
                Select(p => new 
                { 
                    Prop = p, 
                    Value = p.GetValue(input) 
                }).
                Where(
                    elem => SerializationHelper.
                            ShouldSerializeProperty(
                                input, 
                                elem.Prop, 
                                elem.Value,
                                SerializationHelper.
                                SerializationType.X)).
                Select(
                    elem => new XElement(
                                XName.Get(elem.Prop.Name), 
                                elem.Value)).
                Where(elem => elem.IsEmpty == false);
        }  
    }
}
