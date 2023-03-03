namespace WebhookClient.Pages
{
    using System.Net.Http.Formatting;
    using Microsoft.AspNetCore.Mvc.RazorPages;

    [Authorize]
    public class RegisterWebhookModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly Settings _settings;

        public RegisterWebhookModel(IOptions<Settings> settings, IHttpClientFactory httpClientFactory)
        {
            _settings = settings.Value;
            _httpClientFactory = httpClientFactory;
        }

        [BindProperty] public string Token { get; set; }

        public int ResponseCode { get; set; }
        public string RequestUrl { get; set; }
        public string GrantUrl { get; set; }
        public string ResponseMessage { get; set; }
        public string RequestBodyJson { get; set; }

        public void OnGet()
        {
            ResponseCode = (int)HttpStatusCode.OK;
            Token = _settings.Token;
        }

        public async Task<IActionResult> OnPost()
        {
            ResponseCode = (int)HttpStatusCode.OK;
            string protocol = Request.IsHttps ? "https" : "http";
            string selfurl = !string.IsNullOrEmpty(_settings.SelfUrl) ? _settings.SelfUrl
                : $"{protocol}://{Request.Host}/{Request.PathBase}";
            if (!selfurl.EndsWith("/"))
            {
                selfurl = selfurl + "/";
            }
            var granturl = $"{selfurl}check";
            var url = $"{selfurl}webhook-received";
            var client = _httpClientFactory.CreateClient("GrantClient");

            var payload = new WebhookSubscriptionRequest
            {
                Event = "OrderPaid",
                GrantUrl = granturl,
                Url = url,
                Token = Token,
            };
            var response = await client.PostAsync(_settings.WebhooksUrl + "/api/v1/webhooks", payload, new JsonMediaTypeFormatter());

            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("WebhooksList");
            }
            RequestBodyJson = JsonSerializer.Serialize(payload);
            ResponseCode = (int)response.StatusCode;
            ResponseMessage = response.ReasonPhrase;
            GrantUrl = granturl;
            RequestUrl = $"{response.RequestMessage.Method} {response.RequestMessage.RequestUri}";

            return Page();
        }
    }
}
