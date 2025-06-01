using Microsoft.AspNetCore.Mvc;
using Warehouse.Data;
using Warehouse.Models.Entites;
using Warehouse.Models;

namespace Warehouse.Controllers.Warehouse
{
    public class WarehouseController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public WarehouseController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]

        public IActionResult Index()
        {

            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Index(WarehouseViewModel viewModel)
        {
            var main = new Warehouses
            {


                Warehouse_Name = viewModel.warename,
                Warehouse_Location = viewModel.location,
                Warehouse_Contact = viewModel.contact,
                Warehouse_CreatedBy = createdby(viewModel.cb),
                Warehouse_IPAddress = HttpContext.Connection.RemoteIpAddress?.ToString(),
            };
            await dbContext.Warehouse_Warehouse.AddAsync(main);
            await dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Details), new { Guid = main.Warehouse_GUID });


        }
        [HttpGet]

        public IActionResult Details(Guid Guid)
        {
            var stu = dbContext.Warehouse_Warehouse.FirstOrDefault(E => E.Warehouse_GUID == Guid);
            var showData = new WarehouseViewModel
            {
                warename = stu.Warehouse_Name,
                location = stu.Warehouse_Location,
                contact = stu.Warehouse_Contact,
                cb = stu.Warehouse_CreatedBy,

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
