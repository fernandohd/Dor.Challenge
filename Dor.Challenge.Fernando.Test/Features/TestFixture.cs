using AutoMapper;
using Dor.Challenge.Fernando.App.Common.Mappers;
using Dor.Challenge.Fernando.Domain.Persistance.Entities;
using Dor.Challenge.Fernando.Infra.Persistance;
using Microsoft.EntityFrameworkCore;

namespace Dor.Challenge.Fernando.Test.Features
{
    [CollectionDefinition(nameof(TestFixture))]
    public class CollectionFixture : ICollectionFixture<TestFixture> { }

    public class TestFixture : IDisposable
    {
        public readonly IRepository repository;
        public readonly IMapper mapper;

        public TestFixture()
        {
            mapper = new MapperConfiguration(c =>
            {
                c.AddProfile<BodyToEntityMapperProfile>();
                c.AddProfile<EntityToModelMapperProfile>();
            }).CreateMapper();

            IDorDbContext dbContext = new DorDbContext(new DbContextOptionsBuilder()
                .UseInMemoryDatabase("In-memory TestBlogDataBase").Options);
            repository = new Repository(dbContext);

            Init();
        }

        public async void Init()
        {
            repository.Command<AuthorEntity>().AddRange(AuthorMock.AuthorEntitiesMock());

            repository.Command<BlogEntity>().AddRange(BlogMock.BlogEntitiesMock());

            await repository.SaveChangesAsync();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
