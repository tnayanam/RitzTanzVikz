using Bridge.Models;
using System.Collections.Generic;

namespace Bridge.ViewModels
{
    public class ReferralViewModel
    {
        public int Id { get; set; }
        public IEnumerable<Company> Companies { get; set; }
        public IEnumerable<Skill> Skills { get; set; }
        public IEnumerable<Degree> Degrees { get; set; }
        public IEnumerable<Resume> Resumes { get; set; }
        public Referral Referral { get; set; }
        public int CompanyId { get; set; }
        public int SkillId { get; set; }
        public int DegreeId { get; set; }
        public int Experience { get; set; }
        public int ResumeId { get; set; }
        public string ReferralName { get; set; }
        public string CompanyName { get; set; }
        public string SkillName { get; set; }
        public string DegreeName { get; set; }
        public string ResumeName { get; set; }
    }
}