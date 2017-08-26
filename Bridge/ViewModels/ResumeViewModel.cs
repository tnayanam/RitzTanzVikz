using Bridge.CustomValidation;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Bridge.ViewModels
{
    public class ResumeViewModel
    {
        [FileType("pdf|doc|docx|PDF", ErrorMessage = "File type is not valid.")]
        [Required]
        public HttpPostedFileBase UploadedResume { get; set; }
        [Required]
        public string ResumeName { get; set; }
    }
}