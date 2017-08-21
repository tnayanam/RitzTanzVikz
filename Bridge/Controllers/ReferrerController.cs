using System.Web.Mvc;

namespace Bridge.Controllers
{
    //[Authorize(Roles = "Referrer")]
    public class ReferrerController : Controller
    {
        // GET: Referrer
        public ActionResult ReferrerCenter()
        {
            return View();
        }
    }
}