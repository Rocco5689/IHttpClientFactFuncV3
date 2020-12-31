using System.Net.Http;
using System.Threading.Tasks;

namespace IHttpClientFactFuncV3
{
    // CustomHttpClient Class will use the interface ICustomHttpClient requiring GetStatusCodeAsync()
    // method returning a Task<string> to be defined
    public class CustomHttpClient : ICustomHttpClient
    {
        // Creating a private readonly _client of type HttpClient for accepting the injected client in the constructor on line 14: public CustomHttpClient(HttpClient client)
        private readonly HttpClient _client;

        // CustomerHttpClient Constructor accepts the injected client for defining the local Class _client 
        public CustomHttpClient(HttpClient client)
        {
            _client = client;
        }

        // Defining the Task Method required by the Interface ICustomHttpClient
        public Task<string> GetStatusCodeAsync()
        {
            return _client.GetStringAsync("/");
        }
    }
}