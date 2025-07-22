using Microsoft.AspNetCore.Mvc;

namespace Form_Builder.ViewComponents
{
    public class FormFieldViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(int fieldIndex)
        {
            return View(fieldIndex);
        }
    }
}