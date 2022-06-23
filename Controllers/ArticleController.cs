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

        [HttpGet("{id}")]
        public async Task<ActionResult<Article>> Get(int    id)
        {
            var article = await _context.Articles.FindAsync(id);
            if (article == null)
                return BadRequest("Article not found.");
            return Ok(article);
        }
        [HttpPut]
        public async Task<ActionResult<List<Article>>> UpdateArticle(Article request)
        {
            var dbArticle = await _context.Articles.FindAsync(request.Id);
            if (dbArticle == null)
                return BadRequest("Article not found.");

            dbArticle.Title = request.Title;
            await _context.SaveChangesAsync();
            return Ok(await _context.Articles.ToListAsync());
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Article>>> Delete(int id)
        {
            var dbArticle = await _context.Articles.FindAsync(id);
            if (dbArticle == null)
                return BadRequest("Article not found.");

            _context.Articles.Remove(dbArticle);
            await _context.SaveChangesAsync();

            return Ok(await _context.Articles.ToListAsync());
        }
    }
}