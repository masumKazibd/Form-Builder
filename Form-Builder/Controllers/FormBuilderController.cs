using Form_Builder.Data;
using Form_Builder.Models;
using Microsoft.AspNetCore.Mvc;

namespace Form_Builder.Controllers
{
    public class FormBuilderController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly FormRepository _formRepository;
        public FormBuilderController(IConfiguration configuration)
        {
            _configuration = configuration;
            _formRepository = new FormRepository(configuration);
        }

        public IActionResult Index()
        {
            var allForms = _formRepository.GetAllForms();
            return View(allForms);

        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(string formTitle, List<FormFields> fields)
        {
            try
            {
                _formRepository.SaveForm(formTitle, fields);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                return View();
            }
        }
    }
}
