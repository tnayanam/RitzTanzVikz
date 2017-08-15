namespace Bridge.Models
{
    public class Referral
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string ReferralName { get; set; }
        public string UserId { get; set; }
        public int DegreeId { get; set; }
        public int ResumeId { get; set; }
        public Company Company { get; set; }
        public Resume Resume { get; set; }
    }
}