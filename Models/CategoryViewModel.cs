namespace Warehouse.Models
{
    public class CategoryViewModel
    {
        public Guid editid { get; set; }
        public Guid deleteid { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; } = string.Empty;
        public int cb {  get; set; }
    }
}
