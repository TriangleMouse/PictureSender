using MediatR;
using PictureSender.Shared.CQRS.Commands.Response;

namespace PictureSender.Shared.CQRS.Commands.Request
{
    public class CreatePictureDetailCommandRequest : IRequest<CreatePictureDetailCommandResponse>
    {
        public string Description { get; set; }
        public byte[] PictureContent { get; set; }
    }
}
