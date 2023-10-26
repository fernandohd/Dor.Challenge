using Dor.Challenge.Fernando.App.Features.Author.Requests;
using Dor.Challenge.Fernando.Domain.Persistance.Entities;
using Dor.Challenge.Fernando.Infra.Persistance;

namespace Dor.Challenge.Fernando.Test.Features.Authors
{
    [Collection(nameof(TestFixture))]
    public class GetAuthorTest
    {
        private readonly GetAuthorHandler handler;

        public GetAuthorTest(TestFixture fixture)
        {
            var service = new Service<AuthorEntity>(fixture.repository);
            handler = new GetAuthorHandler(fixture.mapper, service);
        }

        [Fact]
        public async void GetAuthor_NoParametersSent_ShouldReturnAll()
        {
            // Arrange
            var request = new GetAuthorRequest();

            // Act
            var result = await handler.Handle(request, new CancellationToken());

            // Assert
            Assert.NotEmpty(result);
        }

        [Fact]
        public async void GetAuthor_CorrectIdSent_ShouldReturnAuthor()
        {
            // Arrange
            var request = new GetAuthorRequest { ID = new List<int> { 1 } };

            // Act
            var result = await handler.Handle(request, new CancellationToken());

            // Assert
            Assert.NotEmpty(result);
            Assert.Equal(request.ID.Count(), result.Count());
        }

        [Fact]
        public async void GetAuthor_WrongIdSent_ShouldReturnEmpty()
        {
            // Arrange
            var request = new GetAuthorRequest { ID = new List<int> { 3 } };

            // Act
            var result = await handler.Handle(request, new CancellationToken());

            // Assert
            Assert.Empty(result);
        }
    }
}
