namespace Warehouse.Models
{
    public class WarehouseViewModel
    {
        public Guid editid { get; set; }
        public Guid deleteid { get; set; }
        public string warename { get; set; }
        public string location { get; set; }
        public string contact { get; set; }
        public int cb { get; set; }
    }
}
