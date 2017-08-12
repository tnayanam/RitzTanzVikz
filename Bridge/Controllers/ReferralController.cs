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
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            var userId = User.Identity.GetUserId();
            var viewModel = new ReferralViewModel
            {
                Companies = _context.Companies.ToList(),
                Degrees = _context.Degrees.ToList(),
                Skills = _context.Skills.ToList(),
                Resumes = _context.Resumes.Where(r => r.UserId == userId).ToList()
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(ReferralViewModel viewModel)
        {
            var userId = User.Identity.GetUserId();
            var referral = new Referral
            {

            }
            return View(viewModel);
        }

    }
}