using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using PictureSender.Client.Interfaces.APIServices;
using PictureSender.Client.RestApi.Base;
using Serilog;

namespace PictureSender.Client.RestApi
{
    public class PictureDetailService : BaseApiService, IPictureDetailService
    {
        public PictureDetailService() : base()
        {

        }

        /// <inheritdoc/>
        public async Task<ResponseModel<GetPackageResponse>> ReceiveOnePackage(int page, int size = 1)
        {
            var token = await GetToken();
            var getPackageRequest = new GetPackageRequest(page, size, true);
            var endpointUrl = GetEndpoint("package");
            var httpRequest = CreateHttpRequest(endpointUrl, HttpMethod.Post);

            SetHeaders(httpRequest, headers);
            SetRequestContent(httpRequest, getPackageRequest, "application/json");

            var httpResponse = await SendRequest(httpRequest, ActionHttpRequestType.GetPackage);

            var response = await DeserializeResponse<GetPackageResponse>(Resource.ReceiveOnePackageLocation, httpResponse);

            return response;
        }

        /// <inheritdoc/>
        public async Task ConfirmPackage(string packageGUID, string confirmId)
        {
            Log.Information(Resource.StartSendConfirmationInfoText, packageGUID);

            var token = await GetToken();
            var endpointUrl = GetEndpoint("package/confirm/" + confirmId);
            var headers = GetHeaders(token);
            var httpRequest = CreateHttpRequest(endpointUrl, HttpMethod.Get);

            SetHeaders(httpRequest, headers);

            var httpResponse = await SendRequest(httpRequest, ActionHttpRequestType.ConfirmPackage);

            await DeserializeResponse<object>(Resource.SendConfirmationLocation, httpResponse);
        }
    }
}
