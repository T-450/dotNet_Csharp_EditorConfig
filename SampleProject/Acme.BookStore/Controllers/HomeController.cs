namespace Acme.BookStore.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Volo.Abp.AspNetCore.Mvc;

    public class HomeController : AbpController
    {
        public ActionResult Index()
        {
            return Redirect("~/swagger");
        }
    }
}
