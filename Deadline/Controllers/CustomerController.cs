using Deadline.Models;
using Microsoft.AspNetCore.Mvc;

namespace Deadline.Controllers
{
    public class CustomerController : Controller
    {
        private readonly DeadlineContext db;

        public CustomerController(DeadlineContext _db)
        {
            db=_db;
        }
        public IActionResult Index()
        {
            List<Customer> list = db.Customers.ToList<Customer>();
            return View(list);
        }
    }
}
