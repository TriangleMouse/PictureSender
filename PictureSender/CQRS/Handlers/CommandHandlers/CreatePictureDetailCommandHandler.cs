using MediatR;
using Microsoft.VisualBasic;
using PictureSender.Server.CQRS.Commands.Request;
using PictureSender.Server.CQRS.Commands.Response;

namespace PictureSender.Server.CQRS.Handlers.CommandHandlers
{
    public class CreatePictureDetailCommandHandler : IRequestHandler<CreatePictureDetailCommandRequest, CreatePictureDetailCommandResponse>
    {
        public CreatePictureDetailCommandHandler()
        {
        }

        public Task<CreatePictureDetailCommandResponse> Handle(CreatePictureDetailCommandRequest request, CancellationToken cancellationToken)
        {
            int idInformation = 0;
            return Task.FromResult(new CreatePictureDetailCommandResponse { IsSuccess = true, CreatedBookId = idInformation });
        }
    }
}
