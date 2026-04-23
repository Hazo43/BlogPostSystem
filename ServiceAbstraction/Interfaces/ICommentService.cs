using Shared.DTOs.CommentModule;

namespace ServiceAbstraction.Interfaces
{
    public interface ICommentService
    {
        // Create Comment 
        Task<CommentResultDTO> CreateComment(CommentRequestDTO requestDTO);

        // Get Comment By PostId
        Task<IEnumerable<CommentResultDTO>> GetCommentByPostId(int postId);
    }
}
