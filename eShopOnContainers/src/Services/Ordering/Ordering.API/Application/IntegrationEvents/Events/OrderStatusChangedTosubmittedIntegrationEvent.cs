namespace Microsoft.eShopOnContainers.Services.Ordering.API.Application.IntegrationEvents.Events
{
    public record OrderStatusChangedToSubmittedIntegrationEvent : IntegrationEvent
    {
        public OrderStatusChangedToSubmittedIntegrationEvent(int orderId, string orderStatus, string buyerName)
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
