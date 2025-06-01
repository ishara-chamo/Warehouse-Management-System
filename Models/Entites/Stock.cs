using System.ComponentModel.DataAnnotations;

namespace Warehouse.Models.Entites
{
    public class Stock
    {
        [Key]
        public int Movement_RowID { get; set; }
        public Guid Movement_GUID { get; set; } = Guid.NewGuid();
        public int Product_RowID { get; set; }
        public int FromWarehouseId { get; set; }
        public int ToWarehouseId { get; set; }
        public int Movement_Quantity { get; set; }
        public DateTime Movement_Date { get; set; }
        public int Movement_CreatedBy { get; set; }
        public string Movement_IPAddress { get; set; }
        public DateTime Movement_CreatedOn { get; set; } = DateTime.Now;
    }
}
