using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Warehouse.Data;

namespace Warehouse.Controllers.Warehouse
{
    public class WarehouseListController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        public WarehouseListController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var std = await dbContext.Warehouse_Warehouse.ToListAsync();
            return View(std);
        }
    }
}
