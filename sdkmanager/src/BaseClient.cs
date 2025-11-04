namespace Autodesk.SDKManager
{
   public class BaseClient
    {
        private IAuthenticationProvider _authenticationProvider;

        public IAuthenticationProvider AuthenticationProvider
        {
            get
            {
                return _authenticationProvider;
            }
            set
            {
                _authenticationProvider = value;
            }
        }

        public BaseClient(IAuthenticationProvider authenticationProvider)
        {
            if (authenticationProvider != null)
            {
                _authenticationProvider = authenticationProvider;
            }
        }
    }
}