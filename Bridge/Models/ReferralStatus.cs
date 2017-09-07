using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bridge.Models
{
    public class ReferralStatus
    {
        [Key]
        public int ReferralStatusId { get; set; }
        public string Status { get; set; }

        public ICollection<ReferralInstance> ReferralInstances { get; set; }
    }
}