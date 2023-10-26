using AutoMapper;
using Dor.Challenge.Fernando.Domain.Models;
using Dor.Challenge.Fernando.Domain.Persistance.Entities;

namespace Dor.Challenge.Fernando.App.Common.Mappers
{
    public class EntityToModelMapperProfile : Profile
    {
        public EntityToModelMapperProfile()
        {
            AllowNullCollections = true;

            CreateMap<AuthorEntity, AuthorModel>();
            CreateMap<BlogEntity, BlogModel>();
        }
    }
}
