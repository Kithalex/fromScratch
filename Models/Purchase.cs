namespace RetailStoreAPI.Models
{
    public class Purchase
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public DateTime PurchaseDate { get; set; }
        public List<PurchaseItem> Items { get; set; }
    }
}
