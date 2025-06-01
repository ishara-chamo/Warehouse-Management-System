using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Warehouse.Data;

namespace Warehouse.Controllers.StockMovement
{
    public class StockMovementListController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        public StockMovementListController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var std = await dbContext.Warehouse_StockMovement.ToListAsync();
            return View(std);
        }
    }
}
