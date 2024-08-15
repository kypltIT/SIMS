using SIMS.Data;

namespace SIMS.Models

{
    public class Courses
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int SemesterId { get; set; }
        public Semesters Semester { get; set; }
        public string LecturerId { get; set; }
        public ApplicationUser Lecture { get; set; }
        public int SubjectId { get; set; }
        public Subjects Subject { get; set; }

        public string Code { get; set; }
        public string Status { get; set; }



    }
}
