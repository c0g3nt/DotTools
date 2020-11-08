using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Xml.Serialization;

namespace Microsoft.SqlDataTools.Model
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class SqlCmdArgumentAttribute : Attribute
    {
        private string longForm;
        private string shortForm;
        public virtual string NameValueSeperator { get; set; }
        public virtual string Prefix { get; set; }
        public string LongForm { get => longForm ?? shortForm; set => longForm = value; }
        public string ShortForm { get => shortForm ?? longForm; set => shortForm = value; }
        public SqlCmdArgumentAttribute([System.Runtime.CompilerServices.CallerMemberName] string longForm = null)
        {
            this.LongForm = longForm;
        }
        public override bool Equals(object obj)
        {
            return obj != null &&
                (ReferenceEquals(this, obj) ||
                  typeof(SqlCmdArgumentAttribute).IsAssignableFrom(obj.GetType()) &&
                  ((SqlCmdArgumentAttribute)obj).LongForm == this.LongForm);
        }
        public override int GetHashCode()
        {
            return (LongForm ?? "").GetHashCode();
        }
    }
    public class ParameterCmdArgumentAttribute : SqlCmdArgumentAttribute
    {
        public override string Prefix { get => "/"; set => base.Prefix = value; }
        public override string NameValueSeperator { get => ":"; set => base.NameValueSeperator = value; }
        public ParameterCmdArgumentAttribute([System.Runtime.CompilerServices.CallerMemberName] string longForm = null) : 
            base(longForm)
        {
            
        }
    }
    public class PropertyCmdArgumentAttribute : SqlCmdArgumentAttribute
    {
        public override string Prefix { get => "/p:"; set => base.Prefix = value; }
        public override string NameValueSeperator { get => "="; set => base.NameValueSeperator = value; }
        public PropertyCmdArgumentAttribute([System.Runtime.CompilerServices.CallerMemberName] string longForm = null) :
            base(longForm)
        {

        }
    }
}
