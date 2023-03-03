namespace Webhooks.API.IntegrationEvents
{
    public record OrderStatusChangedToPaidIntegrationEvent : IntegrationEvent
    {
        public OrderStatusChangedToPaidIntegrationEvent(int orderId,
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
