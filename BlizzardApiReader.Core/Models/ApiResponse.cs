using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BlizzardApiReader.Core
{
    public class ApiResponse : IApiResponse
    {
        HttpResponseMessage response;

        public HttpResponseHeaders Headers
        {
            get { return response.Headers; }
        }

        public ApiResponse(HttpResponseMessage responseMessage)
        {
            response = responseMessage;
        }

        public bool IsSuccessful()
        {
            return response.IsSuccessStatusCode;
        }

        public async Task<string> ReadContentAsync()
        {
            return await response.Content.ReadAsStringAsync();
        }
    }
}
