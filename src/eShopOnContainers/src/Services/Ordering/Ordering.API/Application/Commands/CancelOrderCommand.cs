namespace Microsoft.eShopOnContainers.Services.Ordering.API.Application.Commands
{
    public class CancelOrderCommand : IRequest<bool>
    {
        public CancelOrderCommand() { }

        public CancelOrderCommand(int orderNumber)
        {
            OrderNumber = orderNumber;
        }

        [DataMember]
        public int OrderNumber { get; set; }
    }
}
