using Bridge.CustomValidation;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;

namespace Bridge.ViewModels
{
    public class ReferrerInstanceViewModel
    {
        [Key]
        public int Id { get; set; }

        [FileType("pdf|doc|docx|PDF", ErrorMessage = "File type is not valid.")]
        [Required]
        public HttpPostedFileBase UploadedConfirmProof { get; set; }

        public IEnumerable<SelectListItem> ReferralStatus { get; set; }

        public int ReferralId { get; set; }

        public int ReferralStatusId { get; set; }

    }
}