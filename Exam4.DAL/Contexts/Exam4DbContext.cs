using Exam4.Core.Models;
using Exam4.Core.Models.Common;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Exam4.DAL.Contexts
{
    public class Exam4DbContext : IdentityDbContext
    {
        public Exam4DbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Expert> Experts { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<ExpertSocialMedia> ExpertSocialMedias { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Expert>()
                .HasMany(b => b.SocialMedias)
                .WithOne(b => b.Expert)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<SocialMedia>()
                .HasMany(b => b.Experts)
                .WithOne(b => b.SocialMedia)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }
    }
}
