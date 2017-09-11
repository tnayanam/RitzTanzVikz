﻿using Bridge.CustomValidation;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;

namespace Bridge.ViewModels
{
    public class ReferrerInstanceViewModel
    {
        [Key]
        public int Id { get; set; }

        [FileType("pdf|doc|docx|PDF|jpg|jpeg|JPG|jpeg", ErrorMessage = "File type is not valid.")]
        [Required]
        public HttpPostedFileBase ProofDoc { get; set; }

        [Required]
        public int ReferralId { get; set; }

        [Required]
        public int? ReferralStatusId { get; set; }
        public IEnumerable<SelectListItem> ReferralStatuses { get; set; }

    }
}