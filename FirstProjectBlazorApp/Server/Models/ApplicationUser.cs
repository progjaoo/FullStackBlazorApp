using FirstProjectBlazorApp.Server.Entities;
using Microsoft.AspNetCore.Identity;

namespace FirstProjectBlazorApp.Server.Models
{
    public class ApplicationUser : IdentityUser
    {
        public List<JobApplication> JobApplications { get; private set; }
    }
}