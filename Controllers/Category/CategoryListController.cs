using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Warehouse.Data;

namespace Warehouse.Controllers.Category
{
    public class CategoryListController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        public CategoryListController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var std = await dbContext.Warehouse_Category.ToListAsync();
            return View(std);
        }
    }
}
