using AutoMapper;
using Dor.Challenge.Fernando.App.Common.Interfaces.Persistance;
using Dor.Challenge.Fernando.App.Features.Blog.Requests.Bodies;
using Dor.Challenge.Fernando.Domain.Exceptions;
using Dor.Challenge.Fernando.Domain.Persistance.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dor.Challenge.Fernando.App.Features.Blog.Requests
{
    public class PutBlogRequest : IRequest
    {
        [FromBody]
        public BlogBody? Body { get; init; }
    }

    public class PutBlogHandler : IRequestHandler<PutBlogRequest>
    {
        private readonly IMapper mapper;
        private readonly IService<BlogEntity> blogService;

        public PutBlogHandler(IMapper mapper, IService<BlogEntity> blogService)
        {
            this.mapper = mapper;
            this.blogService = blogService;
        }

        public async Task Handle(PutBlogRequest request, CancellationToken cancellationToken)
        {
            var entity = await blogService.Get(b => b.ID == request.Body!.ID).SingleOrDefaultAsync(cancellationToken)
                ?? throw new NotFoundApiException($"Blog not found; ID: {request.Body!.ID}");

            mapper.Map(request.Body, entity);

            await blogService.SaveChangesAsync(cancellationToken);
        }
    }
}
