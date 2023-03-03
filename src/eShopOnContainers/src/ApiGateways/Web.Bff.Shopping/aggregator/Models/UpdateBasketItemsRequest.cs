namespace Microsoft.eShopOnContainers.Web.Shopping.HttpAggregator.Models
{
    public class UpdateBasketItemsRequest
    {
        public UpdateBasketItemsRequest()
        {
            Updates = new List<UpdateBasketItemData>();
        }

        public string BasketId { get; set; }

        public ICollection<UpdateBasketItemData> Updates { get; set; }
    }
}
