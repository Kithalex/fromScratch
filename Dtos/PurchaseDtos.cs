namespace RetailStoreAPI.Dtos
{
    public class CreatePurchaseDto
    {
        public int CustomerId { get; set; }
        public List<PurchaseItemDto> Items { get; set; } = new();
    }

    public class PurchaseItemDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
