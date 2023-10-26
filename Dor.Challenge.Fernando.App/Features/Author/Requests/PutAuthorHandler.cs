using AutoMapper;
using Dor.Challenge.Fernando.App.Common.Interfaces.Persistance;
using Dor.Challenge.Fernando.App.Features.Author.Requests.Bodies;
using Dor.Challenge.Fernando.Domain.Exceptions;
using Dor.Challenge.Fernando.Domain.Persistance.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dor.Challenge.Fernando.App.Features.Author.Requests
{
    public class PutAuthorRequest : IRequest
    {
        [FromBody]
        public AuthorBody? Body { get; init; }
    }

    public class PutAuthorHandler : IRequestHandler<PutAuthorRequest>
    {
        private readonly IMapper mapper;
        private readonly IService<AuthorEntity> authorService;

        public PutAuthorHandler(IMapper mapper, IService<AuthorEntity> authorService)
        {
            this.mapper = mapper;
            this.authorService = authorService;
        }

        public async Task Handle(PutAuthorRequest request, CancellationToken cancellationToken)
        {
            var entity = await authorService.Get(b => b.ID == request.Body!.ID).SingleOrDefaultAsync(cancellationToken)
                ?? throw new NotFoundApiException($"Author not found; ID: {request.Body!.ID}");

            mapper.Map(request.Body, entity);

            await authorService.SaveChangesAsync(cancellationToken);
        }
    }
}
