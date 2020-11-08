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

    public static partial class DefaultValueHelper
    {
        public enum UserDefinedProfileBehavior
        {
            PrioritizeUserDefined,
            Prioritize
        }
        internal static bool IsDefault(object value, PropertyInfo propertyInfo)
        {

            if (propertyInfo == null)
                throw new ArgumentNullException(nameof(propertyInfo));

            DefaultValueAttribute defaultValue;

            if (value == null ||
                (propertyInfo.PropertyType == typeof(string) && string.IsNullOrEmpty(value as string)))
                return true;

            if ((defaultValue = propertyInfo.GetCustomAttribute<DefaultValueAttribute>()) != null)
                return Equals(value, defaultValue.Value);
            else
                return IsTypeDefault(propertyInfo.PropertyType, value);
        }
        

        internal static bool IsTypeDefault(Type type, object value)
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
    }

 
}
