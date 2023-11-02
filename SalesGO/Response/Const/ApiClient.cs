using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Response.Const
{
    public class ApiClient : IDisposable
    {
        private readonly HttpClient httpClient;

        public ApiClient()
        {
            httpClient = new HttpClient();
        }

        public async Task<string> ExecuteRequestAsync(string url, HttpMethod method,
            string payload = null, string contentType = "application/json",
            Dictionary<string, string> headers = null)
        {
            using (var request = new HttpRequestMessage(method, url))
            {
                if (payload != null)
                {
                    request.Content = new StringContent(payload, System.Text.Encoding.UTF8, contentType);
                }

                if (headers != null)
                {
                    foreach (var header in headers)
                    {
                        request.Headers.Add(header.Key, header.Value);
                    }
                }

                using (var response = await httpClient.SendAsync(request))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        return await response.Content.ReadAsStringAsync();
                    }
                    else
                    {
                        // Handle error response
                        throw new HttpRequestException($"Request failed with status code {response.StatusCode}");
                    }
                }
            }
        }

        public void Dispose()
        {
            httpClient.Dispose();
        }
    }
}
