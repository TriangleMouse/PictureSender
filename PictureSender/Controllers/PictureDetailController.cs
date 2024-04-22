using MediatR;
using Microsoft.AspNetCore.Mvc;
using PictureSender.Shared.Constants.ApiConstants;
using PictureSender.Shared.CQRS.Commands.Request;
using PictureSender.Shared.CQRS.Commands.Response;
using PictureSender.Shared.CQRS.Queries.Request;

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

        [HttpGet(PictureDetailApiConstants.GetAllEndPoint)]
        public async Task<IActionResult> GetAll([FromQuery] GetAllPictureDetailQueryRequest request)
        {
            var pictureDetails = await _mediator.Send(request);

            return Ok(pictureDetails);
        }

        [HttpPost(PictureDetailApiConstants.SaveEndPoint)]
        public async Task<IActionResult> Save([FromBody] CreatePictureDetailCommandRequest request)
        {
            CreatePictureDetailCommandResponse response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpDelete($"{PictureDetailApiConstants.DeleteEndPoint}/{{id}}")]
        public async Task<IActionResult> Delete([FromQuery] DeletePictureDetailCommandRequest request)
        {
            DeletePictureDetailCommandResponse response = await _mediator.Send(request);

            return Ok(response);
        }
    }
}
