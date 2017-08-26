using Bridge.CustomValidation;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;

namespace Bridge.ViewModels
{
    public class CoverLetterViewModel
    {
        public IEnumerable<SelectListItem> Companies { get; set; }
        public int CompanyId { get; set; }

        [Required(ErrorMessage = "Enter Cover Letter Name.")]
        [Display(Name = "CoverLetter Name")]
        public string CoverLetterName { get; set; }

        [FileType("pdf|doc|docx|PDF", ErrorMessage = "File type is not valid.")]
        [Required]
        [Display(Name = "Upload CoverLetter")]
        public HttpPostedFileBase UploadedCoverLetter { get; set; }
    }
}