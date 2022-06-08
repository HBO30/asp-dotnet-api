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
        public async Task<ActionResult<List<Playlist>>> Get()
        {
            return Ok(await _context.Playlists.ToListAsync());
        }
    }
}