using System.ComponentModel.DataAnnotations;

namespace Warehouse.Models.Entites
{
    public class Categories
    {
        [Key]
        public int Category_RowID { get; set; }
        public Guid Category_GUID { get; set; }=Guid.NewGuid();
        public string Category_Name { get; set; }
        public string Category_Description { get; set; }
        public int Category_CreatedBy { get; set; }
        public string Category_IPAddress { get; set; }
        public DateTime Category_CreatedOn { get; set; }= DateTime.Now;

    }
}
