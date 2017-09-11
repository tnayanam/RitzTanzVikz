using System.ComponentModel.DataAnnotations;

namespace Bridge.Models
{
    public class ReferrerInstance
    {
        [Key]
        public int ReferrerInstanceId { get; set; }

        [Required]
        public int ReferralId { get; set; }
        public virtual Referral Referral { get; set; }

        [Required]
        public string ReferrerId { get; set; }
        public virtual ApplicationUser Referrer { get; set; }

        [Required]
        public int ReferralStatusId { get; set; }
        public virtual ReferralStatus ReferralStatus { get; set; }
    }
}