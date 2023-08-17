using System.ComponentModel.DataAnnotations;

namespace CustomField_API
{
    public class CustomFormField
    {
        public Guid CustomFormFieldId { get; set; }

        public string FormName { get; set; }

        public ICollection<CustomFormFieldItem>? CustomFormFieldItems { get; set; }
    }
}