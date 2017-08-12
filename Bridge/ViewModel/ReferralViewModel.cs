using Bridge.Models;
using System.Collections.Generic;

namespace Bridge.ViewModels
{
    public class ReferralViewModel
    {
        public int Id { get; set; }
        public IEnumerable<Company> Companies { get; set; }
        public Referral Referral { get; set; }
        public int CompanyId { get; set; }
    }
}