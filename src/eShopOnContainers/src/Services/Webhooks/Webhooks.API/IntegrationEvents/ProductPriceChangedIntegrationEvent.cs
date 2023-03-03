namespace Webhooks.API.IntegrationEvents
{
    public record ProductPriceChangedIntegrationEvent : IntegrationEvent
    {
        public ProductPriceChangedIntegrationEvent(int productId, decimal newPrice, decimal oldPrice)
        {
            ProductId = productId;
            NewPrice = newPrice;
            OldPrice = oldPrice;
        }

        public int ProductId { get; }

        public decimal NewPrice { get; }

        public decimal OldPrice { get; }
    }
}
