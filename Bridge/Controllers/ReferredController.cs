using Bridge.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;

namespace Bridge.Controllers
{
    public class ReferredController : Controller
    {
        private ApplicationDbContext _context;

        public ReferredController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Referred
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ReferredCandidates()
        {
            var referrerId = User.Identity.GetUserId();
            var referrals = _context.Referrals.Where(r => r.ReferrerId == referrerId);

            return View(referrals);
        }
    }
}