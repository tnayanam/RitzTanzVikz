using Bridge.Models;
using Bridge.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
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

        private void ConfigureViewModel(ReferralViewModel model)
        {
            var candidateId = User.Identity.GetUserId();
            model.Companies = _context.Companies.Select(x => new SelectListItem
            {
                Text = x.CompanyName,
                Value = x.CompanyId.ToString()
            });
            model.Degrees = _context.Degrees.Select(r => new SelectListItem
            {
                Text = r.DegreeName,
                Value = r.DegreeId.ToString()
            });
            model.Skills = _context.Skills.Select(r => new SelectListItem
            {
                Text = r.SkillName,
                Value = r.SkillId.ToString()
            });
            model.Resumes = _context.Resumes.Where(r => r.CandidateId == candidateId).Select(r => new SelectListItem
            {
                Text = r.ResumeName,
                Value = r.ResumeId.ToString()
            });

            if (model.Resumes.Count() > 0)
            {
                model.IsResumeExists = true;
            }

            if (model.CompanyId.HasValue)
            {
                model.CoverLetters = _context.CoverLetters.Where(r => r.CandidateId == candidateId && r.CompanyId == model.CompanyId).Select(c => new SelectListItem
                {
                    Text = c.CoverLetterName,
                    Value = c.CoverLetterId.ToString()
                });
            }
            else
            {
                model.CoverLetters = new SelectList(Enumerable.Empty<SelectListItem>());
            }
        }

        public ActionResult Create()
        {
            ReferralViewModel viewModel = new ReferralViewModel();
            ConfigureViewModel(viewModel);
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ReferralViewModel viewModel)
        {
            var candidateId = User.Identity.GetUserId();
            var referral = _context.Referrals
                     .Where(r => ((r.CandidateId == candidateId)
                      && (r.CompanyId == viewModel.CompanyId)
                      && (r.SkillId == viewModel.SkillId))).SingleOrDefault();
            if (referral != null)
            {
                referral.ResumeId = viewModel.ResumeId;
                referral.CoverLetterId = viewModel.CoverLetterId;
                referral.dateTime = DateTime.Now;
                referral.ReferralName = viewModel.ReferralName;
            }
            else
            {
                referral = new Referral
                {
                    ReferralName = viewModel.ReferralName,
                    ResumeId = viewModel.ResumeId,
                    CandidateId = candidateId,
                    DegreeId = viewModel.DegreeId,
                    CoverLetterId = viewModel.CoverLetterId,
                    SkillId = viewModel.SkillId.Value,
                    dateTime = DateTime.Now
                };

                if (!string.IsNullOrEmpty(viewModel.TempCompany))
                {
                    var newCompany = new Company
                    {
                        CompanyName = viewModel.TempCompany
                    };
                    newCompany.Referrals.Add(referral);
                    _context.Companies.Add(newCompany); ;
                }
                else
                {
                    referral.CompanyId = viewModel.CompanyId.Value;
                    _context.Referrals.Add(referral);
                }
            }
            _context.SaveChanges();

            return RedirectToAction("ReferralCenter");
        }

        // DELETE
        public ActionResult Delete(int referralId)
        {
            var r = _context.Referrals.Where(d => d.ReferralId == referralId);
            _context.Referrals.RemoveRange(r);
            _context.SaveChanges();

            return RedirectToAction("ReferralCenter");
        }

        [HttpPost]
        public JsonResult ListOfCoverLetterByCompanyId(int companyId)
        {
            var coverletters = _context.CoverLetters
                .Where(c => c.CompanyId == companyId)
                .ToList();

            var dropdown = new List<SelectListItem>();
            foreach (var cl in coverletters)
            {
                dropdown.Add(new SelectListItem { Text = cl.CoverLetterName, Value = cl.CoverLetterId.ToString() });
            }

            return Json(dropdown);
        }

        [HttpPost]
        public JsonResult CheckForExistingReferral(ReferralViewModel viewModel)
        {
            bool hasPreviousRequest = false;
            var candidateId = User.Identity.GetUserId();

            if (_context.Referrals
                .Any(r => ((r.CandidateId == candidateId)
                               && (r.CompanyId == viewModel.CompanyId)
                               && (r.SkillId == viewModel.SkillId))))
            {
                if (_context.Referrals
               .Any(r => ((r.CandidateId == candidateId)
                              && (r.CompanyId == viewModel.CompanyId)
                              && (r.SkillId == viewModel.SkillId))
                              && r.ReferralInstances
                              .Any(e => (e.ReferrerId != null) && (e.ReferralStatus == "Referred"))))
                {
                    hasPreviousRequest = false;
                }
                else
                    hasPreviousRequest = true;

            }

            return Json(new { hasPreviousRequest = hasPreviousRequest });
        }

    }
}