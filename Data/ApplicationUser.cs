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
		public DateTime DoB { get; set; }
		public string Address { get; set; }
		public string Gender { get; set; }

		public int Phone { get; set; }

		public int MajorId { get; set; }
		public Majors Major { get; set; }
		public string IntialAdmissionCourse { get; set; }
		public string Status { get; set; }
	}

}
