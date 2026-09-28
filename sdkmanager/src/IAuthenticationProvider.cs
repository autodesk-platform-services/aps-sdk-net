using System.Collections.Generic;
using System.Threading.Tasks;

public interface IAuthenticationProvider
{
       Task<string> GetAccessToken(IEnumerable<string> scopes = default);
}