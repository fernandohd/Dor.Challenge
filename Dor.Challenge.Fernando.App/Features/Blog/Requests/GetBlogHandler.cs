using AutoMapper;
using Dor.Challenge.Fernando.App.Common.Interfaces.Persistance;
using Dor.Challenge.Fernando.Domain.Models;
using Dor.Challenge.Fernando.Domain.Persistance.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dor.Challenge.Fernando.App.Features.Blog.Requests
{
    public class GetBlogRequest : IRequest<IEnumerable<BlogModel>>
    {
        [FromQuery]
        public IEnumerable<int>? ID { get; init; }
    }

    public class GetBlogHandler : IRequestHandler<GetBlogRequest, IEnumerable<BlogModel>>
    {
        private readonly IMapper mapper;
        private readonly IService<BlogEntity> blogService;

        public GetBlogHandler(IMapper mapper, IService<BlogEntity> blogService)
        {
            this.mapper = mapper;
            this.blogService = blogService;
        }

        public async Task<IEnumerable<BlogModel>> Handle(GetBlogRequest request, CancellationToken cancellationToken)
        {
            var entities = await blogService.Read(b => request.ID == null || !request.ID.Any() || request.ID.Contains(b.ID)).Include(b => b.Author).ToListAsync(cancellationToken);

            return mapper.Map<IEnumerable<BlogModel>>(entities);
        }
    }
}
