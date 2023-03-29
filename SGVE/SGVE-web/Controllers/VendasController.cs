using Microsoft.AspNetCore.Mvc;

namespace SGVE_web.Controllers
{
    public class VendasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
