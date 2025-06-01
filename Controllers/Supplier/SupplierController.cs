using Microsoft.AspNetCore.Mvc;
using Warehouse.Data;
using Warehouse.Models.Entites;
using Warehouse.Models;

namespace Warehouse.Controllers.Supplier
{
    public class SupplierController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public SupplierController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]

        public IActionResult Index()
        {

            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Index(SupplierViewModel viewModel)
        {
            var main = new Suppliers
            {


                Supplier_Name = viewModel.SupplierName,
                Supplier_ContactInfo = viewModel.Contactinfo,
                Supplier_CreatedBy = createdby(viewModel.cb),
                Supplier_IPAddress = HttpContext.Connection.RemoteIpAddress?.ToString(),
            };
            await dbContext.Warehouse_Supplier.AddAsync(main);
            await dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Details), new { Guid = main.Supplier_GUID });


        }
        [HttpGet]

        public IActionResult Details(Guid Guid)
        {
            var stu = dbContext.Warehouse_Supplier.FirstOrDefault(E => E.Supplier_GUID == Guid);
            var showData = new SupplierViewModel
            {
                SupplierName = stu.Supplier_Name,
                Contactinfo = stu.Supplier_ContactInfo,
                cb = stu.Supplier_CreatedBy,

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
