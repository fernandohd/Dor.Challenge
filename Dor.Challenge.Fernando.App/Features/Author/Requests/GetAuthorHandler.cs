using AutoMapper;
using Dor.Challenge.Fernando.App.Common.Interfaces.Persistance;
using Dor.Challenge.Fernando.Domain.Models;
using Dor.Challenge.Fernando.Domain.Persistance.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dor.Challenge.Fernando.App.Features.Author.Requests
{
    public class GetAuthorRequest : IRequest<IEnumerable<AuthorModel>>
    {
        [FromQuery]
        public IEnumerable<int>? ID { get; init; }
    }

    public class GetAuthorHandler : IRequestHandler<GetAuthorRequest, IEnumerable<AuthorModel>>
    {
        private readonly IMapper mapper;
        private readonly IService<AuthorEntity> authorService;

        public GetAuthorHandler(IMapper mapper, IService<AuthorEntity> authorService)
        {
            this.mapper = mapper;
            this.authorService = authorService;
        }

        public async Task<IEnumerable<AuthorModel>> Handle(GetAuthorRequest request, CancellationToken cancellationToken)
        {
            var entities = await authorService.Read(a => request.ID == null || !request.ID.Any() || request.ID.Contains(a.ID)).Include(a => a.Blogs).ToListAsync(cancellationToken);

            return mapper.Map<IEnumerable<AuthorModel>>(entities);
        }
    }
}
