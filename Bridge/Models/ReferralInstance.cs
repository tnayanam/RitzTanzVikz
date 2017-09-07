using System.ComponentModel.DataAnnotations;

namespace Bridge.Models
{
    public class ReferralInstance
    {
        [Key]
        public int ReferralInstanceId { get; set; }
        public string ReferralStatus { get; set; }

        public int ReferralId { get; set; }
        public virtual Referral Referral { get; set; }

        public string ReferrerId { get; set; }
        public virtual ApplicationUser Referrer { get; set; }

        [Required]
        public int? ReferralStatusId { get; set; }
        public virtual ReferralStatus ReferralState { get; set; }
    }
}