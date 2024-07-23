namespace SIMS.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public Roles Role { get; set; }
        public DateTime DoB {  get; set; }
        public string Address { get; set; }
        public int GenderId { get; set; }
        public Genders Gender { get; set; }

        public int Phone {  get; set; }

        public int MajorId { get; set; }
        public Majors Major { get; set; }
        public string IntialAdmissionCourse { get; set; }
    }
}
