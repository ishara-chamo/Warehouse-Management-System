using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Warehouse.Data;
using Warehouse.Models;

namespace Warehouse.Controllers.Product
{
    public class ProductEditController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        public ProductEditController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        
        [HttpGet]
        public async Task<IActionResult> Index(Guid editid)
        {
            var cate = dbContext.Warehouse_Category.Select(c => new SelectListItem
            {
                Value = c.Category_RowID.ToString(),
                Text = c.Category_Name
            }).ToList();


            ViewBag.Cate = cate;
            var stud = dbContext.Warehouse_Product.FirstOrDefault(u => u.Product_GUID == editid);
            if (stud == null)
            {
                return NotFound();
            }

            var ss = new ProductViewModel
            {

                cateid = stud.Category_RowID,
                productname = stud.Product_Name,
                productdescription = stud.Product_Description,
                price = stud.Product_Price,
                quantity = stud.Product_Quantity,
               
            };
            return View(ss);

        }

        [HttpPost]

        public async Task<IActionResult> Index(ProductViewModel viewModel)
        {
            var upd = await dbContext.Warehouse_Product.FirstOrDefaultAsync(u => u.Product_GUID == viewModel.editid);
            if (upd == null)
            {
                return NotFound();
            }


            upd.Category_RowID = viewModel.cateid;
            upd.Product_Name = viewModel.productname;
            upd.Product_Description = viewModel.productdescription;
            upd.Product_Price = viewModel.price;
            upd.Product_Quantity = viewModel.quantity;
           


            await dbContext.SaveChangesAsync();
            return RedirectToAction("Index", "ProductList"); //Action Name And Controller Name

        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid deleteid)
        {
            var del = dbContext.Warehouse_Product.FirstOrDefault(u => u.Product_GUID == deleteid);            //stored data

            if (del == null)
            {
                return NotFound();
            }

            try
            {
                dbContext.Warehouse_Product.Remove(del);
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
