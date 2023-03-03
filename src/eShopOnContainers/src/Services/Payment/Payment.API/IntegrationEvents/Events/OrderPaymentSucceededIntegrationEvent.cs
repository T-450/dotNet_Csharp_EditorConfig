namespace Microsoft.eShopOnContainers.Payment.API.IntegrationEvents.Events
{
    public record OrderPaymentSucceededIntegrationEvent : IntegrationEvent
    {
        public OrderPaymentSucceededIntegrationEvent(int orderId)
        {
            OrderId = orderId;
        }

        public int OrderId { get; }
    }
}
