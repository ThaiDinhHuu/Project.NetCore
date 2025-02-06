using eShopSolution.ViewModels.Common;
using eShopSolution.ViewModels.System.User;

namespace eShopSolution.AdminApp.Services
{
    public interface IUserApiClient
    {
        public Task<string> Authenticate(LoginRequest request);
        Task<PagedResult<UserViewModel>> GetUsersPaging(GetUserPagingRequest request);
    }
}
