using System.ComponentModel.DataAnnotations;

namespace Warehouse.Models.Entites
{
    public class Suppliers
    {
        [Key]
        public int Supplier_RowID { get; set; }
        public Guid Supplier_GUID { get; set; } = Guid.NewGuid();
        public string Supplier_Name { get; set; }
        public string Supplier_ContactInfo { get; set; }
        public int Supplier_CreatedBy { get; set; }
        public string Supplier_IPAddress { get; set; }
        public DateTime Supplier_CreatedOn { get; set; } = DateTime.Now;
    }
}
