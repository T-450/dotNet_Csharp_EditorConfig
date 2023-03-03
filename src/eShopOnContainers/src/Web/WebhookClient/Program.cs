CreateWebHostBuilder(args).Build().Run();


IWebHostBuilder CreateWebHostBuilder(string[] args)
{
    return WebHost.CreateDefaultBuilder(args)
        .UseStartup<Startup>();
}
