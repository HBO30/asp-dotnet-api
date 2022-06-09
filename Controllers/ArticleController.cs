using Microsoft.AspNetCore.Mvc;

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
        [HttpGet]
        public async Task<ActionResult<List<Article>>> Get()
        {
            return Ok(await _context.Articles.ToListAsync());
        }
        [HttpPost]
        public async Task<ActionResult<List<Article>>> AddArticle(Article article)
        {
            _context.Articles.Add(article);
            await _context.SaveChangesAsync();

            return Ok(await _context.Articles.ToListAsync());
        }
    }
}