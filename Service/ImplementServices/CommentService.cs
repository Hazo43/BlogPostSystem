using AutoMapper;
using Domain.Entites;
using Domain.Interfaces;
using Service.Specifications;
using ServiceAbstraction.Interfaces;
using Shared.DTOs.CommentModule;

namespace Service.ImplementServices
{
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CommentService( IUnitOfWork unitOfWork , IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<CommentResultDTO> CreateComment(CommentRequestDTO requestDTO)
        {
            // Create
            var comment = new Comment()
            {
                Content = requestDTO.Content,
                CreatedAt = DateTime.UtcNow,
                AuthorId = requestDTO.AuthorId,
                PostId = requestDTO.PostId,
            };
            // Add
             await _unitOfWork.GetRepository<Comment , int>().AddAsync(comment);
            // Save
             await _unitOfWork.SaveChanges();
            // Map
             return _mapper.Map<CommentResultDTO>(comment);
        }

        public async Task<IEnumerable<CommentResultDTO>> GetCommentByPostId(int postId)
        {
           var spec = new CommentByPostIdSpecification(postId);
           var comment = await _unitOfWork.GetRepository<Comment, int>().GetAllAsync(spec);

            if (comment == null)
                return null!;

            return _mapper.Map<IEnumerable<CommentResultDTO>>(comment);
        }
    }
}
