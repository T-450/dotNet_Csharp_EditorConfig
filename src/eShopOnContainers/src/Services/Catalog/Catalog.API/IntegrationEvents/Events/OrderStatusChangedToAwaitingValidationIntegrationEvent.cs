namespace Microsoft.eShopOnContainers.Services.Catalog.API.IntegrationEvents.Events
{
    public record OrderStatusChangedToAwaitingValidationIntegrationEvent : IntegrationEvent
    {
        public OrderStatusChangedToAwaitingValidationIntegrationEvent(int orderId,
            IEnumerable<OrderStockItem> orderStockItems)
        {
            OrderId = orderId;
            OrderStockItems = orderStockItems;
        }

        public int OrderId { get; }
        public IEnumerable<OrderStockItem> OrderStockItems { get; }
    }

    public record OrderStockItem
    {
        public OrderStockItem(int productId, int units)
        {
            ProductId = productId;
            Units = units;
        }

        public int ProductId { get; }
        public int Units { get; }
    }
}
