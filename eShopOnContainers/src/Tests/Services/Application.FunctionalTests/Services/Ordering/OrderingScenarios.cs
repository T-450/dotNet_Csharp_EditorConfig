namespace FunctionalTests.Services.Ordering
{
    using BasketItem = Microsoft.eShopOnContainers.Services.Basket.API.Model.BasketItem;

    public class OrderingScenarios : OrderingScenariosBase
    {
        [Fact]
        public async Task Cancel_basket_and_check_order_status_cancelled()
        {
            using var orderServer = new OrderingScenariosBase().CreateServer();
            using var basketServer = new BasketScenariosBase().CreateServer();
            // Expected data
            var cityExpected = $"city-{Guid.NewGuid()}";
            var orderStatusExpected = "cancelled";

            var basketClient = basketServer.CreateIdempotentClient();
            var orderClient = orderServer.CreateIdempotentClient();

            // GIVEN a basket is created 
            var contentBasket = new StringContent(BuildBasket(), Encoding.UTF8, "application/json");
            await basketClient.PostAsync(BasketScenariosBase.Post.CreateBasket, contentBasket);

            // AND basket checkout is sent
            await basketClient.PostAsync(BasketScenariosBase.Post.CheckoutOrder,
                new StringContent(BuildCheckout(cityExpected), Encoding.UTF8, "application/json"));

            // WHEN Order is created in Ordering.api
            var newOrder = await TryGetNewOrderCreated(cityExpected, orderClient);

            // AND Order is cancelled in Ordering.api
            await orderClient.PutAsync(Put.CancelOrder,
                new StringContent(BuildCancelOrder(newOrder.OrderNumber), Encoding.UTF8, "application/json"));

            // AND the requested order is retrieved
            var order = await TryGetOrder(newOrder.OrderNumber, orderClient);

            // THEN check status
            Assert.Equal(orderStatusExpected, order.Status);
        }

        private async Task<Order> TryGetOrder(string orderNumber, HttpClient orderClient)
        {
            string ordersGetResponse = await orderClient.GetStringAsync(Get.Orders);
            var orders = JsonSerializer.Deserialize<List<Order>>(ordersGetResponse, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            });

            return orders.Single(o => o.OrderNumber == orderNumber);
        }

        private async Task<Order> TryGetNewOrderCreated(string city, HttpClient orderClient)
        {
            var counter = 0;
            Order order = null;

            while (counter < 20)
            {
                //get the orders and verify that the new order has been created
                string ordersGetResponse = await orderClient.GetStringAsync(Get.Orders);
                var orders = JsonSerializer.Deserialize<List<Order>>(ordersGetResponse, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                });

                if (orders == null || orders.Count == 0)
                {
                    counter++;
                    await Task.Delay(100);
                    continue;
                }

                var lastOrder = orders.OrderByDescending(o => o.Date).First();
                int.TryParse(lastOrder.OrderNumber, out int id);
                string orderDetails = await orderClient.GetStringAsync(Get.OrderBy(id));
                order = JsonSerializer.Deserialize<Order>(orderDetails, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                });

                order.City = city;

                if (IsOrderCreated(order, city))
                {
                    break;
                }
            }

            return order;
        }

        private bool IsOrderCreated(Order order, string city)
        {
            return order.City == city;
        }

        private string BuildBasket()
        {
            var order = new CustomerBasket("9e3163b9-1ae6-4652-9dc6-7898ab7b7a00");
            order.Items = new List<BasketItem>
            {
                new BasketItem
                {
                    Id = "1",
                    ProductName = "ProductName",
                    ProductId = 1,
                    UnitPrice = 10,
                    Quantity = 1,
                },
            };
            return JsonSerializer.Serialize(order);
        }

        private string BuildCancelOrder(string orderId)
        {
            var order = new OrderDTO
            {
                OrderNumber = orderId,
            };
            return JsonSerializer.Serialize(order);
        }

        private string BuildCheckout(string cityExpected)
        {
            var checkoutBasket = new BasketDTO
            {
                City = cityExpected,
                Street = "street",
                State = "state",
                Country = "coutry",
                ZipCode = "zipcode",
                CardNumber = "1111111111111",
                CardHolderName = "CardHolderName",
                CardExpiration = DateTime.Now.AddYears(1),
                CardSecurityNumber = "123",
                CardTypeId = 1,
                Buyer = "Buyer",
                RequestId = Guid.NewGuid(),
            };

            return JsonSerializer.Serialize(checkoutBasket);
        }
    }
}
