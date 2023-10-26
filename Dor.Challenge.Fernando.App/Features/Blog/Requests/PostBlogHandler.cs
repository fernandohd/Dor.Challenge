using AutoMapper;
using Dor.Challenge.Fernando.App.Common.Interfaces.Persistance;
using Dor.Challenge.Fernando.App.Features.Blog.Requests.Bodies;
using Dor.Challenge.Fernando.Domain.Models;
using Dor.Challenge.Fernando.Domain.Persistance.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dor.Challenge.Fernando.App.Features.Blog.Requests
{
    public class PostBlogRequest : IRequest<BlogModel>
    {
        [FromBody]
        public BlogBody? Body { get; init; }
    }

    public class PostBlogHandler : IRequestHandler<PostBlogRequest, BlogModel>
    {
        private readonly IMapper mapper;
        private readonly IService<BlogEntity> blogService;

        public PostBlogHandler(IMapper mapper, IService<BlogEntity> blogService)
        {
            this.mapper = mapper;
            this.blogService = blogService;
        }

        public async Task<BlogModel> Handle(PostBlogRequest request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<BlogEntity>(request.Body);

            blogService.Add(entity);

            await blogService.SaveChangesAsync(cancellationToken);

            return mapper.Map<BlogModel>(entity);
        }
    }
}
