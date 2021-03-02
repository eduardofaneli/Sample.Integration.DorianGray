using Microsoft.Extensions.Logging;
using Novell.Directory.Ldap;
using Sample.Integration.Api.Services.Interfaces;

namespace Sample.Integration.Api.Services
{
    public class AdService : IAdService
    {
        private readonly ILogger<AdService> _logger;

        public AdService(ILogger<AdService> logger)
        {
            _logger = logger;
        }
        public bool Authenticate(string ip, string username, string password)
        {
            try
            {
                var useDn = $"{username}@{ip}";
                using var cn = new LdapConnection();
                cn.Connect(ip, 389);
                cn.Bind(useDn, password);
                return cn.Bound;

            }
            catch (LdapException ex)
            {
                _logger.LogError(ex, "Error in Authenticate");
                return false;
            }
            
        }
    }
}
