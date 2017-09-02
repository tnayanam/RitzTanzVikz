using Foolproof;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Bridge.ViewModels
{
    public class ReferralViewModel
    {
        public int ReferralViewModelId { get; set; }

        public bool IsResumeExists { get; set; }

        public bool IsCoverLetterExists { get; set; }

        [RequiredIf("CompanyId", "4", ErrorMessage = "asdfsdfsa")]
        [Display(Name = "Other Company")]
        public string TempCompany { get; set; }

        [Display(Name = "Experience(months)")]
        [Range(0, int.MaxValue, ErrorMessage = "Experience should be greater than 0.")]
        public int Experience { get; set; }

        [Display(Name = "Referral Name")]
        public string ReferralName { get; set; }

        [Display(Name = "Resume Name")]
        public string ResumeName { get; set; }

        [Display(Name = "Resume")]
        [Required]
        public int ResumeId { get; set; }
        public IEnumerable<SelectListItem> Resumes { get; set; }

        [Display(Name = "Degree")]
        public int DegreeId { get; set; }
        public IEnumerable<SelectListItem> Degrees { get; set; }

        [Display(Name = "Skill")]
        public int SkillId { get; set; }
        public IEnumerable<SelectListItem> Skills { get; set; }

        [Display(Name = "Company Name")]
        [Required]
        public int? CompanyId { get; set; }
        public IEnumerable<SelectListItem> Companies { get; set; }

        // needs to have "?" because when no dropdown is selected we want to pass NULL values
        [Display(Name = "Cover Letter")]
        public int? CoverLetterId { get; set; }
        public IEnumerable<SelectListItem> CoverLetters { get; set; }
    }
}