using MediatR;
using PictureSender.Shared.CQRS.Commands.Response;

namespace PictureSender.Shared.CQRS.Commands.Request
{
    public class DeletePictureDetailCommandRequest : IRequest<DeletePictureDetailCommandResponse>
    {
        public int PictureId { get; set; }
    }
}
