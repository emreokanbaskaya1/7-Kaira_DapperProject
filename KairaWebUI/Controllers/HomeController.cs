using Microsoft.AspNetCore.Mvc;

namespace KairaWebUI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
