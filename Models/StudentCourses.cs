namespace SIMS.Models
{
    public class StudentCourses
    {
        public int Id { get; set; }
        public int Grade { get; set; }
        public string Note { get; set; }
        public int UserId { get; set; }

        public Users User { get; set; }

        public int CourseId { get; set; }
        public Courses Course { get; set; }



    }
}
