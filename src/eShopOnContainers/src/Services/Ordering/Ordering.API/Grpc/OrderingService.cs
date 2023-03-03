namespace GrpcOrdering
{
    public class OrderingService : OrderingGrpc.OrderingGrpcBase
    {
        private readonly ILogger<OrderingService> _logger;
        private readonly IMediator _mediator;

        public OrderingService(IMediator mediator, ILogger<OrderingService> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        public override async Task<OrderDraftDTO> CreateOrderDraftFromBasketData(CreateOrderDraftCommand createOrderDraftCommand,
            ServerCallContext context)
        {
            _logger.LogInformation("Begin grpc call from method {Method} for ordering get order draft {CreateOrderDraftCommand}",
                context.Method, createOrderDraftCommand);
            _logger.LogTrace(
                "----- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
                createOrderDraftCommand.GetGenericTypeName(),
                nameof(createOrderDraftCommand.BuyerId),
                createOrderDraftCommand.BuyerId,
                createOrderDraftCommand);

            var command = new Microsoft.eShopOnContainers.Services.Ordering.API.Application.Commands.CreateOrderDraftCommand(
                createOrderDraftCommand.BuyerId,
                MapBasketItems(createOrderDraftCommand.Items));


            var data = await _mediator.Send(command);

            if (data != null)
            {
                context.Status = new Status(StatusCode.OK, $" ordering get order draft {createOrderDraftCommand} do exist");

                return MapResponse(data);
            }
            context.Status = new Status(StatusCode.NotFound, $" ordering get order draft {createOrderDraftCommand} do not exist");

            return new OrderDraftDTO();
        }

        public OrderDraftDTO MapResponse(Microsoft.eShopOnContainers.Services.Ordering.API.Application.Commands.OrderDraftDTO order)
        {
            var result = new OrderDraftDTO
            {
                Total = (double)order.Total,
            };

            order.OrderItems.ToList().ForEach(i => result.OrderItems.Add(new OrderItemDTO
            {
                Discount = (double)i.Discount,
                PictureUrl = i.PictureUrl,
                ProductId = i.ProductId,
                ProductName = i.ProductName,
                UnitPrice = (double)i.UnitPrice,
                Units = i.Units,
            }));

            return result;
        }

        public IEnumerable<Microsoft.eShopOnContainers.Services.Ordering.API.Application.Models.BasketItem> MapBasketItems(
            RepeatedField<BasketItem> items)
        {
            return items.Select(x => new Microsoft.eShopOnContainers.Services.Ordering.API.Application.Models.BasketItem
            {
                Id = x.Id,
                ProductId = x.ProductId,
                ProductName = x.ProductName,
                UnitPrice = (decimal)x.UnitPrice,
                OldUnitPrice = (decimal)x.OldUnitPrice,
                Quantity = x.Quantity,
                PictureUrl = x.PictureUrl,
            });
        }
    }
}
