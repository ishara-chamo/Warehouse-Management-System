using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Warehouse.Data;

namespace Warehouse.Controllers.Product
{
    public class ProductListController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        public ProductListController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var std = await dbContext.Warehouse_Product.ToListAsync();
            return View(std);
        }
    }
}
