using MediatR;
using PictureSender.Server.CQRS.Commands.Response;

namespace PictureSender.Server.CQRS.Commands.Request
{
    public class CreatePictureDetailCommandRequest : IRequest<CreatePictureDetailCommandResponse>
    {
        public string Description { get; set; }
        public byte[] PictureContent { get; set; }
    }
}
