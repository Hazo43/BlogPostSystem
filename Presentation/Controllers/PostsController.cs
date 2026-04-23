using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction;
using ServiceAbstraction.Interfaces;
using Shared.DTOs.BlogPostModule;

namespace Presentation.Controllers
{
    public class PostsController : ApiController
    {
        private readonly IBlopPostService _postService;

        public PostsController(IBlopPostService postService)
        {
            _postService = postService;
        }

        // Get => BaseUrl/api/Post => GetAllPostes
        [HttpGet]
        public async Task<ActionResult<BlogPostResultDTO>> GetAllPostes([FromQuery] BlogPostSpecificationParameter parameter)
        {
            var result = await _postService.GetAllAsync(parameter);
            return Ok(result);
        }

        // Get => BaseUrl/api/Post/{id} 
        [HttpGet("{id:int}")]
        public async Task<ActionResult<BlogPostResultDTO?>> GetPostById(int id)
        {
            var result = await _postService.GetByIdAsync(id);
            return Ok(result);
        }

        // Post => BaseUrl/api/Post
        [HttpPost]
        public async Task<ActionResult<BlogPostResultDTO>> CreatePostAsync([FromBody]BlogPostRequestDTO blogPost)
        {
            var result = await _postService.CreateAsync(blogPost);
            return Ok(result);
        }

        // Put => BaseUrl/api/Post/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<BlogPostResultDTO>> UpdatePostAsync (int id , UpdateBlogPostDTO blogPostDTO )
        {
            var result = await _postService.UpdateAsync(id, blogPostDTO);
            return Ok(result);
        }

        // Delete => BaseUrl/api/Post/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePostByIdAsync(int id)
        {
            await _postService.DeleteAsync(id);
            return NoContent();
        }
    }
}
