using PictureSender.Client.Interfaces.APIServices;
using PictureSender.Client.RestApi.Base;
using PictureSender.Shared.Constants.ApiConstants;
using Serilog;
using System.Net.Http;

namespace PictureSender.Client.RestApi
{
    public class PictureDetailService : BaseApiService, IPictureDetailService
    {
        public PictureDetailService() : base(new HttpClient(), PictureDetailApiConstants.Controller)
        {

        }

        public async Task SavePictureDetail()
        {
            //var endpointUrl = GetEndpoint("package");
        }

        public async Task GetAllPictureDetail()
        {
            var endpointUrl = GetEndpoint(PictureDetailApiConstants.GetAllEndPoint);
            var httpRequest = CreateHttpRequest(endpointUrl, HttpMethod.Get);
            var httpResponse = await SendRequest(httpRequest);

            await DeserializeResponse<object>(httpResponse);
        }
    }
}
