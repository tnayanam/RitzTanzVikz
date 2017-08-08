using Bridge.Models;
using System.Data.Entity.Infrastructure;
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
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Resume resume, HttpPostedFileBase uploadedResume)
        {
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
                            ResumeName = resume.ResumeName
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
    }
}
