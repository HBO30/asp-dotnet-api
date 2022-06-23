using Microsoft.AspNetCore.Mvc;

namespace SuperHerosSchool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly DataContext _context;
        public CourseController(DataContext context )
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Course>>> Get()
        {
            return Ok(await _context.Courses.ToListAsync());
        }
        [HttpPost]
        public async Task<ActionResult<List<Course>>> AddCourse(Course course)
        {
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();

            return Ok(await _context.Courses.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> Get(int    id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null)
                return BadRequest("Course not found.");
            return Ok(course);
        }
        [HttpPut]
        public async Task<ActionResult<List<Course>>> UpdateCourse(Course request)
        {
            var dbCourse = await _context.Courses.FindAsync(request.Id);
            if (dbCourse == null)
                return BadRequest("Course not found.");

            dbCourse.Title = request.Title;
            await _context.SaveChangesAsync();
            return Ok(await _context.Courses.ToListAsync());
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Course>>> Delete(int id)
        {
            var dbCourse = await _context.Courses.FindAsync(id);
            if (dbCourse == null)
                return BadRequest("Course not found.");

            _context.Courses.Remove(dbCourse);
            await _context.SaveChangesAsync();

            return Ok(await _context.Courses.ToListAsync());
        }
    }
}