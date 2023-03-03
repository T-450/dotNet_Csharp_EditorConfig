namespace Microsoft.eShopOnContainers.WebMVC.Services
{
    using Order = ViewModels.Order;

    public class BasketService : IBasketService
    {
        private readonly HttpClient _apiClient;
        private readonly string _basketByPassUrl;
        private readonly ILogger<BasketService> _logger;
        private readonly string _purchaseUrl;
        private readonly IOptions<AppSettings> _settings;

        public BasketService(HttpClient httpClient, IOptions<AppSettings> settings, ILogger<BasketService> logger)
        {
            _apiClient = httpClient;
            _settings = settings;
            _logger = logger;

            _basketByPassUrl = $"{_settings.Value.PurchaseUrl}/b/api/v1/basket";
            _purchaseUrl = $"{_settings.Value.PurchaseUrl}/api/v1";
        }

        public async Task<Basket> GetBasket(ApplicationUser user)
        {
            string uri = API.Basket.GetBasket(_basketByPassUrl, user.Id);
            _logger.LogDebug("[GetBasket] -> Calling {Uri} to get the basket", uri);
            var response = await _apiClient.GetAsync(uri);
            _logger.LogDebug("[GetBasket] -> response code {StatusCode}", response.StatusCode);
            string responseString = await response.Content.ReadAsStringAsync();
            return string.IsNullOrEmpty(responseString) ?
                new Basket
                    { BuyerId = user.Id } :
                JsonSerializer.Deserialize<Basket>(responseString, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                });
        }

        public async Task<Basket> UpdateBasket(Basket basket)
        {
            string uri = API.Basket.UpdateBasket(_basketByPassUrl);

            var basketContent = new StringContent(JsonSerializer.Serialize(basket), Encoding.UTF8, "application/json");

            var response = await _apiClient.PostAsync(uri, basketContent);

            response.EnsureSuccessStatusCode();

            return basket;
        }

        public async Task Checkout(BasketDTO basket)
        {
            string uri = API.Basket.CheckoutBasket(_basketByPassUrl);
            var basketContent = new StringContent(JsonSerializer.Serialize(basket), Encoding.UTF8, "application/json");

            _logger.LogInformation("Uri chechout {uri}", uri);

            var response = await _apiClient.PostAsync(uri, basketContent);

            response.EnsureSuccessStatusCode();
        }

        public async Task<Basket> SetQuantities(ApplicationUser user, Dictionary<string, int> quantities)
        {
            string uri = API.Purchase.UpdateBasketItem(_purchaseUrl);

            var basketUpdate = new
            {
                BasketId = user.Id,
                Updates = quantities.Select(kvp => new
                {
                    BasketItemId = kvp.Key,
                    NewQty = kvp.Value,
                }).ToArray(),
            };

            var basketContent = new StringContent(JsonSerializer.Serialize(basketUpdate), Encoding.UTF8, "application/json");

            var response = await _apiClient.PutAsync(uri, basketContent);

            response.EnsureSuccessStatusCode();

            string jsonResponse = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<Basket>(jsonResponse, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            });
        }

        public async Task<Order> GetOrderDraft(string basketId)
        {
            string uri = API.Purchase.GetOrderDraft(_purchaseUrl, basketId);

            string responseString = await _apiClient.GetStringAsync(uri);

            var response = JsonSerializer.Deserialize<Order>(responseString, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            });

            return response;
        }

        public async Task AddItemToBasket(ApplicationUser user, int productId)
        {
            string uri = API.Purchase.AddItemToBasket(_purchaseUrl);

            var newItem = new
            {
                CatalogItemId = productId,
                BasketId = user.Id,
                Quantity = 1,
            };

            var basketContent = new StringContent(JsonSerializer.Serialize(newItem), Encoding.UTF8, "application/json");

            var response = await _apiClient.PostAsync(uri, basketContent);
        }
    }
}
