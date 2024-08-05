using Microsoft.AspNetCore.Identity;
using SIMS.Models;

namespace SIMS.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Code { get; set; }

        public int RoleId { get; set; }
        public DateTime DoB {  get; set; }
        public string Address { get; set; }
        public int Gender { get; set; }
        public int DepartmentId { get; set; }
        public int MajorId { get; set; }
        public string IntialAdmissionCourse {  get; set; }

        public Roles Role {  get; set; }
    }

}
