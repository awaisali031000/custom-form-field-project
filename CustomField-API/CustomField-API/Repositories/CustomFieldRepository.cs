using CustomField_API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CustomField_API.Repositories
{
    public class CustomFieldRepository : ICustomFieldRepository
    {
        private readonly DataContext _context;

        public CustomFieldRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<CustomFormField> PostAndUpdateFormField(CustomFormField formFields)
        {
            try
            {
                bool isExisting = _context.CustomFormFields.Any(x => x.CustomFormFieldId == formFields.CustomFormFieldId);
                if (!isExisting)
                {
                    foreach (var field in formFields.CustomFormFieldItems)
                    {
                        _context.CustomFormFieldItems.Add(field);
                    }

                    _context.CustomFormFields.Add(formFields);

                    await _context.SaveChangesAsync();
                    return formFields;
                }
                else
                {
                    var form = await _context.CustomFormFields
                        .Include(f => f.CustomFormFieldItems)
                        .FirstOrDefaultAsync(f => f.CustomFormFieldId == formFields.CustomFormFieldId);

                    if (form != null)
                    {
                        form.FormName = formFields.FormName;
                        form.CustomFormFieldItems = formFields.CustomFormFieldItems;
                        foreach (var fieldtoUpdate in formFields.CustomFormFieldItems)
                        {
                            var existingField = form.CustomFormFieldItems
                                .FirstOrDefault(f => f.CustomFormFieldItemId == fieldtoUpdate.CustomFormFieldItemId);


                            if (existingField != null)
                            {
                                existingField.Type = fieldtoUpdate.Type;
                                existingField.Label = fieldtoUpdate.Label;
                                existingField.ControlName = fieldtoUpdate.ControlName;
                                existingField.Option = fieldtoUpdate.Option;
                                existingField.Data = fieldtoUpdate.Data;
                                existingField.Index = fieldtoUpdate.Index;
                            }
                            else
                            {
                                _context.CustomFormFieldItems.Add(fieldtoUpdate);
                            }
                        }

                        await _context.SaveChangesAsync();
                    }
                    return formFields;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred: {ex.Message}");
            }
        }

        public async Task<List<CustomFormField>> GetAll()
        {
            var result = await _context.CustomFormFields
                .Include(cff => cff.CustomFormFieldItems)
                .ToListAsync();

            foreach (var customFormField in result)
            {
                customFormField.CustomFormFieldItems = customFormField.CustomFormFieldItems
                    .OrderBy(item => item.Index)
                    .ToList();
            }

            return result;
        }
    }
}
