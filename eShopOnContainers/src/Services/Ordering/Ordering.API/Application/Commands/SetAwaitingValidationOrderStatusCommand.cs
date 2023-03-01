namespace Microsoft.eShopOnContainers.Services.Ordering.API.Application.Commands
{
    public class SetAwaitingValidationOrderStatusCommand : IRequest<bool>
    {
        public SetAwaitingValidationOrderStatusCommand(int orderNumber)
        {
            OrderNumber = orderNumber;
        }

        [DataMember]
        public int OrderNumber { get; private set; }
    }
}
