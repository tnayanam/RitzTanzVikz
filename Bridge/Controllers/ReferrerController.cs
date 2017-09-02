using Bridge.Models;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace Bridge.Controllers
{
    //[Authorize(Roles = "Referrer")]
    public class ReferrerController : Controller
    {

        private ApplicationDbContext _context { get; set; }

        public ReferrerController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Referrer
        public ActionResult ReferrerCenter()
        {
            var referrerId = User.Identity.GetUserId();
            var companyId = _context.Users.Where(r => r.Id == referrerId).Select(r => r.CompanyId).SingleOrDefault();
            var referrals = _context.Referrals.Where(r => r.CompanyId == companyId && r.ReferrerId == null)
           .Include("Company")
            .Include("CoverLetter")
            .Include("Resume")
            .Include("Degree")
            .Include("Candidate");
            return View(referrals);
        }

        //public ActionResult ReferralConfirmation(int referralId)
        //{
        //    var referrals = _context.Referrals.Where(r => r.ReferralId == referralId);

        //    return View(referrals);
        //}

        public ActionResult ReferralConfirmation(Referral referral)
        {
            var referrals = _context.Referrals.Where(r => r.ReferralId == referral.ReferralId).SingleOrDefault();

            return View(referrals);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ReferralConfirmation(Referral referral, HttpPostedFileBase upload)
        {
            var referrerId = User.Identity.GetUserId();
            var model = _context.Referrals.Where(r => r.ReferralId == referral.ReferralId).SingleOrDefault();

            if (upload != null && upload.ContentLength > 0)
            {
                model.FileName = System.IO.Path.GetFileName(upload.FileName);
                model.ContentType = upload.ContentType;
                model.ReferrerId = referrerId;
                using (var reader = new System.IO.BinaryReader(upload.InputStream))
                {
                    model.Content = reader.ReadBytes(upload.ContentLength);
                }
            }
            _context.SaveChanges();

            return RedirectToAction("ReferralCenter");
        }

        public ActionResult ReferredCandidates()
        {
            var referrerId = User.Identity.GetUserId();
            var referrals = _context.Referrals.Where(r => r.ReferrerId == referrerId);

            return View(referrals);
        }

        public ActionResult Details(string candidateId)
        {
            var candidate = _context.Users.Where(u => u.Id == candidateId).SingleOrDefault();
            return View(candidate);
        }
    }
}