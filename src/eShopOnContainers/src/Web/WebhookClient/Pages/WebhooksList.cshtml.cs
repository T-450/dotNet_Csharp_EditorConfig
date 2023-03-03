namespace WebhookClient.Pages
{
    using Microsoft.AspNetCore.Mvc.RazorPages;

    public class WebhooksListModel : PageModel
    {
        private readonly IWebhooksClient _webhooksClient;

        public WebhooksListModel(IWebhooksClient webhooksClient)
        {
            _webhooksClient = webhooksClient;
        }

        public IEnumerable<WebhookResponse> Webhooks { get; private set; }

        public async Task OnGet()
        {
            Webhooks = await _webhooksClient.LoadWebhooks();
        }
    }
}
