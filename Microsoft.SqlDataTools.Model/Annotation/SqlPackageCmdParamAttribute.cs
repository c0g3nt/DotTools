namespace Microsoft.SqlDataTools.Model.Annotation
{
    public class SqlPackageCmdParamAttribute : SqlPackageCmdArgAttribute
    {
        public override string Prefix { 
            get => "/"; 
            set => base.Prefix = value; }

        public override string NameValueSeperator { 
            get => ":"; 
            set => base.NameValueSeperator = value; }

        public SqlPackageCmdParamAttribute(
            [System.Runtime.CompilerServices.CallerMemberName] 
            string longForm = null) :
            base(longForm)
        {

        }
    }
}
