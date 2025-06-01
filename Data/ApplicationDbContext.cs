using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Warehouse.Models;
using Warehouse.Models.Entites;

namespace Warehouse.Data
{
    public class ApplicationDbContext : DbContext//IdentityDbContext<User>  // Use IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<ContactMessage> ContactMessages { get; set; }
        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<Suppliers> Warehouse_Supplier { get; set; }
        public DbSet<Categories> Warehouse_Category { get; set; }
        public DbSet<Products> Warehouse_Product { get; set; }
        public DbSet<Warehouses> Warehouse_Warehouse { get; set; }
        public DbSet<Stock> Warehouse_StockMovement { get; set; }



    }
}

