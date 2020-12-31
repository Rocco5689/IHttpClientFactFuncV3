using System.Threading.Tasks;

namespace IHttpClientFactFuncV3
{

    // Interface ICustomHttpClient definition requiring the GetStatusCodeAsync() returning a Task<string> be defined.
    public interface ICustomHttpClient
    {
        Task<string> GetStatusCodeAsync();
    }
}