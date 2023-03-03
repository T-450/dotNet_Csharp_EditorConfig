namespace Microsoft.eShopOnContainers.Payment.API.IntegrationEvents.Events
{
    public record OrderStatusChangedToStockConfirmedIntegrationEvent : IntegrationEvent
    {
        public OrderStatusChangedToStockConfirmedIntegrationEvent(int orderId)
        {
            OrderId = orderId;
        }

        public int OrderId { get; }
    }
}
