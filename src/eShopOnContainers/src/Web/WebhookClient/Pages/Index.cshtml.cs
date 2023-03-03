namespace WebhookClient.Pages
{
    using Microsoft.AspNetCore.Mvc.RazorPages;

    public class IndexModel : PageModel
    {
        private readonly IHooksRepository _hooksRepository;

        public IndexModel(IHooksRepository hooksRepository)
        {
            _hooksRepository = hooksRepository;
        }

        public IEnumerable<WebHookReceived> WebHooksReceived { get; private set; }

        public async Task OnGet()
        {
            WebHooksReceived = await _hooksRepository.GetAll();
        }
    }
}
