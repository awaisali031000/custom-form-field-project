using Microsoft.AspNetCore.Mvc;

namespace CustomField_API.Repositories
{
    public interface ICustomFieldRepository
    {
        Task<CustomFormField> PostAndUpdateFormField(CustomFormField formFields);
        Task<List<CustomFormField>> GetAll();
    }
}
