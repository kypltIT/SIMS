namespace SIMS.Models
{
    public class Semesters
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string Code { get; set; }
    }
}
