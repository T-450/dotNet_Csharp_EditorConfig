namespace Microsoft.eShopOnContainers.WebMVC.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<CatalogService> _logger;

        private readonly string _remoteServiceBaseUrl;
        private readonly IOptions<AppSettings> _settings;

        public CatalogService(HttpClient httpClient, ILogger<CatalogService> logger, IOptions<AppSettings> settings)
        {
            _httpClient = httpClient;
            _settings = settings;
            _logger = logger;

            _remoteServiceBaseUrl = $"{_settings.Value.PurchaseUrl}/c/api/v1/catalog/";
        }

        public async Task<Catalog> GetCatalogItems(int page, int take, int? brand, int? type)
        {
            string uri = API.Catalog.GetAllCatalogItems(_remoteServiceBaseUrl, page, take, brand, type);

            string responseString = await _httpClient.GetStringAsync(uri);

            var catalog = JsonSerializer.Deserialize<Catalog>(responseString, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            });

            return catalog;
        }

        public async Task<IEnumerable<SelectListItem>> GetBrands()
        {
            string uri = API.Catalog.GetAllBrands(_remoteServiceBaseUrl);

            string responseString = await _httpClient.GetStringAsync(uri);

            var items = new List<SelectListItem>();

            items.Add(new SelectListItem
                { Value = null, Text = "All", Selected = true });

            using var brands = JsonDocument.Parse(responseString);

            foreach (var brand in brands.RootElement.EnumerateArray())
            {
                items.Add(new SelectListItem
                {
                    Value = brand.GetProperty("id").ToString(),
                    Text = brand.GetProperty("brand").ToString(),
                });
            }

            return items;
        }

        public async Task<IEnumerable<SelectListItem>> GetTypes()
        {
            string uri = API.Catalog.GetAllTypes(_remoteServiceBaseUrl);

            string responseString = await _httpClient.GetStringAsync(uri);

            var items = new List<SelectListItem>();
            items.Add(new SelectListItem
                { Value = null, Text = "All", Selected = true });

            using var catalogTypes = JsonDocument.Parse(responseString);

            foreach (var catalogType in catalogTypes.RootElement.EnumerateArray())
            {
                items.Add(new SelectListItem
                {
                    Value = catalogType.GetProperty("id").ToString(),
                    Text = catalogType.GetProperty("type").ToString(),
                });
            }

            return items;
        }
    }
}
