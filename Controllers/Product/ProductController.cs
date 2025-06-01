using Microsoft.AspNetCore.Mvc;
using Warehouse.Data;
using Warehouse.Models.Entites;
using Warehouse.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Warehouse.Controllers.Product
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public ProductController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]

        public IActionResult Index()
        {
            var cate = dbContext.Warehouse_Category.Select(c => new SelectListItem
            {
            Value=c.Category_RowID.ToString(),
            Text=c.Category_Name
            }) .ToList();

           ViewBag. Cate = cate;

            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Index(ProductViewModel viewModel)
        {
            var main = new Products
            {


                Product_Name = viewModel.productname,
                Category_RowID = viewModel.cateid,
                Product_Description = viewModel.productdescription,
                Product_Price = viewModel.price,
                Product_Quantity = viewModel.quantity,
                Product_CreatedBy = createdby(viewModel.cb),
                Product_IPAddress = HttpContext.Connection.RemoteIpAddress?.ToString(),
            };
            await dbContext.Warehouse_Product.AddAsync(main);
            await dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Details), new { Guid = main.Product_GUID });


        }
        [HttpGet]

        public IActionResult Details(Guid Guid)
        {
            var stu = dbContext.Warehouse_Product.FirstOrDefault(E => E.Product_GUID == Guid);
            var showData = new ProductViewModel
            {
                productname = stu.Product_Name,
                cateid = stu.Category_RowID,
                productdescription = stu.Product_Description,
                price = stu.Product_Price,
                quantity = stu.Product_Quantity,
                cb = stu.Product_CreatedBy,

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
