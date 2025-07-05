using Microsoft.AspNetCore.Mvc;

namespace app_news_api.Controllers
{
    public class NewsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
