using Bridge.Models;
using Bridge.ViewModels;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace Bridge.Controllers
{
    //[Authorize(Roles = "Referrer")]
    [Authorize]
    public class ReferrerController : Controller
    {
        private ApplicationDbContext _context;

        public ReferrerController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Referrer
        public ActionResult ReferrerCenter()
        {
            var referrerId = User.Identity.GetUserId();
            var companyId = _context.Users
                .Where(r => r.Id == referrerId)
                .Select(r => r.CompanyId).Single();

            var referrals = _context.Referrals.Where(r => (r.CompanyId == companyId) && (!r.IsReferralSuccessful))
               .Include("Company")
               .Include("CoverLetter")
               .Include("Resume")
               .Include("Degree")
               .Include("Candidate");
            //var refer = _context.Referrals.Where(r => (r.CompanyId == companyId) && r.ReferralInstances.Any(e => (e.ReferrerId != null) && (e.ReferralStatus != "Referred")));

            return View(referrals);
        }


        //public ActionResult ReferralConfirmation(Referral referral)
        //{
        //    var referrals = _context.Referrals.Where(r => r.ReferralId == referral.ReferralId).SingleOrDefault();

        //    return View(referrals);
        //}

        public ActionResult ReferralConfirmation(Referral referral)
        {
            var viewModel = new ReferrerInstanceViewModel
            {
                ReferralId = referral.ReferralId,
                ReferralStatus = _context.ReferralStatus.Select(x => new SelectListItem
                {
                    Text = x.Status,
                    Value = x.ReferralStatusId.ToString()
                })
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ReferralConfirmation(Referral referral, HttpPostedFileBase upload)
        {
            var referrerId = User.Identity.GetUserId();
            var model = _context.Referrals.Where(r => r.ReferralId == referral.ReferralId).SingleOrDefault();

            var abc = new ReferralInstance();

            if (upload != null && upload.ContentLength > 0)
            {
                model.FileName = System.IO.Path.GetFileName(upload.FileName);
                model.ContentType = upload.ContentType;
                abc.ReferrerId = referrerId;
                abc.ReferralId = model.ReferralId;
                abc.ReferralStatus = "referred";
                using (var reader = new System.IO.BinaryReader(upload.InputStream))
                {
                    model.Content = reader.ReadBytes(upload.ContentLength);
                }
            }
            _context.ReferralInstances.Add(abc);
            _context.SaveChanges();

            return RedirectToAction("ReferrerCenter");
        }

        public ActionResult ReferredCandidates()
        {
            var referrerId = User.Identity.GetUserId();

            var referrals = _context.ReferralInstances
                 .Where(r => (r.ReferrerId == referrerId) && (r.ReferralStatus == "referred"))
                    .Select(r => r.Referral);
            return View(referrals);
        }

        public ActionResult Details(string candidateId)
        {
            var candidate = _context.Users.Where(u => u.Id == candidateId).SingleOrDefault();
            return View(candidate);
        }
    }
}