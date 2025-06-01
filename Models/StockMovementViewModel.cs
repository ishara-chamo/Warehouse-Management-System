namespace Warehouse.Models
{
    public class StockMovementViewModel
    {
        public Guid editid { get; set; }
        public Guid deleteid { get; set; }
        public int productid { get; set; }
        public int fromwarehouseid { get; set; }
        public int towarehouseid { get; set; }
        public int quantity { get; set; }
        public DateTime date { get; set; }
        public int cb {  get; set; }
    }
}
