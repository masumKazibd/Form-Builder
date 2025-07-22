using Form_Builder.Data;
using Form_Builder.Models;
using Form_Builder.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Form_Builder.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormsApiController : ControllerBase
    {
        private readonly FormRepository _formRepository;

        public FormsApiController(IConfiguration configuration)
        {
            _formRepository = new FormRepository(configuration);
        }

        [HttpPost]
        public IActionResult Create([FromBody] PreviewViewModel formData)
        {
            if (formData == null || string.IsNullOrWhiteSpace(formData.FormTitle))
            {
                return BadRequest("Invalid data provided.");
            }

            try
            {
                var fieldsToSave = formData.Fields.Select(f => new FormFields
                {
                    Label = f.Label,
                    IsRequired = f.IsRequired
                }).ToList();
                
                _formRepository.SaveForm(formData.FormTitle, fieldsToSave);

                return Ok(new { success = true, message = "Form saved successfully!" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An internal server error occurred.");
            }
        }
    }
}