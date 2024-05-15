using Microsoft.AspNetCore.Mvc;

namespace MaxsimApp.Controllers
{
    public class PageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
