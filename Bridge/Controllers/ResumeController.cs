using Bridge.Models;
using Microsoft.AspNet.Identity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bridge.Controllers
{
    public class ResumeController : Controller
    {

        private ApplicationDbContext _context;

        public ResumeController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Resume
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var resumeList = _context.Resumes.Where(r => r.UserId == userId).ToList();
            return View(resumeList);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Resume resume, HttpPostedFileBase uploadedResume)
        {
            var x = User.Identity.GetUserId();
            try
            {
                if (ModelState.IsValid)
                {
                    if (uploadedResume != null && uploadedResume.ContentLength > 0)
                    {
                        var tempresume = new Resume
                        {
                            FileName = System.IO.Path.GetFileName(uploadedResume.FileName),
                            ContentType = uploadedResume.ContentType,
                            ResumeName = resume.ResumeName,
                            UserId = User.Identity.GetUserId(),
                            datetime = System.DateTime.Now
                        };
                        using (var reader = new System.IO.BinaryReader(uploadedResume.InputStream))
                        {
                            tempresume.Content = reader.ReadBytes(uploadedResume.ContentLength);
                        }
                        _context.Resumes.Add(tempresume);
                    }
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View("Index");
        }

        public FileContentResult Details(int? id)
        {
            var temp = _context.Resumes.Where(f => f.Id == id).SingleOrDefault();
            var fileRes = new FileContentResult(temp.Content.ToArray(), temp.ContentType);
            fileRes.FileDownloadName = temp.FileName;
            return fileRes;
        }

        public ActionResult Delete(int? id)
        {
            var r = _context.Resumes.Where(c => c.Id == id);
            _context.Resumes.RemoveRange(r);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
