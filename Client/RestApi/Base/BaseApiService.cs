using System.Net;
using System.Net.Http;

namespace PictureSender.Client.RestApi.Base
{
    public abstract class BaseApiService
    {
        private string Context { get; set; }
        protected HttpClient HttpClient { get; }

        public BaseApiService()
        {

        }

        /// <summary>
        /// Gets final URL for concrete method of API.
        /// </summary>
        /// <param name="method"></param>
        /// <returns>The final URL to method.</returns>
        protected virtual Uri GetEndpoint(string method)
        {
            var url = new Uri(_Settings.BaseUrl + Context + method);

            return url;
        }

        /// <summary>
        /// Creates instance of Http request by input URL and HTTP method.
        /// </summary>
        /// <param name="url">The final URL for current request.</param>
        /// <param name="httpMethod">The http method.</param>
        /// <returns>The instance of Http request.</returns>
        protected virtual HttpRequestMessage CreateHttpRequest(Uri url, HttpMethod httpMethod)
        {
            var httpRequest = new HttpRequestMessage
            {
                Method = httpMethod,
                RequestUri = url
            };

            return httpRequest;
        }

        /// <summary>
        /// Sets content to the request.
        /// </summary>
        /// <typeparam name="T">The type of content.</typeparam>
        /// <param name="httpRequest">The current http request.</param>
        /// <param name="source">The model with data for current request.</param>
        /// <param name="contentType">The type of content.</param>
        protected void SetRequestContent<T>(HttpRequestMessage httpRequest, T source, string contentType)
        {
            if (source != null)
            {
                string requestContent = SafeJsonConvert.SerializeObject(source, SerializationSettings);
                httpRequest.Content = new StringContent(requestContent, System.Text.Encoding.UTF8);
            }

            if (!string.IsNullOrEmpty(contentType))
            {
                httpRequest.Content.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse(contentType);
            }
        }

        /// <summary>
        /// Sends request async.
        /// </summary>
        /// <param name="httpRequest">The current http request.</param>
        /// <returns>The http response.</returns>
        protected async Task<HttpResponseMessage> SendRequest(HttpRequestMessage httpRequest, ActionHttpRequestType actionType)
        {
            var dateNameFile = DateTime.Now.ToString("HH.mm.ss");

            if (_smdoSettings.IsDebugMode)
            {
                await JsonDebugModeHelper.WriteToRequest(httpRequest, _smdoSettings, actionType, dateNameFile);
            }
            var httpResponse = await HttpClient.SendAsync(httpRequest).ConfigureAwait(false);

            if (_smdoSettings.IsDebugMode)
            {
                await JsonDebugModeHelper.WriteToResponse(httpResponse, _smdoSettings, actionType, dateNameFile);
            }

            return httpResponse;
        }

        /// <summary>
        /// Deserializes response to concrete model or throw exception, if response status != 200,201,204.
        /// </summary>
        /// <typeparam name="T">The model type to which the response is deserialized.</typeparam>
        /// <param name="locationText">The text for error handler, shows where request are completing.</param>
        /// <param name="httpResponse">The http response.</param>
        /// <returns>The deserialized model from response.</returns>
        protected async Task<ResponseModel<T>> DeserializeResponse<T>(string locationText, HttpResponseMessage httpResponse)
        {
            if (!(httpResponse.StatusCode.Equals(HttpStatusCode.OK) || httpResponse.StatusCode.Equals(HttpStatusCode.Created)
                || httpResponse.StatusCode.Equals(HttpStatusCode.NoContent)))
            {
                await HttpErrorHandler.Handle(locationText, httpResponse);
            }

            var responseString = await httpResponse.Content.ReadAsStringAsync();
            ResponseModel<T> response = new ResponseModel<T>
            {
                StatusCode = httpResponse.StatusCode,
                Body = JsonConvert.DeserializeObject<T>(responseString, DeserializationSettings)
            };

            return response;
        }
    }
}
