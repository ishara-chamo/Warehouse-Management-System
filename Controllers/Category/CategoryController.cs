using Microsoft.AspNetCore.Mvc;
using Warehouse.Data;
using Warehouse.Models;
using Warehouse.Models.Entites;


namespace Warehouse.Controllers.Category
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public CategoryController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]

        public IActionResult Index()
        {
            
             return View();
         }

         [HttpPost]

         public async Task<IActionResult> Index(CategoryViewModel viewModel)
         {
            var main = new Categories
            {


                Category_Name = viewModel.CategoryName,
                Category_Description = viewModel.CategoryDescription,
                Category_CreatedBy = createdby(viewModel.cb),
                Category_IPAddress = HttpContext.Connection.RemoteIpAddress?.ToString(),
            };
                 await dbContext.Warehouse_Category.AddAsync(main);
                 await dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Details), new { Guid = main.Category_GUID });


        }
        [HttpGet]

        public IActionResult Details(Guid Guid)
        {
            var stu = dbContext.Warehouse_Category.FirstOrDefault(E => E.Category_GUID == Guid);
            var showData = new CategoryViewModel
            {
                CategoryName = stu.Category_Name,
                CategoryDescription = stu.Category_Description,
                cb = stu.Category_CreatedBy,

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
