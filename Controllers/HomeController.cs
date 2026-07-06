using Microsoft.AspNetCore.Mvc;

namespace WebNetCore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() // ito yung babalik na response sa request return type is IActionResult tas Index na Mehtod
        {
            return View();
        }
    }
}
