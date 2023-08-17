namespace CustomField_API.Managers
{
    public interface ICustomFieldManager
    {
        Task<CustomFormField> PostFormField(CustomFormField formFields);
        Task<List<CustomFormField>> GetAll();
    }
}
