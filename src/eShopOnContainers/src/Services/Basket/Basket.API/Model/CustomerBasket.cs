namespace Microsoft.eShopOnContainers.Services.Basket.API.Model
{
    public class CustomerBasket
    {
        public CustomerBasket() { }

        public CustomerBasket(string customerId)
        {
            BuyerId = customerId;
        }

        public string BuyerId { get; set; }

        public List<BasketItem> Items { get; set; } = new List<BasketItem>();
    }
}
