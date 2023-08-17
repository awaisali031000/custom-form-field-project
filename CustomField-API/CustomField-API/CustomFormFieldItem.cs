using System.ComponentModel.DataAnnotations;

namespace CustomField_API
{
    public class CustomFormFieldItem
    {
        public Guid CustomFormFieldItemId { get; set; }
        public string Type { get; set; }
        public string Label { get; set; }
        public string ControlName { get; set; }
        public string Option { get; set; }
        public string Data { get; set; }
        public int Index { get; set; }
    }
}