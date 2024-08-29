using Microsoft.AspNetCore.Identity;
using SIMS.Models;

namespace SIMS.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string Code { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Role { get; set; }

        public string IntialAdmissionCourse { get; set; }
        public string Status { get; set; }
    }

}
