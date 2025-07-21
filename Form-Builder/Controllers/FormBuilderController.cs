using Microsoft.AspNetCore.Mvc;

namespace Form_Builder.Controllers
{
    public class FormBuilderController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }
    }
}
