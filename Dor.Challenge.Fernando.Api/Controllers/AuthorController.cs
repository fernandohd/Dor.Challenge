using Dor.Challenge.Fernando.App.Features.Author.Requests;
using Dor.Challenge.Fernando.Domain.Exceptions;
using Dor.Challenge.Fernando.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dor.Challenge.Fernando.Api.Controllers
{
    /// <summary>
    /// Controller to manage Authors
    /// </summary>
    [ApiController]
    [Produces("application/json")]
    [Route("[controller]")]
    [ProducesResponseType(typeof(BadRequestApiException), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(NotFoundApiException), StatusCodes.Status404NotFound)]
    public class AuthorController : ControllerBase
    {
        private readonly IMediator mediator;

        /// <summary>
        /// Initialize instance of <see cref="AuthorController"/> class using the contract of mediator.
        /// </summary>
        /// <param name="mediator"></param>
        public AuthorController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>Create an author based on the sent object</summary>
        /// <remarks>
        /// Example request:
        /// 
        ///     <![CDATA[POST Author
        ///     {
        ///        "id": "321654",
        ///        "name": "Mario Benedetti",
        ///        "nationality": "Uruguayan"
        ///     }]]>
        ///     
        /// </remarks>
        /// <returns>Author created</returns>
        [HttpPost]
        [ProducesResponseType(typeof(AuthorModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(PostAuthorRequest request)
        {
            var result = await mediator.Send(request);

            return Ok(result);
        }

        /// <summary>Get authors by IDs, returns all if no parameters are sent</summary>
        /// <remarks>
        /// Consulta de ejemplo:
        /// 
        ///     <![CDATA[GET Author?ID=321654]]>
        ///     
        /// </remarks>
        /// <returns>Collection of authors</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<AuthorModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(IEnumerable<AuthorModel>), StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Get(GetAuthorRequest request)
        {
            var result = await mediator.Send(request);

            return result.Any() ? Ok(result) : NoContent();
        }

        /// <summary>Update an author based on the sent object</summary>
        /// <remarks>
        /// Example request:
        /// 
        ///     <![CDATA[PUT Author
        ///     {
        ///         "id": 321654,
        ///         "name": "Mario Benedetti",
        ///         "nationality": "Uruguayan"
        ///     }]]>
        ///     
        /// </remarks>
        /// <returns>Action result</returns>
        [HttpPut]
        [ProducesResponseType(typeof(IActionResult), StatusCodes.Status200OK)]
        public async Task<IActionResult> Put(PutAuthorRequest request)
        {
            await mediator.Send(request);

            return Ok();
        }

        /// <summary>Delete an author by ID</summary>
        /// <remarks>
        /// Consulta de ejemplo:
        /// 
        ///     <![CDATA[DELETE Author?ID=321654]]>
        ///     
        /// </remarks>
        /// <returns>Action result</returns>
        [HttpDelete]
        [ProducesResponseType(typeof(IActionResult), StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(DeleteAuthorRequest request)
        {
            await mediator.Send(request);

            return Ok();
        }
    }
}