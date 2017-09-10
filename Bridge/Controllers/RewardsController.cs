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
            ViewBag.ReferrerCount = _context.Referrals
                .Where(s => s.CandidateId == candidateId
                && (s.IsReferralSuccessful)).Count();

            return View();
        }
    }
}