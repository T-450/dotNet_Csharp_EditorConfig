namespace Microsoft.eShopOnContainers.Services.Ordering.API.Application.Commands
{
    public class SetStockConfirmedOrderStatusCommand : IRequest<bool>
    {
        public SetStockConfirmedOrderStatusCommand(int orderNumber)
        {
            OrderNumber = orderNumber;
        }

        [DataMember]
        public int OrderNumber { get; private set; }
    }
}
