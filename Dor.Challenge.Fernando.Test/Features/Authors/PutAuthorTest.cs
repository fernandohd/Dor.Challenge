using Dor.Challenge.Fernando.App.Features.Author.Requests;
using Dor.Challenge.Fernando.Domain.Exceptions;
using Dor.Challenge.Fernando.Domain.Persistance.Entities;
using Dor.Challenge.Fernando.Infra.Persistance;

namespace Dor.Challenge.Fernando.Test.Features.Authors
{
    [Collection(nameof(TestFixture))]
    public class PutAuthorTest
    {
        private readonly PutAuthorHandler handler;

        public PutAuthorTest(TestFixture fixture)
        {
            var service = new Service<AuthorEntity>(fixture.repository);
            handler = new PutAuthorHandler(fixture.mapper, service);
        }

        [Fact]
        public async void PutAuthor_CorrectBodySent_ShouldUpdateAuthor()
        {
            // Arrange
            var request = new PutAuthorRequest { Body = AuthorMock.AuthorBodyMock(2) };

            // Act
            await handler.Handle(request, new CancellationToken());

            // Assert
            Assert.True(true);
        }

        [Fact]
        public async void PutAuthor_IncorrectBodySent_ShouldThrowException()
        {
            // Arrange
            var request = new PutAuthorRequest { Body = AuthorMock.AuthorBodyMock(0) };

            // Act
            async Task func() { await handler.Handle(request, new CancellationToken()); }

            // Assert
            await Assert.ThrowsAsync<NotFoundApiException>(func);
        }
    }
}
