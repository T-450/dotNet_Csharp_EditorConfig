namespace WebMVC.Services.ModelDTOs
{
    public record OrderProcessAction
    {
        public static OrderProcessAction Ship = new OrderProcessAction(nameof(Ship).ToLowerInvariant(), "Ship");

        protected OrderProcessAction() { }

        public OrderProcessAction(string code, string name)
        {
            Code = code;
            Name = name;
        }

        public string Code { get; }
        public string Name { get; }
    }
}
