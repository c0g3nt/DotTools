using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Microsoft.SqlDataTools.Model
{
    public static class CommandLineExtensions
    {
        public static IEnumerable<string> AsCommandLineArguments(
           this ISqlPackageParameters param,
           bool? useProfile = null,
           bool? skipValuesDefinedInProfile = true)
        {
            if (param == null)
                return null;

            var paramargs =
                AsCommandLineArguments(
                    param,
                    p => typeof(DeploymentProperties).IsAssignableFrom(p.PropertyType) == false &&
                    typeof(IEnumerable<SqlCmdVariable>).IsAssignableFrom(p.PropertyType) == false);

            var propargs =
                AsCommandLineArguments(
                    param.Properties,
                    null);

            var varargs =
                param.Variables?.Select(v => v.AsCommandLineArgument());

            return paramargs.DefaultIfEmpty().
                Concat(propargs.DefaultIfEmpty()).
                Concat(varargs.DefaultIfEmpty());
        }

        private static IEnumerable<string> AsCommandLineArguments(object input, Func<PropertyInfo, bool> predicate)
        {
            return input.
                GetType().
                GetProperties().
                Where(p => predicate == null || predicate.Invoke(p) == true).
                Select(p=> new {Property = p, Value = p.GetValue(input)}).
                Where(elem => DefaultChecker.IsDefault(elem.Value,elem.Property) == false).
                Select(elem => new
                {
                    Name = elem.Property.Name,
                    Value = elem.Value?.ToString(),
                    ArgAttr =
                    elem.Property.GetCustomAttributes().
                    FirstOrDefault(
                        a =>
                        typeof(SqlCmdArgumentAttribute).
                        IsAssignableFrom(
                            a.GetType())) as SqlCmdArgumentAttribute
                }).
                Select(elem => new
                {
                    Prefix = elem.ArgAttr?.Prefix ?? "",
                    Name = elem.ArgAttr?.ShortForm ?? elem.Name,
                    Seperator = elem.ArgAttr?.NameValueSeperator ?? ":",
                    elem.Value
                }).
                Select(elem => GetSanitizedCmdString(string.Concat(elem.Prefix, elem.Name, elem.Seperator, elem.Value)));
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
