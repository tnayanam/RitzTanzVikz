using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bridge.Models
{
    public class ReferralStatus
    {
        [Key]
        public int ReferralStatusId { get; set; }

        public string ReferralStatusType { get; set; }

        public ICollection<ReferrerInstance> ReferrerInstances { get; set; }
    }
}