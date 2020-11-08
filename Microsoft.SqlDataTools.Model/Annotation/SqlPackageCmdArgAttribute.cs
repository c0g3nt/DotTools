
namespace Microsoft.SqlDataTools.Model.Annotation
{
    [System.AttributeUsage(
        System.AttributeTargets.Property, 
        AllowMultiple = false, 
        Inherited = true)]
    public class SqlPackageCmdArgAttribute : System.Attribute
    {
        private string longForm;
        private string shortForm;

        public virtual string NameValueSeperator { get; set; }

        public virtual string Prefix { get; set; }

        public string LongForm { 
            get => longForm ?? shortForm; 
            set => longForm = value; }

        public string ShortForm { 
            get => shortForm ?? longForm; 
            set => shortForm = value; }

        public SqlPackageCmdArgAttribute(
            [System.Runtime.CompilerServices.CallerMemberName] 
            string longForm = null)
        {
            this.LongForm = longForm;
        }

        public override bool Equals(object obj)
        {
            return obj != null &&
                (ReferenceEquals(this, obj) ||
                  typeof(SqlPackageCmdArgAttribute).
                  IsAssignableFrom(obj.GetType()) &&
                  ((SqlPackageCmdArgAttribute)obj).LongForm ==
                    this.LongForm);
        }

        public override int GetHashCode()
        {
            return (LongForm ?? "").GetHashCode();
        }
    }


}
