using Sample.Integration.Api.Models;

namespace Sample.Integration.Api.Services.Interfaces
{
    public interface IAdService
    {
        bool Authenticate(string ip, string username, string password);
    }
}
