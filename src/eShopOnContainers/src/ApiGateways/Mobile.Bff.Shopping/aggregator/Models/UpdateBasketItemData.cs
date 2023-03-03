namespace Microsoft.eShopOnContainers.Mobile.Shopping.HttpAggregator.Models
{
    public class UpdateBasketItemData
    {
        public UpdateBasketItemData()
        {
            NewQty = 0;
        }

        public string BasketItemId { get; set; }

        public int NewQty { get; set; }
    }
}
