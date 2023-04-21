using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using SharedCode.Interfaces;
using SharedCode.Utils;

namespace SharedCode.Managers
{
	public class NetworkHandlerManager : INetworkHandler
    {
        private static HttpClient httpClient = new HttpClient();

        public async Task<T> GetData<T>(string endpoint)
        {
            var response = new HttpResponseMessage();
            try
            {
                response = await httpClient.GetAsync(endpoint);
                return await response.Content.ReadFromJsonAsync<T>();
            }
            catch (Exception ex)
            {
                CheckNetworkException(response);
                throw ex;
            }
        }

        public async Task<byte[]> LoadImage(string imageUrl)
        {
            try
            {
                Task<byte[]> contentsTask = httpClient.GetByteArrayAsync(imageUrl);
                return await contentsTask;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CheckNetworkException(HttpResponseMessage response)
        {
            switch (response.StatusCode)
            {
                case HttpStatusCode.BadRequest:
                    throw NetworkErrors.BadRequest;
                case HttpStatusCode.NotFound:
                    throw NetworkErrors.NotFound;
                case var expression when response.StatusCode >= HttpStatusCode.InternalServerError:
                    throw NetworkErrors.InternalServerError;
            }
        }
    }
}

