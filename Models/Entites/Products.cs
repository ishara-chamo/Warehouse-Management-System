using System.ComponentModel.DataAnnotations;

namespace Warehouse.Models.Entites
{
    public class Products
    {
        [Key]
        public int Product_RowID { get; set; }
        public Guid Product_GUID { get; set; } = Guid.NewGuid();
        public string Product_Name { get; set; }
        public int Category_RowID { get; set; }
        public string Product_Description { get; set; }
        public decimal Product_Price { get; set; }
        public int Product_Quantity { get; set; }
        public int Product_CreatedBy { get; set; }
        public string Product_IPAddress { get; set; }
        public DateTime Product_CreatedOn { get; set; } = DateTime.Now;
    }
}
