namespace UnitTest.Ordering
{
    using Order = Microsoft.eShopOnContainers.Services.Ordering.Domain.AggregatesModel.OrderAggregate.Order;

    public class AddressBuilder
    {
        public Address Build()
        {
            return new Address("street", "city", "state", "country", "zipcode");
        }
    }

    public class OrderBuilder
    {
        private readonly Order order;

        public OrderBuilder(Address address)
        {
            order = new Order(
                "userId",
                "fakeName",
                address,
                5,
                "12",
                "123",
                "name",
                DateTime.UtcNow);
        }

        public OrderBuilder AddOne(
            int productId,
            string productName,
            decimal unitPrice,
            decimal discount,
            string pictureUrl,
            int units = 1)
        {
            order.AddOrderItem(productId, productName, unitPrice, discount, pictureUrl, units);
            return this;
        }

        public Order Build()
        {
            return order;
        }
    }
}
