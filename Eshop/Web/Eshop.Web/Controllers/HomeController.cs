using Eshop.Services.Data.Contracts;
using System.Web.Mvc;

namespace Eshop.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IItemsService itemsService;

        public HomeController(IItemsService itemsService)
        {
            this.itemsService = itemsService;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult About()
        {
            this.ViewBag.Message = "Your application description page.";

            return this.View();
        }

        public ActionResult Contact()
        {
            this.ViewBag.Message = "Your contact page.";

            return this.View();
        }
    }
}