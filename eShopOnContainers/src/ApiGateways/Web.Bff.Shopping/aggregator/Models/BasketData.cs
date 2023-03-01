namespace Microsoft.eShopOnContainers.Web.Shopping.HttpAggregator.Models
{
    public class BasketData
    {
        public BasketData() { }

        public BasketData(string buyerId)
        {
            BuyerId = buyerId;
        }

        public string BuyerId { get; set; }

        public List<BasketDataItem> Items { get; set; } = new List<BasketDataItem>();
    }
}
