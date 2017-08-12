using Bridge.Models;
using Bridge.ViewModels;
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
            var viewModel = new ReferralViewModel
            {
                Companies = _context.Companies.ToList()
            };
            return View(viewModel);
        }

    }
}