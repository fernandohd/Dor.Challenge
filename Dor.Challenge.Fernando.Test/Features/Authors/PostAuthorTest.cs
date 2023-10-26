using Dor.Challenge.Fernando.App.Features.Author.Requests;
using Dor.Challenge.Fernando.Domain.Persistance.Entities;
using Dor.Challenge.Fernando.Infra.Persistance;

namespace Dor.Challenge.Fernando.Test.Features.Authors
{
    [Collection(nameof(TestFixture))]
    public class PostAuthorTest
    {
        private readonly PostAuthorHandler handler;

        public PostAuthorTest(TestFixture fixture)
        {
            var service = new Service<AuthorEntity>(fixture.repository);
            handler = new PostAuthorHandler(fixture.mapper, service);
        }

        [Fact]
        public async void PostAuthor_CorrectBodySent_ShouldAddAndReturnAuthor()
        {
            // Arrange
            var request = new PostAuthorRequest { Body = AuthorMock.AuthorBodyMock() };

            // Act
            var result = await handler.Handle(request, new CancellationToken());

            // Assert
            Assert.NotNull(result);
            Assert.NotEqual(0, result.ID);
        }
    }
}
