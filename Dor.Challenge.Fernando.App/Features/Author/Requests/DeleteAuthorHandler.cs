using Dor.Challenge.Fernando.App.Common.Interfaces.Persistance;
using Dor.Challenge.Fernando.Domain.Exceptions;
using Dor.Challenge.Fernando.Domain.Persistance.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dor.Challenge.Fernando.App.Features.Author.Requests
{
    public class DeleteAuthorRequest : IRequest
    {
        [FromQuery]
        public int ID { get; init; }
    }
    public class DeleteAuthorHandler : IRequestHandler<DeleteAuthorRequest>
    {
        private readonly IService<AuthorEntity> authorService;

        public DeleteAuthorHandler(IService<AuthorEntity> authorService)
        {
            this.authorService = authorService;
        }

        public async Task Handle(DeleteAuthorRequest request, CancellationToken cancellationToken)
        {
            var entity = await authorService.Get(b => b.ID == request.ID).SingleOrDefaultAsync(cancellationToken)
                ?? throw new NotFoundApiException($"Author not found; ID: {request.ID}");

            authorService.Remove(entity!);

            await authorService.SaveChangesAsync(cancellationToken);
        }
    }
}
