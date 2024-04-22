using System.Net;
using System.Net.Http;
using PictureSender.Shared.Constants.ApiConstants;

namespace PictureSender.Client.RestApi.Base
{
    public abstract class BaseApiService
    {
        protected string Controller { get;}
        protected HttpClient HttpClient { get; }

        public BaseApiService(HttpClient httpClient, string controller)
        {
            HttpClient = httpClient;
            Controller = controller;
        }

        /// <summary>
        /// Возвращает окончательный URL-адрес для конкретного метода API.
        /// </summary>
        /// <param name="method"></param>
        /// <returns>Окончательный URL-адрес метода.</returns>
        protected virtual Uri GetEndpoint(string method)
        {
            var url = new Uri($"{BaseApiConstants.ApiBaseDomain}/{Controller}/{method}");

            return url;
        }

        /// <summary>
        /// Создает экземпляр Http-запроса с помощью входного URL-адреса и HTTP-метода.
        /// </summary>
        /// <param name="url">Окончательный URL-адрес для текущего запроса.</param>
        /// <param name="httpMethod">Http метод</param>
        /// <returns>Экземпляр http запроса</returns>
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
        /// Присваивает контент к запросу
        /// </summary>
        /// <typeparam name="T">Тип контента</typeparam>
        /// <param name="httpRequest">Текущий http запрос</param>
        /// <param name="source">Модель с данными</param>
        /// <param name="contentType">Тип контента</param>
        protected void SetRequestContent<T>(HttpRequestMessage httpRequest, T source, string contentType)
        {
            if (source != null)
            {
                string requestContent = SafeJsonConvert.SerializeObject(source);
                httpRequest.Content = new StringContent(requestContent, System.Text.Encoding.UTF8);
            }

            if (!string.IsNullOrEmpty(contentType))
            {
                httpRequest.Content.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse(contentType);
            }
        }

        /// <summary>
        /// Отправляет запрос
        /// </summary>
        /// <param name="httpRequest">Запрос</param>
        /// <returns>Ответ от сервера/returns>
        protected async Task<HttpResponseMessage> SendRequest(HttpRequestMessage httpRequest)
        {
            var httpResponse = await HttpClient.SendAsync(httpRequest).ConfigureAwait(false);

            return httpResponse;
        }

        /// <summary>
        /// Дессериализует ответ от сервера
        /// </summary>
        /// <typeparam name="T">Модель для дессериализации.</typeparam>
        /// <param name="httpResponse">Http ответ.</param>
        /// <returns>Дессериализованная модель.</returns>
        protected async Task<ResponseModel<T>> DeserializeResponse<T>(HttpResponseMessage httpResponse)
        {
            var responseString = await httpResponse.Content.ReadAsStringAsync();
            ResponseModel<T> response = new ResponseModel<T>
            {
                StatusCode = httpResponse.StatusCode,
                Body = JsonConvert.DeserializeObject<T>(responseString)
            };

            return response;
        }
    }
}
