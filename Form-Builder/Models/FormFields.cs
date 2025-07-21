namespace Form_Builder.Models
{
    public class FormFields
    {
        public int FieldID { get; set; }
        public int FormID { get; set; }
        public string Label { get; set; }
        public bool IsRequired { get; set; }
    }
}