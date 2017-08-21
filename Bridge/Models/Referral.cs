using System.ComponentModel.DataAnnotations;

namespace Bridge.Models
{
    public class Referral
    {
        [Key]
        public int ReferralId { get; set; }
        public string ReferralName { get; set; }

        public int DegreeId { get; set; }
        public virtual Degree Degree { get; set; }

        public int CoverLetterId { get; set; }
        public virtual CoverLetter CoverLetter { get; set; }

        public int ResumeId { get; set; }
        public virtual Resume Resume { get; set; }

        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }

        public string CandidateId { get; set; }
        public virtual ApplicationUser Candidate { get; set; }

        public string ReferrerId { get; set; }
        public virtual ApplicationUser Referrer { get; set; }
    }
}