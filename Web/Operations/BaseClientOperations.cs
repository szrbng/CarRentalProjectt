using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Web.Operations
{
    public class BaseClientOperations : HttpClient
    {
        private HttpClient _client;
        private JsonSerializer _serializer;

        public BaseClientOperations(HttpClient client, JsonSerializer serializer)
        {
            _client = client;
            _serializer = serializer;
        }

        public async Task<TResponse> Get<TResponse>(string path, string parameters, CancellationToken cancellationToken = default(CancellationToken))
        {
            string reqPath = path;
            if (parameters != "")
            {
                reqPath += "?" + parameters;
            }
            var request = new HttpRequestMessage(HttpMethod.Get, reqPath);
            TResponse result = (TResponse)Activator.CreateInstance(typeof(TResponse));// default(TResponse);
            try
            {
                var response = await _client.SendAsync(request, cancellationToken);

                if (response.IsSuccessStatusCode)
                {

                    using (var streamReader = new StreamReader(await response.Content.ReadAsStreamAsync()))
                    using (var jsonTextReader = new JsonTextReader(streamReader))
                    {
                        result = _serializer.Deserialize<TResponse>(jsonTextReader);
                    }
                }
                else
                {
                }
                response.Dispose();
            }
            catch (Exception ex)
            {
            }
            finally
            {
                request.Dispose();
            }
            return result;
        }

        public async Task<TResponse> Post<TResponse, TRequest>(string path, TRequest model, IHeaderDictionary headers = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new HttpRequestMessage(HttpMethod.Post, $"{path}");
            TResponse result = (TResponse)Activator.CreateInstance(typeof(TResponse));
            var requestContent = JsonConvert.SerializeObject(model);

            try
            {
                if (model != null)
                {
                    request.Content = new StringContent(requestContent, Encoding.UTF8);
                    request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    request.Headers.TryAddWithoutValidation("User-Agent", "crmpanel");
                    //request.Content.Headers.ContentLength = requestContent.Length;
                }
                else
                {
                    request.Content = new StringContent("{}", Encoding.UTF8, "application/json");
                    request.Headers.TryAddWithoutValidation("User-Agent", "crmpanel");

                }

                var response = await _client.SendAsync(request, CancellationToken.None);

                if (response.IsSuccessStatusCode)
                {

                    using (var streamReader = new StreamReader(await response.Content.ReadAsStreamAsync()))
                    using (var jsonTextReader = new JsonTextReader(streamReader))
                    {
                        result = _serializer.Deserialize<TResponse>(jsonTextReader);

                    }
                }
                else
                {

                }
                response.Dispose();
            }
            catch (Exception ex)
            {

            }

            finally
            {
                request.Dispose();
            }
            return result;
        }

        public async Task<TResponse> Put<TResponse, TRequest>(string path, TRequest model, HttpRequestHeaders headers = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new HttpRequestMessage(HttpMethod.Put, $"{path}");
            TResponse result = (TResponse)Activator.CreateInstance(typeof(TResponse));
            var requestContent = JsonConvert.SerializeObject(model);
            try
            {

                request.Content = new StringContent(requestContent);
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var response = await _client.SendAsync(request, CancellationToken.None);

                if (response.IsSuccessStatusCode)
                {

                    using (var streamReader = new StreamReader(await response.Content.ReadAsStreamAsync()))
                    using (var jsonTextReader = new JsonTextReader(streamReader))
                    {
                        result = _serializer.Deserialize<TResponse>(jsonTextReader);
                    }
                }
                else
                {
                }
                response.Dispose();
            }
            catch (Exception ex)
            {
            }

            finally
            {
                request.Dispose();
            }
            return result;
        }

        public async Task<TResponse> Delete<TResponse>(string path, IHeaderDictionary headers = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, $"{path}");
            TResponse result = (TResponse)Activator.CreateInstance(typeof(TResponse));
            try
            {
                //request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                //request.Content.Headers.ContentLength = requestContent.Length;

                var response = await _client.SendAsync(request, CancellationToken.None);

                if (response.IsSuccessStatusCode)
                {

                    using (var streamReader = new StreamReader(await response.Content.ReadAsStreamAsync()))
                    using (var jsonTextReader = new JsonTextReader(streamReader))
                    {
                        result = _serializer.Deserialize<TResponse>(jsonTextReader);
                    }
                }
                else
                {
                }
                response.Dispose();
            }
            catch (Exception ex)
            {
            }

            finally
            {
                request.Dispose();
            }
            return result;
        }
    }
}
