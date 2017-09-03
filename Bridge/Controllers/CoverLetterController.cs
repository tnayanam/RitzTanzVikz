using Bridge.Models;
using Bridge.ViewModels;
using Microsoft.AspNet.Identity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Mvc;

namespace Bridge.Controllers
{
    public class CoverLetterController : Controller
    {

        private ApplicationDbContext _context;

        public CoverLetterController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Resume
        public ActionResult CoverLetterCenter()
        {
            var userId = User.Identity.GetUserId();
            var coverLetterList = _context.CoverLetters.Where(r => r.CandidateId == userId).OrderByDescending(r => r.datetime).ToList();
            return View(coverLetterList);
        }

        public FileContentResult Details(int? coverLetterId)
        {
            var temp = _context.CoverLetters.Where(f => f.CoverLetterId == coverLetterId).SingleOrDefault();
            var fileRes = new FileContentResult(temp.Content.ToArray(), temp.ContentType);
            fileRes.FileDownloadName = temp.FileName;
            return fileRes;
        }

        //[HttpPost]
        // ToDo Need to make it a post request
        public ActionResult Delete(int? coverLetterId)
        {
            var r = _context.CoverLetters.Where(c => c.CoverLetterId == coverLetterId);
            _context.CoverLetters.RemoveRange(r);
            _context.SaveChanges();
            return RedirectToAction("CoverLetterCenter");
        }

        public ActionResult UploadCoverLetter()
        {
            var viewModel = new CoverLetterViewModel
            {
                Companies = _context.Companies.Select(x => new SelectListItem
                {
                    Text = x.CompanyName,
                    Value = x.CompanyId.ToString()
                })
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UploadCoverLetter(CoverLetterViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (viewModel.UploadedCoverLetter != null && viewModel.UploadedCoverLetter.ContentLength > 0)
                    {
                        var tempcoverletter = new CoverLetter
                        {
                            FileName = System.IO.Path.GetFileName(viewModel.UploadedCoverLetter.FileName),
                            ContentType = viewModel.UploadedCoverLetter.ContentType,
                            CoverLetterName = viewModel.CoverLetterName,
                            CandidateId = User.Identity.GetUserId(),
                            datetime = System.DateTime.Now

                        };
                        if (!string.IsNullOrEmpty(viewModel.TempCompany))
                        {
                            var tempCompany = new Company { CompanyName = viewModel.TempCompany };
                            using (var reader = new System.IO.BinaryReader(viewModel.UploadedCoverLetter.InputStream))
                            {
                                tempcoverletter.Content = reader.ReadBytes(viewModel.UploadedCoverLetter.ContentLength);
                            }
                            tempCompany.CoverLetters.Add(tempcoverletter);
                            _context.Companies.Add(tempCompany);
                        }
                        else
                        {
                            tempcoverletter.CompanyId = viewModel.CompanyId;
                            using (var reader = new System.IO.BinaryReader(viewModel.UploadedCoverLetter.InputStream))
                            {
                                tempcoverletter.Content = reader.ReadBytes(viewModel.UploadedCoverLetter.ContentLength);
                            }
                            _context.CoverLetters.Add(tempcoverletter);
                        }
                    }
                    _context.SaveChanges();

                    return RedirectToAction("CoverLetterCenter");
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