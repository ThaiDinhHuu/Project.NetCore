using eShopSolution.ViewModels.System.User;

namespace eShopSolution.Application.System.User
{
    public interface IUserService
    {
        Task<string> Authenticate(LoginRequest request);
        Task<bool> Register(RegisterRequest request);
    }
}
