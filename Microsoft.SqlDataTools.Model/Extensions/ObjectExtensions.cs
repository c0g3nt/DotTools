using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace Microsoft.SqlDataTools.Model.Extensions
{
    internal static class ObjectExtensions
    {
        public static bool IsDefault(
            this object value, 
            PropertyInfo propertyInfo)
        {

            if (propertyInfo == null)
                throw new ArgumentNullException(
                    nameof(propertyInfo));

            DefaultValueAttribute defaultValue;

            if (
                value == null ||
                (
                propertyInfo.PropertyType == 
                    typeof(string) && 
                string.IsNullOrEmpty(value as string)
                )
               )
                return true;

            if (
                (
                defaultValue = 
                    propertyInfo.
                    GetCustomAttribute<DefaultValueAttribute>()
                ) != null
               )
                return Equals(
                    value, 
                    defaultValue.Value);
            else
                return value.IsTypeDefault();
        }


        public static bool IsTypeDefault(this object value)
        {
            if (value == null)
                return true;

            Type type = value.GetType();

            if (type == typeof(string))
                return string.
                    IsNullOrEmpty(
                        value as string);

            else if (
                    type.IsPrimitive || 
                    type.IsValueType
                    )
                return Activator.
                    CreateInstance(type).
                    Equals(value);

            else if (
                    typeof(IEnumerable).
                    IsAssignableFrom(type)
                    )
                return value == null ||
                    (value as IEnumerable).
                    GetEnumerator().
                    MoveNext();

            else if (type.IsAbstract)
                return value == null;

            else if (
                        type.IsClass == true ||
                        type.IsInterface == true &&
                        value == null
                    )
                return true;

            else
                return Activator.
                    CreateInstance(type).
                    Equals(value);

        }
    }
}
