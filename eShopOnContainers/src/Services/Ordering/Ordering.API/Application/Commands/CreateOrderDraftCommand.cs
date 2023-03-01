namespace Microsoft.eShopOnContainers.Services.Ordering.API.Application.Commands
{
    using BasketItem = Models.BasketItem;

    public class CreateOrderDraftCommand : IRequest<OrderDraftDTO>
    {
        public CreateOrderDraftCommand(string buyerId, IEnumerable<BasketItem> items)
        {
            BuyerId = buyerId;
            Items = items;
        }

        public string BuyerId { get; }

        public IEnumerable<BasketItem> Items { get; }
    }
}
