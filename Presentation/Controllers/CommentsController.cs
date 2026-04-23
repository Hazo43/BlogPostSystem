using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction.Interfaces;
using Shared.DTOs.CommentModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    public class CommentsController : ApiController
    {
        private readonly ICommentService _commentService;

        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        // Post => BaseUrl/api/Cpmments
        // [FromBody] Request  عشان الداتا هتتبعت في ال
        [HttpPost]
        public async Task<ActionResult<CommentResultDTO>> CreateComment([FromBody] CommentRequestDTO requestDTO)
        {
            var result = await _commentService.CreateComment(requestDTO);
            return Ok(result);
        }
        
        // Get => BaseUrl/api/Comments/{id}
        [HttpGet("{postId}")]
        public async Task<ActionResult<IEnumerable<CommentResultDTO>>> GetCommentByPostIdAsync(int postId )
        {
            var comments = await _commentService.GetCommentByPostId(postId);
            return Ok(comments);
        }

    }
}
