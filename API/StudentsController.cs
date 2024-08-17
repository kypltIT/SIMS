using SIMS.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIMS.Data;

namespace SIMS.API
{

    [Route("api/[controller]")]
    [ApiController]

    public class StudentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StudentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchStudents(string? term, int courseId)
        {
            var students = await _context.Users
            .Where(u => u.Role == "Student" &&
                            !_context.StudentCourses.Any(sc => sc.CourseId == courseId && sc.StudentId == u.Id) &&
                            (u.FirstName.Contains(term) || (u.LastName.Contains(term) || u.Email.Contains(term) || u.Code.Contains(term))))
                .Select(u => new { id = u.Id, text = u.FirstName + u.LastName + " (" + u.Email + ")" })
                .ToListAsync();

            return Ok(students);
        }
    }
}