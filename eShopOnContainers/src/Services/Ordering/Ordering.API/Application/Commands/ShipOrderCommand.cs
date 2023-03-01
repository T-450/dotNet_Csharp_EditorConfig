namespace Microsoft.eShopOnContainers.Services.Ordering.API.Application.Commands
{
    public class ShipOrderCommand : IRequest<bool>
    {
        public ShipOrderCommand(int orderNumber)
        {
            OrderNumber = orderNumber;
        }

        [DataMember]
        public int OrderNumber { get; private set; }
    }
}
