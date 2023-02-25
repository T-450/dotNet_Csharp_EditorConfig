namespace Acme.BookStore.Data
{
    using Microsoft.EntityFrameworkCore;
    using Volo.Abp.DependencyInjection;

    public class BookStoreEFCoreDbSchemaMigrator : ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public BookStoreEFCoreDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the BookStoreDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<BookStoreDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}
