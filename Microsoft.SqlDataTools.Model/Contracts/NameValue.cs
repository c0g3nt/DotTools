namespace Microsoft.SqlDataTools.Model
{
    public struct NameValue
    {
        public NameValue(string name, object value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; set; }
        public object Value { get; set; }
    }
}
