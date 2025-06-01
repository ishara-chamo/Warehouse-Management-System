using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Warehouse.Data;

namespace Warehouse.Controllers.Supplier
{
    public class SupplierListController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        public SupplierListController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var std = await dbContext.Warehouse_Supplier.ToListAsync();
            return View(std);
        }
    }
}
