using AutoMapper;
using Dor.Challenge.Fernando.App.Features.Author.Requests.Bodies;
using Dor.Challenge.Fernando.App.Features.Blog.Requests.Bodies;
using Dor.Challenge.Fernando.Domain.Persistance.Entities;

namespace Dor.Challenge.Fernando.App.Common.Mappers
{
    public class BodyToEntityMapperProfile : Profile
    {
        public BodyToEntityMapperProfile()
        {
            CreateMap<AuthorBody, AuthorEntity>();
            CreateMap<BlogBody, BlogEntity>();
        }
    }
}
