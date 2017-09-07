using Bridge.Models;
using Microsoft.AspNet.Identity;
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
            // _context.Referrals.Where(s => s.CandidateId == candidateId && (s.ReferralInstances.Any(c => c.ReferralStatus)));
            return View();
        }
    }
}