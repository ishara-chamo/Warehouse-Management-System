using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Warehouse.Data;
using Warehouse.Models.Entites;
using Warehouse.Models;

namespace Warehouse.Controllers.StockMovement
{
    public class StockMovementController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public StockMovementController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]

        public IActionResult Index()
        {
            var pro = dbContext.Warehouse_Product.Select(c => new SelectListItem
            {
                Value = c.Product_RowID.ToString(),
                Text = c.Product_Name
            }).ToList();

            ViewBag.Pro = pro;

            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Index(StockMovementViewModel viewModel)
        {
            var main = new Stock
            {


                Product_RowID = viewModel.productid,
                FromWarehouseId = viewModel.fromwarehouseid,
                ToWarehouseId = viewModel.towarehouseid,
                Movement_Quantity = viewModel.quantity,
                Movement_Date = viewModel.date,
                Movement_CreatedBy = createdby(viewModel.cb),
                Movement_IPAddress = HttpContext.Connection.RemoteIpAddress?.ToString(),
            };
            await dbContext.Warehouse_StockMovement.AddAsync(main);
            await dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Details), new { Guid = main.Movement_GUID });


        }
        [HttpGet]

        public IActionResult Details(Guid Guid)
        {
            var stu = dbContext.Warehouse_StockMovement.FirstOrDefault(E => E.Movement_GUID == Guid);
            var showData = new StockMovementViewModel
            {
                productid = stu.Product_RowID,
                fromwarehouseid = stu.FromWarehouseId,
                towarehouseid = stu.ToWarehouseId,
                quantity = stu.Movement_Quantity,
                date = stu.Movement_Date,
                cb = stu.Movement_CreatedBy,

            };
            return View(showData);
        }


        public int createdby(int createdby)
        {
            createdby = 1;
            return (createdby);
        }
    }
}
