using MediatR;
using PictureSender.Shared.CQRS.Commands.Request;
using PictureSender.Shared.CQRS.Commands.Response;

namespace PictureSender.Server.CQRS.Handlers.CommandHandlers
{
    public class DeletePictureDetailCommandHandler : IRequestHandler<DeletePictureDetailCommandRequest, DeletePictureDetailCommandResponse>
    {
        public DeletePictureDetailCommandHandler() 
        {
            
        }

        public Task<DeletePictureDetailCommandResponse> Handle(DeletePictureDetailCommandRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new DeletePictureDetailCommandResponse { IsSuccess = true });
        }
    }
}
