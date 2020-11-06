using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.SqlDataTools.Model
{
    public struct Defaulted<T>
    {
        public readonly T DefaultValue;
        public T Value { get; set; }
        public bool IsDefault { get => Equals(DefaultValue, Value); }
        public static implicit operator T(Defaulted<T> defaulted)
        {
            return defaulted.Value;
        }
        public static implicit operator Defaulted<T>(T value)
        {
            return new Defaulted<T>()
            {
                Value = value
            };
        }
    }
}
