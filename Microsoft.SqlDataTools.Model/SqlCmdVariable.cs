using System;
using System.Collections.Generic;

namespace Microsoft.SqlDataTools.Model
{
    public class SqlCmdVariable : IEquatable<SqlCmdVariable>
    {

        public SqlCmdVariable(string name, string value)
        {
            Name = name;
            Value = value;
        }
        public string Name { get; set; }
        public string Value { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as SqlCmdVariable);
        }

        public bool Equals(SqlCmdVariable other)
        {
            return ReferenceEquals(this,other) ||
                   ( other != null &&
                     Name == other.Name &&
                     Value == other.Value  );
        }

        public override int GetHashCode()
        {
            int hashCode = -244751520;

            hashCode = 
                hashCode * 
                -1521134295 + 
                EqualityComparer<string>.
                Default
                .GetHashCode(Name);

            hashCode = 
                hashCode * 
                -1521134295 + 
                EqualityComparer<string>.
                Default.
                GetHashCode(Value);

            return hashCode;
        }
    }
}
