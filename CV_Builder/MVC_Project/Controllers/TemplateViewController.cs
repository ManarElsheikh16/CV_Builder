using Microsoft.AspNetCore.Mvc;

namespace Final.Controllers
{
    public class TemplateViewController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
