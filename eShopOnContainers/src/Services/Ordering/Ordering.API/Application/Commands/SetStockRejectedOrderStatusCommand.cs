namespace Microsoft.eShopOnContainers.Services.Ordering.API.Application.Commands
{
    public class SetStockRejectedOrderStatusCommand : IRequest<bool>
    {
        public SetStockRejectedOrderStatusCommand(int orderNumber, List<int> orderStockItems)
        {
            OrderNumber = orderNumber;
            OrderStockItems = orderStockItems;
        }

        [DataMember]
        public int OrderNumber { get; private set; }

        [DataMember]
        public List<int> OrderStockItems { get; private set; }
    }
}
