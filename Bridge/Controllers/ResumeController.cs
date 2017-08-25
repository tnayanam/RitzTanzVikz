using Bridge.Models;
using Bridge.ViewModels;
using Microsoft.AspNet.Identity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Mvc;

namespace Bridge.Controllers
{
    //[Authorize(Roles = "Candidate")]
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
            var resumeList = _context.Resumes.Where(r => r.CandidateId == candidateId).OrderByDescending(r => r.datetime).ToList();
            return View(resumeList);
        }

        public FileContentResult Details(int? resumeId)
        {
            var temp = _context.Resumes.Where(f => f.ResumeId == resumeId).SingleOrDefault();
            var fileRes = new FileContentResult(temp.Content.ToArray(), temp.ContentType);
            fileRes.FileDownloadName = temp.FileName;
            return fileRes;
        }

        // Todo: Need to make it a POST Request
        public ActionResult Delete(int? resumeId)
        {
            var r = _context.Resumes.Where(c => c.ResumeId == resumeId);
            _context.Resumes.RemoveRange(r);
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
