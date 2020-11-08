﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Microsoft.SqlDataTools.Model
{
    internal static class Serialization
    {
        public static bool ShouldSerializeProperty(object input, PropertyInfo prop, object value)
        {
            return !(
                input == null ||
                prop == null ||
                value == null ||
                typeof(DeploymentProperties).IsAssignableFrom(prop.PropertyType) ||
                typeof(IEnumerable<SqlCmdVariable>).IsAssignableFrom(prop.PropertyType) ||
                DefaultChecker.IsDefault(value, prop)
                );
        }
    }
}
