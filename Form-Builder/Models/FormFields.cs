namespace Form_Builder.Models
{
    public class FormFields
    {
        public int FieldID { get; set; }
        public Form FormId { get; set; }
        public string Label { get; set; }
        public bool IsRequired { get; set; }
    }
}
