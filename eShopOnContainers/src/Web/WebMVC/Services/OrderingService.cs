namespace Microsoft.eShopOnContainers.WebMVC.Services
{
    using System.Net;
    using Order = ViewModels.Order;

    public class OrderingService : IOrderingService
    {
        private readonly string _remoteServiceBaseUrl;
        private readonly IOptions<AppSettings> _settings;
        private readonly HttpClient _httpClient;


        public OrderingService(HttpClient httpClient, IOptions<AppSettings> settings)
        {
            _httpClient = httpClient;
            _settings = settings;

            _remoteServiceBaseUrl = $"{settings.Value.PurchaseUrl}/o/api/v1/orders";
        }

        public async Task<Order> GetOrder(ApplicationUser user, string id)
        {
            string uri = API.Order.GetOrder(_remoteServiceBaseUrl, id);

            string responseString = await _httpClient.GetStringAsync(uri);

            var response = JsonSerializer.Deserialize<Order>(responseString, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            });

            return response;
        }

        public async Task<List<Order>> GetMyOrders(ApplicationUser user)
        {
            string uri = API.Order.GetAllMyOrders(_remoteServiceBaseUrl);

            string responseString = await _httpClient.GetStringAsync(uri);

            var response = JsonSerializer.Deserialize<List<Order>>(responseString, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            });

            return response;
        }


        public async Task CancelOrder(string orderId)
        {
            var order = new OrderDTO
            {
                OrderNumber = orderId,
            };

            string uri = API.Order.CancelOrder(_remoteServiceBaseUrl);
            var orderContent = new StringContent(JsonSerializer.Serialize(order), Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync(uri, orderContent);

            if (response.StatusCode == HttpStatusCode.InternalServerError)
            {
                throw new Exception("Error cancelling order, try later.");
            }

            response.EnsureSuccessStatusCode();
        }

        public async Task ShipOrder(string orderId)
        {
            var order = new OrderDTO
            {
                OrderNumber = orderId,
            };

            string uri = API.Order.ShipOrder(_remoteServiceBaseUrl);
            var orderContent = new StringContent(JsonSerializer.Serialize(order), Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync(uri, orderContent);

            if (response.StatusCode == HttpStatusCode.InternalServerError)
            {
                throw new Exception("Error in ship order process, try later.");
            }

            response.EnsureSuccessStatusCode();
        }

        public void OverrideUserInfoIntoOrder(Order original, Order destination)
        {
            destination.City = original.City;
            destination.Street = original.Street;
            destination.State = original.State;
            destination.Country = original.Country;
            destination.ZipCode = original.ZipCode;

            destination.CardNumber = original.CardNumber;
            destination.CardHolderName = original.CardHolderName;
            destination.CardExpiration = original.CardExpiration;
            destination.CardSecurityNumber = original.CardSecurityNumber;
        }

        public Order MapUserInfoIntoOrder(ApplicationUser user, Order order)
        {
            order.City = user.City;
            order.Street = user.Street;
            order.State = user.State;
            order.Country = user.Country;
            order.ZipCode = user.ZipCode;

            order.CardNumber = user.CardNumber;
            order.CardHolderName = user.CardHolderName;
            order.CardExpiration =
                new DateTime(int.Parse("20" + user.Expiration.Split('/')[1]), int.Parse(user.Expiration.Split('/')[0]), 1);
            order.CardSecurityNumber = user.SecurityNumber;

            return order;
        }

        public BasketDTO MapOrderToBasket(Order order)
        {
            order.CardExpirationApiFormat();

            return new BasketDTO
            {
                City = order.City,
                Street = order.Street,
                State = order.State,
                Country = order.Country,
                ZipCode = order.ZipCode,
                CardNumber = order.CardNumber,
                CardHolderName = order.CardHolderName,
                CardExpiration = order.CardExpiration,
                CardSecurityNumber = order.CardSecurityNumber,
                CardTypeId = 1,
                Buyer = order.Buyer,
                RequestId = order.RequestId,
            };
        }
    }
}
