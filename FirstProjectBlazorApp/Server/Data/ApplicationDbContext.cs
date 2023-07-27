using Duende.IdentityServer.EntityFramework.Options;
using FirstProjectBlazorApp.Server.Entities;
using FirstProjectBlazorApp.Server.Models;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace FirstProjectBlazorApp.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
           DbContextOptions options,
           IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        public DbSet<Job> Jobs { get; set; }
        public DbSet<JobApplication> JobApplications { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>(e =>
            {
                e.HasMany(u => u.JobApplications)
                    .WithOne()
                    .HasForeignKey(ja => ja.UserId);
            });

            builder.Entity<Job>(e =>
            {
                e.HasKey(j => j.Id);

                e.HasMany(j => j.JobApplications)
                    .WithOne(ja => ja.Job)
                    .HasForeignKey(ja => ja.JobId);
            });

            builder.Entity<JobApplication>(e =>
            {
                e.HasKey(ja => ja.Id);
            });

            base.OnModelCreating(builder);
        }
    }
}