using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Detail()
        {
            return View();
        }
    }
}
