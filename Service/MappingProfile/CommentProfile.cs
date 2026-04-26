using AutoMapper;
using Domain.Entites;
using Shared.DTOs.CommentModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.MappingProfile
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<Comment, CommentResultDTO>()
                .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.User.UserName))
                .ForMember(dest => dest.PostTitle, opt => opt.MapFrom(src => src.BlogPost.Title));
     
        }
    }
}
