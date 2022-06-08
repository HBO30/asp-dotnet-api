using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperHerosSchool.data;

namespace SuperHerosSchool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly DataContext _context;
        public ArticleController(DataContext context )
        {
            _context = context;
        }
        public async Task<ActionResult<List<Article>>> Get()
        {
            return Ok(await _context.Articles.ToListAsync());
        }
    }
}