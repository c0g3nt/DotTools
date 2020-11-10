using Microsoft.SqlDataTools.Model.Annotation;
using Microsoft.SqlDataTools.Model.Extensions;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Microsoft.SqlDataTools.Model
{
    internal static class SerializationHelper
    {
        public enum SerializationType
        {
            XElement,
            CommandPromptArgument
        }
        public static bool ShouldSerializeProperty(
            object input, 
            PropertyInfo prop, 
            object value,
            SerializationType serializationType)
        {
            return !(
                input == null ||
                prop == null ||
                value == null ||
                (   serializationType == SerializationType.XElement && 
                    prop.GetCustomAttribute<XIgnoreAttribute>() != null
                ) ||
                (   serializationType == SerializationType.CommandPromptArgument && 
                    prop.GetCustomAttribute<CmdArgIgnoreAttribute>() != null
                ) ||
                value.IsDefault(prop)
                );
        }
    }
}
