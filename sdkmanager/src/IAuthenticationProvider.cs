using System.Collections.Generic;
using System.Threading.Tasks;

namespace Autodesk.SDKManager
{
    public interface IAuthenticationProvider
    {
        Task<string> GetAccessToken(IEnumerable<string> scopes = default);
    }
}