using CustomField_API.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CustomField_API.Managers
{
    public class CustomFieldManager : ICustomFieldManager
    {
        private readonly ICustomFieldRepository _customFieldRepository;

        public CustomFieldManager(ICustomFieldRepository customFieldRepository)
        {
            _customFieldRepository = customFieldRepository;
        }
        public async Task<CustomFormField> PostFormField(CustomFormField formFields)
        {
            var result = await _customFieldRepository.PostAndUpdateFormField(formFields);
            return result;
        }

        public async Task<List<CustomFormField>> GetAll()
        {
            var result = await _customFieldRepository.GetAll();
            return result;
        }
    }
}
