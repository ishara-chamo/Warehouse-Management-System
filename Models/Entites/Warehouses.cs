using System.ComponentModel.DataAnnotations;

namespace Warehouse.Models.Entites
{
    public class Warehouses
    {
        [Key]
        public int Warehouse_RowID { get; set; }
        public Guid Warehouse_GUID { get; set; } = Guid.NewGuid();
        public string Warehouse_Name { get; set; }
        public string Warehouse_Location { get; set; }
        public string Warehouse_Contact { get; set; }
        public int Warehouse_CreatedBy { get; set; }
        public string Warehouse_IPAddress { get; set; }
        public DateTime Warehouse_CreatedOn { get; set; } = DateTime.Now;
    }
}
