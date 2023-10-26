using AutoMapper;
using Dor.Challenge.Fernando.App.Common.Interfaces.Persistance;
using Dor.Challenge.Fernando.App.Features.Author.Requests.Bodies;
using Dor.Challenge.Fernando.Domain.Models;
using Dor.Challenge.Fernando.Domain.Persistance.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dor.Challenge.Fernando.App.Features.Author.Requests
{
    public class PostAuthorRequest : IRequest<AuthorModel>
    {
        [FromBody]
        public AuthorBody? Body { get; init; }
    }

    public class PostAuthorHandler : IRequestHandler<PostAuthorRequest, AuthorModel>
    {
        private readonly IMapper mapper;
        private readonly IService<AuthorEntity> authorService;

        public PostAuthorHandler(IMapper mapper, IService<AuthorEntity> authorService)
        {
            this.mapper = mapper;
            this.authorService = authorService;
        }

        public async Task<AuthorModel> Handle(PostAuthorRequest request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<AuthorEntity>(request.Body);

            authorService.Add(entity);

            await authorService.SaveChangesAsync(cancellationToken);

            return mapper.Map<AuthorModel>(entity);
        }
    }
}
