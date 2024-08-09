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
        public int UserId { get; set; }
        public Users User { get; set; }
        public int SubjectId { get; set; }
        public Subjects Subject { get; set; }


    }
}
