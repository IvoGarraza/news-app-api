using app_news_api.Model;
using app_news_api.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace app_news_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : Controller
    {
        private readonly INewsRepository _newsRepository;

        public NewsController(INewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllNews()
        {
            var newsList = await _newsRepository.GetAllNews();
            return Ok(newsList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetNewsById(int id)
        {
            var newsList = await _newsRepository.GetNewsById(id);
            return Ok(newsList);
        }

        [HttpPost]
        public async Task<IActionResult> AddNews([FromBody] News news)
        {
            if (news == null)
            {
                return BadRequest("News object is null");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _newsRepository.AddNews(news);
            if (result)
            {
                return CreatedAtAction(nameof(GetNewsById), new { id = news.Id }, news);
            }
            return BadRequest("Error adding news");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateNews([FromBody] News news)
        {
            if (news == null)
            {
                return BadRequest("News object is null");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _newsRepository.UpdateNews(news);
            if (result)
            {
                return NoContent();
            }
            return BadRequest("Error adding news");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNews(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid news ID");
            }
            var result = await _newsRepository.DeleteNews(id);
            if (result)
            {
                return NoContent();
            }
            return NotFound("News not found");
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchNews([FromQuery] string? title, [FromQuery] string? author)
        {
            var allNews = await _newsRepository.GetAllNews();
            var filtered = allNews.Where(n =>
                (string.IsNullOrEmpty(title) || n.Title.Contains(title, StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrEmpty(author) || n.Author.Contains(author, StringComparison.OrdinalIgnoreCase))
            );
            return Ok(filtered);
        }

    }
}
