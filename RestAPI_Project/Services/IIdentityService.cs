using System.Threading.Tasks;
using RestAPI_Project.Domain;

namespace RestAPI_Project.Controllers.V1
{
    public interface IIdentityService
    {
        Task<AuthenticationResult> RegisterAsync(string email, string password);
        Task<AuthenticationResult> LoginAsync(string email, string password);
        Task<AuthenticationResult> RefreshTokenAsync(string token, string refreshToken);


    }
}