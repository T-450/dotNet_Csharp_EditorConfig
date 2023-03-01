namespace Microsoft.eShopOnContainers.Services.Ordering.SignalrHub.AutofacModules
{
    using Module = Autofac.Module;

    public class ApplicationModule
        : Module
    {
        public string QueriesConnectionString { get; }

        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterAssemblyTypes(typeof(OrderStatusChangedToAwaitingValidationIntegrationEvent).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(IIntegrationEventHandler<>));

        }
    }
}
