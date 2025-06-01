namespace Warehouse.Models
{
    public class ProductViewModel
    {
        public Guid editid { get; set; }
        public Guid deleteid { get; set; }
        public string productname { get; set; }
        public string productdescription { get; set; }
        public int cateid { get; set; }
        public decimal price { get; set; }
        public int quantity { get; set; }
        public int cb {  get; set; }
    }
}
