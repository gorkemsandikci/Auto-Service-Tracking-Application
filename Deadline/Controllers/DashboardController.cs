using Microsoft.AspNetCore.Mvc;

namespace Deadline.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
