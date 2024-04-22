using MediatR;
using PictureSender.Shared.CQRS.Queries.Response;

namespace PictureSender.Shared.CQRS.Queries.Request
{
    public class GetAllPictureDetailQueryRequest : IRequest<List<GetAllPictureDetailQueryResponse>>
    {
    }
}
