using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Warehouse.Data;
using Warehouse.Models;

namespace Warehouse.Controllers.StockMovement
{
    public class StockMovementEditController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        public StockMovementEditController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index(Guid editid)
        {
            var pro = dbContext.Warehouse_Product.Select(c => new SelectListItem
            {
                Value = c.Product_RowID.ToString(),
                Text = c.Product_Name
            }).ToList();

            ViewBag.Pro = pro;


            var stu = dbContext.Warehouse_StockMovement.FirstOrDefault(u => u.Movement_GUID == editid);
            if (stu == null)
            {
                return NotFound();
            }

            var ss = new StockMovementViewModel
            {
                productid = stu.Product_RowID,
                fromwarehouseid = stu.FromWarehouseId,
                towarehouseid = stu.ToWarehouseId,
                quantity = stu.Movement_Quantity,
                date = stu.Movement_Date,

            };
            return View(ss);

        }

        [HttpPost]

        public async Task<IActionResult> Index(StockMovementViewModel viewModel)
        {
            var upd = await dbContext.Warehouse_StockMovement.FirstOrDefaultAsync(u => u.Movement_GUID == viewModel.editid);
            if (upd == null)
            {
                return NotFound();
            }


            upd.Product_RowID = viewModel.productid;
            upd.FromWarehouseId = viewModel.fromwarehouseid;
            upd.ToWarehouseId = viewModel.towarehouseid;
            upd.Movement_Quantity = viewModel.quantity;
            upd.Movement_Date = viewModel.date;


            await dbContext.SaveChangesAsync();
            return RedirectToAction("Index", "StockMovementList"); //Action Name And Controller Name

        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid deleteid)
        {
            var del = dbContext.Warehouse_StockMovement.FirstOrDefault(u => u.Movement_GUID == deleteid);            //stored data

            if (del == null)
            {
                return NotFound();
            }

            try
            {
                dbContext.Warehouse_StockMovement.Remove(del);
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
