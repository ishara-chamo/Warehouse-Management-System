using Microsoft.AspNetCore.Mvc;
using Warehouse.Data;
using Warehouse.Models.Entites;
    

namespace Warehouse.Controllers.Contact
{
    public class ContactController : Controller
    {
        private readonly ApplicationDbContext DbContext;

        public ContactController(ApplicationDbContext context)
        {
            DbContext = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(ContactMessage message)
        {
            if (ModelState.IsValid)
            {
                DbContext.ContactMessages.Add(message);
                DbContext.SaveChanges();
                ViewBag.Message = "Your message has been sent successfully!";
                return View();
            }
            return View(message);
        }
    }
}
