using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bridge.Models
{
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }

        public ICollection<Referral> Referrals { get; set; }
        public ICollection<CoverLetter> CoverLetters { get; set; }
    }
}