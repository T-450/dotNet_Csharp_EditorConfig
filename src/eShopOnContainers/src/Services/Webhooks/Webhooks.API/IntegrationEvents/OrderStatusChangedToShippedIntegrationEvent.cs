namespace Webhooks.API.IntegrationEvents
{
    public record OrderStatusChangedToShippedIntegrationEvent : IntegrationEvent
    {
        public OrderStatusChangedToShippedIntegrationEvent(int orderId, string orderStatus, string buyerName)
        {
            OrderId = orderId;
            OrderStatus = orderStatus;
            BuyerName = buyerName;
        }

        public int OrderId { get; }
        public string OrderStatus { get; }
        public string BuyerName { get; }
    }
}
