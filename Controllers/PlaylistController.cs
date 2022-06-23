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
        public async Task<ActionResult<List<Playlist>>> AddPlaylist(Playlist playlist)
        {
            _context.Playlists.Add(playlist);
            await _context.SaveChangesAsync();

            return Ok(await _context.Playlists.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Playlist>> Get(int    id)
        {
            var playlist = await _context.Playlists.FindAsync(id);
            if (playlist == null)
                return BadRequest("Playlist not found.");
            return Ok(playlist);
        }
        [HttpPut]
        public async Task<ActionResult<List<Playlist>>> UpdatePlaylist(Playlist request)
        {
            var dbPlaylist = await _context.Playlists.FindAsync(request.Id);
            if (dbPlaylist == null)
                return BadRequest("Playlist not found.");

            dbPlaylist.Title = request.Title;
            await _context.SaveChangesAsync();
            return Ok(await _context.Playlists.ToListAsync());
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Playlist>>> Delete(int id)
        {
            var dbPlaylist = await _context.Playlists.FindAsync(id);
            if (dbPlaylist == null)
                return BadRequest("Playlist not found.");

            _context.Playlists.Remove(dbPlaylist);
            await _context.SaveChangesAsync();

            return Ok(await _context.Playlists.ToListAsync());
        }
    }
}