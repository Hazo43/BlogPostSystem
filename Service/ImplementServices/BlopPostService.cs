using AutoMapper;
using Domain.Entites;
using Domain.Entites.Enums;
using Domain.Interfaces;
using Service.Specifications;
using ServiceAbstraction;
using ServiceAbstraction.Interfaces;
using Shared.DTOs.BlogPostModule;

namespace Service.ImplementServices
{
    public class BlopPostService : IBlopPostService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BlopPostService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<BlogPostResultDTO> CreateAsync(BlogPostRequestDTO blogDto)
        {

            // create 
            var post = new BlogPost
            {
                Title = blogDto.Title,
                AuthorId = blogDto.AuthorId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = null,
                CategoryId = blogDto.CategoryId,
                Content = blogDto.Content,
                Status = Enum.Parse<Status>(blogDto.Status),
                BlogPostTags = blogDto.TagIds.Select(tagId => new BlogPostTag
                {
                    TagId = tagId

                }).ToList(),

            };
            // Add
            await _unitOfWork.GetRepository<BlogPost, int>().AddAsync(post);
            // save
            await _unitOfWork.SaveChanges();
            // map from BlogPost To BlogPostResultDTO
            return _mapper.Map<BlogPostResultDTO>(post);
        }

        public async Task<bool> DeleteAsync(int postId)
        {
            var Repo = _unitOfWork.GetRepository<BlogPost, int>();

            var post = await Repo.GetByIdAsync(postId);
            if (post == null)
                return false;

            Repo.Delete(post);

            await _unitOfWork.SaveChanges();

            return true;
        }

        public async Task<IEnumerable<BlogPostResultDTO>> GetAllAsync(BlogPostSpecificationParameter parameter)
        {
            var specification = new BlogPostWithCategoryAndStatus(parameter);
            var Posts = await _unitOfWork.GetRepository<BlogPost, int>().GetAllAsync(specification);
            return _mapper.Map<IEnumerable<BlogPostResultDTO>>(Posts);
        }

        public async Task<BlogPostResultDTO?> GetByIdAsync(int postId)
        {
            var specification = new BlogPostWithCategoryAndStatus(postId);
            var post = await _unitOfWork.GetRepository<BlogPost, int>().GetByIdAsync(specification);
            if (post == null)
                return null;

            return _mapper.Map<BlogPostResultDTO>(post);
        }

        public async Task<BlogPostResultDTO> UpdateAsync(int postId, UpdateBlogPostDTO blogDTO)
        {

            var post = await _unitOfWork.GetRepository<BlogPost, int>().GetByIdAsync(postId);

            if (post is null)
                return null!;

            post.AuthorId = blogDTO.AuthorId;
            post.CategoryId = blogDTO.CategoryId;
            post.Status = Enum.Parse<Status>(blogDTO.Status);
            post.Title = blogDTO.Title;
            post.Content = blogDTO.Content;
            post.UpdatedAt = DateTime.UtcNow;

            // عشان ميحطش القديم ع الجديد update لازم امسح الداتا اللي جواه قبل ما اعمل
            post.BlogPostTags.Clear();

            foreach (var tagId in blogDTO.TagIds)
            {
                post.BlogPostTags.Add(new BlogPostTag
                {
                    TagId = tagId,
                    PostId = postId
                });
            }


            _unitOfWork.GetRepository<BlogPost, int>().Update(post);
            await _unitOfWork.SaveChanges();

            return _mapper.Map<BlogPostResultDTO>(post);
        }
    }
}
