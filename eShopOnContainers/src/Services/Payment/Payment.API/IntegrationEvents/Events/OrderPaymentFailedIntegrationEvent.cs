namespace Microsoft.eShopOnContainers.Payment.API.IntegrationEvents.Events
{
    public record OrderPaymentFailedIntegrationEvent : IntegrationEvent
    {
        public OrderPaymentFailedIntegrationEvent(int orderId)
        {
            OrderId = orderId;
        }

        public int OrderId { get; }
    }
}
