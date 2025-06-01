using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Warehouse.Data;
using Warehouse.Models;

namespace Warehouse.Controllers.Warehouse
{
    public class WarehouseEditController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        public WarehouseEditController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public async Task<IActionResult> Index(Guid editid)
        {
            var stu = dbContext.Warehouse_Warehouse.FirstOrDefault(u => u.Warehouse_GUID == editid);
            if (stu == null)
            {
                return NotFound();
            }

            var ss = new WarehouseViewModel
            {
                warename = stu.Warehouse_Name,
                location = stu.Warehouse_Location,
                contact = stu.Warehouse_Contact,

            };
            return View(ss);

        }

        [HttpPost]

        public async Task<IActionResult> Index(WarehouseViewModel viewModel)
        {
            var upd = await dbContext.Warehouse_Warehouse.FirstOrDefaultAsync(u => u.Warehouse_GUID == viewModel.editid);
            if (upd == null)
            {
                return NotFound();
            }

            upd.Warehouse_Name = viewModel.warename;
            upd.Warehouse_Location = viewModel.location;
            upd.Warehouse_Contact = viewModel.contact;



            await dbContext.SaveChangesAsync();
            return RedirectToAction("Index", "WarehouseList"); //Action Name And Controller Name

        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid deleteid)
        {
            var del = dbContext.Warehouse_Warehouse.FirstOrDefault(u => u.Warehouse_GUID == deleteid);            //stored data

            if (del == null)
            {
                return NotFound();
            }

            try
            {
                dbContext.Warehouse_Warehouse.Remove(del);
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
