using Microsoft.AspNetCore.Mvc;


namespace SuperHerosSchool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaylistController : ControllerBase
    {
        private readonly DataContext _context;
        public PlaylistController(DataContext context )
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Playlist>>> Get()
        {
            return Ok(await _context.Playlists.ToListAsync());
        }
        [HttpPost]
           public async Task<ActionResult<List<Playlist>>> AddPlaylist(Course course)
        {
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();

            return Ok(await _context.Courses.ToListAsync());
        }
    }
}