using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Microsoft.SqlDataTools.Model
{
    [AttributeUsage(AttributeTargets.Property,AllowMultiple =false,Inherited=true)]
    public class ShortFormAttribute : Attribute
    {
        public string ShortForm { get; set; }
        public ShortFormAttribute(string shortForm)
        {
            this.ShortForm = shortForm;
        }
    }
}
