using System.Web.Mvc;

namespace Bridge.Controllers
{
    [Authorize(Roles = "Referrer")]
    public class ReferrerController : Controller
    {
        // GET: Referrer
        public ActionResult Index()
        {
            return View();
        }
    }
}