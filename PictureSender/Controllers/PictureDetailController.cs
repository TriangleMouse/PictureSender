using MediatR;
using Microsoft.AspNetCore.Mvc;
using PictureSender.Server.CQRS.Commands.Request;
using PictureSender.Server.CQRS.Commands.Response;
using PictureSender.Server.CQRS.Queries.Request;

namespace PictureSender.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PictureDetailController : Controller
    {
        private readonly IMediator _mediator;

        public PictureDetailController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllPictureDetailQueryRequest request)
        {
            var allBooks = await _mediator.Send(request);

            return Ok(allBooks);
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody] CreatePictureDetailCommandRequest request)
        {
            CreatePictureDetailCommandResponse response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromQuery] DeletePictureDetailCommandRequest request)
        {
            DeletePictureDetailCommandResponse response = await _mediator.Send(request);

            return Ok(response);
        }
    }
}
