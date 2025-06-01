using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Warehouse.Data;
using Warehouse.Models;

namespace Warehouse.Controllers.Supplier
{
    public class SupplierEditController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        public SupplierEditController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public async Task<IActionResult> Index(Guid editid)
        {
            var stud = dbContext.Warehouse_Supplier.FirstOrDefault(u => u.Supplier_GUID == editid);
            if (stud == null)
            {
                return NotFound();
            }

            var ss = new SupplierViewModel
            {
                SupplierName = stud.Supplier_Name,
                Contactinfo = stud.Supplier_ContactInfo,

            };
            return View(ss);

        }

        [HttpPost]

        public async Task<IActionResult> Index(SupplierViewModel viewModel)
        {
            var upd = await dbContext.Warehouse_Supplier.FirstOrDefaultAsync(u => u.Supplier_GUID == viewModel.editid);
            if (upd == null)
            {
                return NotFound();
            }


            upd.Supplier_Name = viewModel.SupplierName;
            upd.Supplier_ContactInfo = viewModel.Contactinfo;



            await dbContext.SaveChangesAsync();
            return RedirectToAction("Index", "SupplierList"); //Action Name And Controller Name

        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid deleteid)
        {
            var del = dbContext.Warehouse_Supplier.FirstOrDefault(u => u.Supplier_GUID == deleteid);            //stored data

            if (del == null)
            {
                return NotFound();
            }

            try
            {
                dbContext.Warehouse_Supplier.Remove(del);
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
