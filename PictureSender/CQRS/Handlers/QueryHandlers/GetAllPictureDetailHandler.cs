﻿using MediatR;
using PictureSender.Shared.CQRS.Queries.Request;
using PictureSender.Shared.CQRS.Queries.Response;

namespace PictureSender.Server.CQRS.Handlers.QueryHandlers
{
    public class GetAllPictureDetailHandler : IRequestHandler<GetAllPictureDetailQueryRequest, List<GetAllPictureDetailQueryResponse>>
    {
        public GetAllPictureDetailHandler() { }

        public Task<List<GetAllPictureDetailQueryResponse>> Handle(GetAllPictureDetailQueryRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new List<GetAllPictureDetailQueryResponse>());
        }
    }
}
