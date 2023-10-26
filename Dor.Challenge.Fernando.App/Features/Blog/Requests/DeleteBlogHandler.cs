using Dor.Challenge.Fernando.App.Common.Interfaces.Persistance;
using Dor.Challenge.Fernando.Domain.Exceptions;
using Dor.Challenge.Fernando.Domain.Persistance.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dor.Challenge.Fernando.App.Features.Blog.Requests
{
    public class DeleteBlogRequest : IRequest
    {
        [FromQuery]
        public int ID { get; init; }
    }
    public class DeleteBlogHandler : IRequestHandler<DeleteBlogRequest>
    {
        private readonly IService<BlogEntity> blogService;

        public DeleteBlogHandler(IService<BlogEntity> blogService)
        {
            this.blogService = blogService;
        }

        public async Task Handle(DeleteBlogRequest request, CancellationToken cancellationToken)
        {
            var entity = await blogService.Get(b => b.ID == request.ID).SingleOrDefaultAsync(cancellationToken)
                ?? throw new NotFoundApiException($"Blog not found; ID: {request.ID}");

            blogService.Remove(entity!);

            await blogService.SaveChangesAsync(cancellationToken);
        }
    }
}
