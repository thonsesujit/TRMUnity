using Assets.Scripts.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace Assets.Scripts.Api
{
    public interface IAPIHelper
    {
        HttpClient ApiClient { get; }
        Task<AuthenticatedUser> Authenticate(string username, string password);
        void LogOffUser();

        Task GetLoggedInUserInfo(string token);
    }
}