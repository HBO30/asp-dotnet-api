using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperHerosSchool.data;

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