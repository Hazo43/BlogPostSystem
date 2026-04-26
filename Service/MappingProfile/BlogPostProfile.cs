using AutoMapper;
using Domain.Entites;
using Shared.DTOs.BlogPostModule;

namespace Service.MappingProfile
{
    public class BlogPostProfile : Profile
    {
        public BlogPostProfile()
        {
            CreateMap<BlogPost, BlogPostResultDTO>()
                     .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString())) // Status -> Enum
                     .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.Name)) // Category
                     .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.User.UserName)) // User
                     .ForMember(dest => dest.Tags, opt => opt.MapFrom
                     (src => src.BlogPostTags.Select(bt => bt.Tag.Name).ToList()));                  // Tags
        }
    }
}
