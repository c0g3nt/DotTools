namespace Microsoft.SqlDataTools.Model.Annotation
{
    public class SqlPackageCmdPropAttribute : SqlPackageCmdArgAttribute
    {
        public override string Prefix { 
            get => "/p:"; 
            set => base.Prefix = value; }

        public override string NameValueSeperator { 
            get => "="; 
            set => base.NameValueSeperator = value; }

        public SqlPackageCmdPropAttribute(
            [System.Runtime.CompilerServices.CallerMemberName] 
            string longForm = null) :
            base(longForm)
        {
        }
    }
}
