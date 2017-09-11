﻿using Bridge.Models;
using Bridge.ViewModels;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using System.Linq;
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

        public ActionResult ReferrerCenter()
        {
            var referrerId = User.Identity.GetUserId();
            var companyId = _context.Users
                .Where(r => r.Id == referrerId)
                .Select(r => r.CompanyId).Single();

            var referrals = _context.Referrals
                .Where(r => ((r.CompanyId == companyId)
                && (!r.IsReferralSuccessful))
                && !r.ReferrerInstances.Any(e => (e.ReferrerId == referrerId) && (e.ReferralStatusId == 1)))
               .Include("Company")
               .Include("CoverLetter")
               .Include("Resume")
               .Include("Degree")
               .Include("Candidate");

            return View(referrals);
        }

        private void ConfigureViewModel(ReferrerInstanceViewModel viewModel)
        {
            viewModel.ReferralStatuses = _context.ReferralStatuses.Select(x => new SelectListItem
            {
                Text = x.ReferralStatusType,
                Value = x.ReferralStatusId.ToString()
            });
        }

        public ActionResult ReferralConfirmation(int referralId)
        {
            var viewModel = new ReferrerInstanceViewModel
            {
                ReferralId = referralId
            };
            ConfigureViewModel(viewModel);

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ReferralConfirmation(ReferrerInstanceViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                ConfigureViewModel(viewModel);
                return View(viewModel);
            }

            var referrerId = User.Identity.GetUserId();
            var referral = _context.Referrals
                .Where(r => r.ReferralId == viewModel.ReferralId).Single();

            var instance = new ReferrerInstance();
            if (viewModel.ReferralStatusId == 1)
            {
                instance.ReferrerId = referrerId;
                instance.ReferralId = viewModel.ReferralId;
                instance.ReferralStatusId = 1;
            }
            else if (viewModel.ReferralStatusId == 2)
            {
                if (viewModel.ProofDoc != null && viewModel.ProofDoc.ContentLength > 0)
                {
                    referral.FileName = System.IO.Path.GetFileName(viewModel.ProofDoc.FileName);
                    referral.ContentType = viewModel.ProofDoc.ContentType;
                    instance.ReferrerId = referrerId;
                    instance.ReferralId = referral.ReferralId;
                    instance.ReferralStatusId = 2;
                    using (var reader = new System.IO.BinaryReader(viewModel.ProofDoc.InputStream))
                    {
                        referral.Content = reader.ReadBytes(viewModel.ProofDoc.ContentLength);
                    }
                }
                referral.IsReferralSuccessful = true;
                referral.ReferrerId = referrerId;
            }
            else
                return RedirectToAction("ReferrerCenter");

            _context.ReferrerInstances.Add(instance);
            _context.SaveChanges();
            return RedirectToAction("ReferrerCenter");
        }

        public ActionResult Details(string candidateId)
        {
            var candidate = _context.Users
                .Where(u => u.Id == candidateId).SingleOrDefault();
            return View(candidate);
        }
    }
}