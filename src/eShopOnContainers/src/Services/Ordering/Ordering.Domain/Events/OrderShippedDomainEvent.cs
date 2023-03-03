namespace Microsoft.eShopOnContainers.Services.Ordering.Domain.Events
{
    public class OrderShippedDomainEvent : INotification
    {
        public OrderShippedDomainEvent(Order order)
        {
            Order = order;
        }

        public Order Order { get; }
    }
}
