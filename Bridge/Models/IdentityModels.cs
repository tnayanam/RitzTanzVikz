using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Bridge.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Resume> Resumes { get; set; }
        public ICollection<CoverLetter> CoverLetters { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Resume> Resumes { get; set; }
        public DbSet<CoverLetter> CoverLetters { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Referral> Referrals { get; set; }
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
            .WithRequired(u => u.User)   // each resume required one user
            .HasForeignKey(u => u.UserId)
            .WillCascadeOnDelete(false);

            // one user can have many coverletters
            dBModelBuilder.Entity<ApplicationUser>()
                 .HasMany<CoverLetter>(u => u.CoverLetters) // application user has many coveletter
                 .WithRequired(u => u.User)   // each coverlletter required one user
                 .HasForeignKey(u => u.UserId)
                 .WillCascadeOnDelete(false);


            base.OnModelCreating(dBModelBuilder);

            //dBModelBuilder.Entity<Resume>().HasRequired(x => x.User);
            //dBModelBuilder.Entity<CoverLetter>().HasRequired(x => x.User);
        }
    }
}