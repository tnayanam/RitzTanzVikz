using Bridge.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bridge.ViewModels
{
    public class ReferralViewModel
    {
        public int ReferralViewModelId { get; set; }

        public int Experience { get; set; }
        [Display(Name = "Referral Name")]
        public string ReferralName { get; set; }

        [Display(Name = "Resume Name")]
        public string ResumeName { get; set; }

        [Display(Name = "Resume")]
        public int ResumeId { get; set; }
        public IEnumerable<Resume> Resumes { get; set; }

        [Display(Name = "Degree")]
        public int DegreeId { get; set; }
        public IEnumerable<Degree> Degrees { get; set; }

        [Display(Name = "Skill")]
        public int SkillId { get; set; }
        public IEnumerable<Skill> Skills { get; set; }

        [Display(Name = "Company Name")]
        public int CompanyId { get; set; }
        public IEnumerable<Company> Companies { get; set; }

        [Display(Name = "Cover Letter")]
        public int CoverLetterId { get; set; }
        public IEnumerable<CoverLetter> CoverLetters { get; set; }
    }
}