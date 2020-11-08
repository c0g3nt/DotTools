using Microsoft.SqlDataTools.Model.Annotation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Microsoft.SqlDataTools.Model
{
    internal static class CmdHelper
    {
        public static IEnumerable<string> PropertiesToSqlCmdArgs(
            object input,
            bool preferShortForm = true)
        {
            return input.
                GetType().
                GetProperties().
                Select(p=> new { Prop = p, Value = p.GetValue(input)}).
                Where(elem=> 
                    SerializationHelper.ShouldSerializeProperty(
                        input,
                        elem.Prop,
                        elem.Value,
                        SerializationHelper.SerializationType.CmdArg)).
                Select(elem => new
                {
                    Name = elem.Prop.Name,
                    Value = elem.Value?.ToString(),
                    ArgAttr =
                    elem.Prop.GetCustomAttributes().
                    FirstOrDefault(
                        a =>
                        typeof(SqlPackageCmdArgAttribute).
                        IsAssignableFrom(
                            a.GetType())) as SqlPackageCmdArgAttribute
                }).
                Select(elem => new
                {
                    Prefix = elem.ArgAttr?.Prefix ?? "",
                    Name =
                        ( preferShortForm ? 
                            elem.ArgAttr?.ShortForm : 
                            elem.ArgAttr?.LongForm
                         ) ?? 
                        elem.Name,
                    Seperator = 
                        elem.ArgAttr?.NameValueSeperator ?? 
                        ":",
                    elem.Value
                }).
                Select(elem => 
                    GetSanitizedCmdString(
                        string.Concat(
                            elem.Prefix, 
                            elem.Name, 
                            elem.Seperator, 
                            elem.Value)));
        }

        private static string GetSanitizedCmdString(string value)
        {
            if (string.IsNullOrEmpty(value))
                return value;

            value = value.Replace("\"", "\"\"");

            if (value.IndexOf(" ") > -1)
                value = string.Concat("\"", value, "\"");

            return value;
        }
    }
}
