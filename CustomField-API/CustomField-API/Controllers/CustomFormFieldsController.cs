using CustomField_API.Data;
using CustomField_API.Managers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CustomField_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomFormFieldsController : ControllerBase
    {
        private readonly ICustomFieldManager _customFieldManager;

        public CustomFormFieldsController(ICustomFieldManager customFieldManager)
        {
            _customFieldManager = customFieldManager;
        }

        [HttpPost]
        public async Task<IActionResult> PostFormField(CustomFormField formFields)
        {
            var result = await _customFieldManager.PostFormField(formFields);

            return Ok(result);
            
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _customFieldManager.GetAll();
            return Ok(result);
        }
    }
}
