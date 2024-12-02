using System.Collections.Generic;
using System.Threading.Tasks;

public class StaticAuthenticationProvider : IAuthenticationProvider
{
    private string _accessToken;

    public StaticAuthenticationProvider(string accessToken)
    {
        _accessToken = accessToken;
    }


    public async Task<string> GetAccessToken(IEnumerable<string> scopes = default)
    {
        return _accessToken;
    }


}