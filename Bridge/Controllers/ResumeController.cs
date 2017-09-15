﻿using Bridge.Models;
using Bridge.ViewModels;
using Microsoft.AspNet.Identity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace Bridge.Controllers
{
    [Authorize(Roles = "Candidate")]
    public class ResumeController : Controller
    {
        private ApplicationDbContext _context;

        public ResumeController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult ResumeCenter()
        {
            var candidateId = User.Identity.GetUserId();
            var resumeList = _context
                .Resumes.Where(r => r.CandidateId == candidateId)
                .OrderByDescending(r => r.datetime);

            return View(resumeList);
        }

        public FileContentResult Download(int resumeId)
        {
            var temp = _context
                .Resumes.Where(f => f.ResumeId == resumeId).SingleOrDefault();
            var fileRes = new FileContentResult(temp.Content.ToArray(), temp.ContentType);
            fileRes.FileDownloadName = temp.FileName;

            return fileRes;
        }

        //ToDo: Need to code preview functionality.
        public FileStreamResult GetPDF(int resumeId)
        {
            var temp = _context.Resumes
                .Where(f => f.ResumeId == resumeId).SingleOrDefault();
            var fileRes = new FileContentResult(temp.Content.ToArray(), temp.ContentType);
            var streamResult = new FileStreamResult(new MemoryStream(fileRes.FileContents), fileRes.ContentType);

            return streamResult;
        }

        public FileContentResult Details(int resumeId)
        {
            var temp = _context.Resumes
                .Where(f => f.ResumeId == resumeId).Single();
            var fileRes = new FileContentResult(temp.Content.ToArray(), temp.ContentType);
            fileRes.FileDownloadName = temp.FileName;

            return fileRes;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int resumeId)
        {
            var r = _context.Resumes
                .Where(c => c.ResumeId == resumeId).Single();
            _context.Resumes.Remove(r);
            _context.SaveChanges();

            return RedirectToAction("ResumeCenter");
        }

        public ActionResult UploadResume()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UploadResume(ResumeViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (viewModel.UploadedResume != null && viewModel.UploadedResume.ContentLength > 0)
                    {
                        var tempresume = new Resume
                        {
                            FileName = System.IO.Path.GetFileName(viewModel.UploadedResume.FileName),
                            ContentType = viewModel.UploadedResume.ContentType,
                            ResumeName = viewModel.ResumeName,
                            CandidateId = User.Identity.GetUserId(),
                            datetime = System.DateTime.Now
                        };
                        using (var reader = new System.IO.BinaryReader(viewModel.UploadedResume.InputStream))
                        {
                            tempresume.Content = reader.ReadBytes(viewModel.UploadedResume.ContentLength);
                        }
                        _context.Resumes.Add(tempresume);
                    }
                    _context.SaveChanges();
                    return RedirectToAction("ResumeCenter");
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View();
        }
    }

}
