using System;
using System.Collections.Generic;

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

    }
}
