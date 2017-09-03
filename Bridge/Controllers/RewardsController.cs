using Bridge.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;

namespace Bridge.Controllers
{
    public class RewardsController : Controller
    {
        private ApplicationDbContext _context;

        public RewardsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Rewards
        public ActionResult ShowRewards()
        {
            var candidateId = User.Identity.GetUserId();
            var referrerCount = _context.Referrals.Where(r => (r.CandidateId == candidateId) && (!string.IsNullOrEmpty(r.ReferrerId))).Count();
            ViewBag.ReferrerCount = 10 - referrerCount;
            return View();
        }
    }
}