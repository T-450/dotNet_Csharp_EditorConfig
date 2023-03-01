using Microsoft.Extensions.Configuration.Json;

await BuildWebHost(args).RunAsync();

IWebHost BuildWebHost(string[] args)
{
    return WebHost
        .CreateDefaultBuilder(args)
        .ConfigureAppConfiguration(cb =>
        {
            var sources = cb.Sources;
            sources.Insert(3, new JsonConfigurationSource
            {
                Optional = true,
                Path = "appsettings.localhost.json",
                ReloadOnChange = false,
            });
        })
        .UseStartup<Startup>()
        .UseSerilog((builderContext, config) =>
        {
            config
                .MinimumLevel.Information()
                .Enrich.FromLogContext()
                .WriteTo.Console();
        })
        .Build();
}
