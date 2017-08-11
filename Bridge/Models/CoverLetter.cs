using System;
using System.ComponentModel.DataAnnotations;

namespace Bridge.Models
{
    public class CoverLetter
    {
        public int Id { get; set; }
        [StringLength(255)]
        public string CoverLetterName { get; set; }
        [StringLength(255)]
        public string FileName { get; set; }
        [StringLength(100)]
        public string ContentType { get; set; }
        public byte[] Content { get; set; }
        [Display(Name = "Date Uploaded")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime datetime { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

    }
}