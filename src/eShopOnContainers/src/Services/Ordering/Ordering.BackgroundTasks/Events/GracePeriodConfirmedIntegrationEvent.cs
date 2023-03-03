namespace Ordering.BackgroundTasks.Events
{
    using Microsoft.eShopOnContainers.BuildingBlocks.EventBus.Events;

    public record GracePeriodConfirmedIntegrationEvent : IntegrationEvent
    {
        public GracePeriodConfirmedIntegrationEvent(int orderId)
        {
            OrderId = orderId;
        }

        public int OrderId { get; }
    }
}
