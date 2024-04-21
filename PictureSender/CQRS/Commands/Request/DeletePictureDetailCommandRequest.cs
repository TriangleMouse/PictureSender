using MediatR;
using PictureSender.Server.CQRS.Commands.Response;

namespace PictureSender.Server.CQRS.Commands.Request
{
    public class DeletePictureDetailCommandRequest : IRequest<DeletePictureDetailCommandResponse>
    {
        public int PictureId { get; set; }
    }
}
