using Bridge.CustomValidation;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Bridge.ViewModels
{
    public class CoverLetterViewModel
    {
        [Required(ErrorMessage = "Enter Cover Letter Name.")]
        [Display(Name = "CoverLetter Name")]
        public string CoverLetterName { get; set; }

        [FileType("pdf|doc|docx", ErrorMessage = "File type is not valid.")]
        [Required]
        [Display(Name = "Upload CoverLetter")]
        public HttpPostedFileBase UploadedCoverLetter { get; set; }
    }
}