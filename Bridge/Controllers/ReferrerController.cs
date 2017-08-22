using Bridge.Models;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using System.Linq;
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
            var referrals = _context.Referrals.Where(r => r.CompanyId == companyId)
           .Include("Company")
            .Include("CoverLetter")
            .Include("Resume")
            .Include("Degree")
            .Include("Candidate");
            return View(referrals);
        }
    }
}