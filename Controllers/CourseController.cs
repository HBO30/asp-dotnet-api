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
        public async Task<ActionResult<List<Course>>> Get()
        {
            return Ok(await _context.Courses.ToListAsync());
        }
    }
}