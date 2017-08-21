using Bridge.Models;
using Bridge.ViewModels;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;

namespace Bridge.Controllers
{
    public class ReferralController : Controller
    {
        private ApplicationDbContext _context;

        public ReferralController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Referral
        public ActionResult ReferralCenter()
        {
            var candidateId = User.Identity.GetUserId();
            var viewModel = _context.Referrals
                .Include("Company")
                .Include("Resume")
                .Include("CoverLetter")
                .Where(r => r.CandidateId == candidateId).ToList();

            return View(viewModel);
        }

        public ActionResult Create()
        {
            var candidateId = User.Identity.GetUserId();
            var viewModel = new ReferralViewModel
            {
                Companies = _context.Companies.ToList(),
                Degrees = _context.Degrees.ToList(),
                Skills = _context.Skills.ToList(),
                Resumes = _context.Resumes.Where(r => r.CandidateId == candidateId).ToList(),
                CoverLetters = _context.CoverLetters.Where(r => r.CandidateId == candidateId).ToList()
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ReferralViewModel viewModel)
        {
            var candidateId = User.Identity.GetUserId();
            var referral = new Referral
            {
                CompanyId = viewModel.CompanyId,
                ReferralName = viewModel.ReferralName,
                ResumeId = viewModel.ResumeId,
                CandidateId = candidateId,
                DegreeId = viewModel.DegreeId,
                CoverLetterId = viewModel.CoverLetterId
            };
            _context.Referrals.Add(referral);
            _context.SaveChanges();
            return RedirectToAction("ReferralCenter");
        }
    }
}