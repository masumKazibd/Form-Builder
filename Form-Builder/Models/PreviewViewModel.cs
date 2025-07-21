namespace Form_Builder.Models.ViewModels
{
    public class PreviewViewModel
    {
        public string FormTitle { get; set; }
        public List<FormFieldViewModel> Fields { get; set; }
    }

    public class FormFieldViewModel
    {
        public string Label { get; set; }
        public bool IsRequired { get; set; }
    }
}