using MediatR;
using PictureSender.Server.CQRS.Queries.Response;

namespace PictureSender.Server.CQRS.Queries.Request
{
    public class GetAllPictureDetailQueryRequest : IRequest<List<GetAllPictureDetailQueryResponse>>
    {
    }
}
