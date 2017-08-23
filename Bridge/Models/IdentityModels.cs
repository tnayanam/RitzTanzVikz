﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Bridge.Models
{
  
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Resume> Resumes { get; set; }
        public DbSet<CoverLetter> CoverLetters { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Referral> Referrals { get; set; }
        public DbSet<Degree> Degrees { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder dBModelBuilder)
        {
            // one usr can have many resumes
            dBModelBuilder.Entity<ApplicationUser>()
            .HasMany<Resume>(u => u.Resumes) // application user has many resumes
            .WithRequired(u => u.Candidate)   // each resume required one user
            .HasForeignKey(u => u.CandidateId);
            //.WillCascadeOnDelete(false);

            //// one user can have many coverletters
            dBModelBuilder.Entity<ApplicationUser>()
                 .HasMany<CoverLetter>(u => u.CoverLetters) // application user has many coveletter
                 .WithRequired(u => u.Candidate)   // each coverlletter required one user
                 .HasForeignKey(u => u.CandidateId);
            //     .WillCascadeOnDelete(false);

            //// one cover letter can be there in many referrals
            dBModelBuilder.Entity<CoverLetter>()
                .HasMany(u => u.Referrals)
                .WithRequired(u => u.CoverLetter)
                .HasForeignKey(u => u.CoverLetterId);

            // one resume can be there in many referrals
            dBModelBuilder.Entity<Resume>()
                .HasMany<Referral>(u => u.Refferals)
                .WithRequired(u => u.Resume)
                .HasForeignKey(u => u.ResumeId)
                 .WillCascadeOnDelete(false);

            // one referral has one company but one company can have many referrals
            dBModelBuilder.Entity<Company>()
                .HasMany(u => u.Referrals)
                .WithRequired(u => u.Company)
                .HasForeignKey(u => u.CompanyId);
            //.WillCascadeOnDelete(false);

            // one candidate can have many referrals
            dBModelBuilder.Entity<ApplicationUser>()
            .HasMany(u => u.CandidateReferral)
            .WithRequired(u => u.Candidate)
            .HasForeignKey(u => u.CandidateId)
            .WillCascadeOnDelete(false);

            //one referrer can have many referrals
            dBModelBuilder.Entity<ApplicationUser>()
            .HasMany(u => u.ReferrerReferral)
            .WithOptional(u => u.Referrer)
            .HasForeignKey(u => u.ReferrerId)
            .WillCascadeOnDelete(false);

            base.OnModelCreating(dBModelBuilder);
        }
    }
}