using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TraversalProject.ViewComponents.Default
{
    public class _Statistics : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            using var context = new Context();
            ViewBag.value1 = context.Destinations.Count();
            ViewBag.value2 = context.Guides.Count();
            ViewBag.value3 = "285";
            return View();
        }
    }
}
