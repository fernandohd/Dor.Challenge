using Dor.Challenge.Fernando.App.Features.Blog.Requests;
using Dor.Challenge.Fernando.Domain.Exceptions;
using Dor.Challenge.Fernando.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dor.Challenge.Fernando.Api.Controllers
{
    /// <summary>
    /// Controller to manage blogs
    /// </summary>
    [ApiController]
    [Produces("application/json")]
    [Route("[controller]")]
    [ProducesResponseType(typeof(BadRequestApiException), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(NotFoundApiException), StatusCodes.Status404NotFound)]
    public class BlogController : ControllerBase
    {
        private readonly IMediator mediator;

        /// <summary>
        /// Initialize instance of <see cref="BlogController"/> class using the contract of mediator.
        /// </summary>
        /// <param name="mediator"></param>
        public BlogController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>Create a blog based on the sent object</summary>
        /// <remarks>
        /// Example request:
        /// 
        ///     <![CDATA[POST Blog
        ///     {
        ///         "title": "Lorem ipsum",
        ///         "content": "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
        ///         "authorId": 321654
        ///     }]]>
        ///     
        /// </remarks>
        /// <returns>Blog created</returns>
        [HttpPost]
        [ProducesResponseType(typeof(BlogModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(PostBlogRequest request)
        {
            var result = await mediator.Send(request);

            return Ok(result);
        }

        /// <summary>Get blogs by IDs, returns all if no parameters are sent</summary>
        /// <remarks>
        /// Consulta de ejemplo:
        /// 
        ///     <![CDATA[GET Blog?ID=1&ID=2]]>
        ///     
        /// </remarks>
        /// <returns>Collection of blogs</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<BlogModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(IEnumerable<BlogModel>), StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Get(GetBlogRequest request)
        {
            var result = await mediator.Send(request);

            return result.Any() ? Ok(result) : NoContent();
        }

        /// <summary>Update a blog based on the sent object</summary>
        /// <remarks>
        /// Example request:
        /// 
        ///     <![CDATA[PUT Blog
        ///     {
        ///         "id": 1,
        ///         "title": "Lorem ipsum",
        ///         "content": "Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
        ///         "authorId": 321654
        ///     }]]>
        ///     
        /// </remarks>
        /// <returns>Action result</returns>
        [HttpPut]
        [ProducesResponseType(typeof(IActionResult), StatusCodes.Status200OK)]
        public async Task<IActionResult> Put(PutBlogRequest request)
        {
            await mediator.Send(request);

            return Ok();
        }

        /// <summary>Delete a blog by ID</summary>
        /// <remarks>
        /// Consulta de ejemplo:
        /// 
        ///     <![CDATA[DELETE Blog?ID=1]]>
        ///     
        /// </remarks>
        /// <returns>Action result</returns>
        [HttpDelete]
        [ProducesResponseType(typeof(IActionResult), StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(DeleteBlogRequest request)
        {
            await mediator.Send(request);

            return Ok();
        }
    }
}