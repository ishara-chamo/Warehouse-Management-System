using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Warehouse.Data;
using Warehouse.Models;

namespace Warehouse.Controllers.Category
{
    public class CategoryEditController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        public CategoryEditController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public async Task<IActionResult> Index(Guid editid)
        {
            var stud = dbContext.Warehouse_Category.FirstOrDefault(u => u.Category_GUID == editid);
            if (stud == null)
            {
                return NotFound();
            }

            var ss = new CategoryViewModel
            {
                CategoryName = stud.Category_Name,
                CategoryDescription = stud.Category_Description,

            };
            return View(ss);

        }

        [HttpPost]

        public async Task<IActionResult> Index(CategoryViewModel viewModel)
        {
            var upd = await dbContext.Warehouse_Category.FirstOrDefaultAsync(u => u.Category_GUID == viewModel.editid);
            if (upd == null)
            {
                return NotFound();
            }

            upd.Category_Name = viewModel.CategoryName;
            upd.Category_Description = viewModel.CategoryDescription;



            await dbContext.SaveChangesAsync();
            return RedirectToAction("Index", "CategoryList"); //Action Name And Controller Name

        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid deleteid)
        {
            var del = dbContext.Warehouse_Category.FirstOrDefault(u => u.Category_GUID == deleteid);            //stored data

            if (del == null)
            {
                return NotFound();
            }

            try
            {
                dbContext.Warehouse_Category.Remove(del);
                await dbContext.SaveChangesAsync();
                return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                // Handle concurrency exception
                return Conflict("The record was  deleted .");
            }

        }
    }
}
