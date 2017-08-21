using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bridge.Models
{
    public class Resume
    {
        [Key]
        public int ResumeId { get; set; }

        [Required]
        [Display(Name = "Resume Name")]
        [StringLength(255)]
        public string ResumeName { get; set; }

        [StringLength(255)]
        public string FileName { get; set; }

        [StringLength(100)]
        public string ContentType { get; set; }

        public byte[] Content { get; set; }

        [Display(Name = "Date Uploaded")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime datetime { get; set; }

        public string CandidateId { get; set; }
        public virtual ApplicationUser Candidate { get; set; }

        public ICollection<Referral> Refferals { get; set; }

    }
}