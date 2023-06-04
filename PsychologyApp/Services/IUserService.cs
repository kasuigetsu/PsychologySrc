using Microsoft.AspNetCore.Mvc.ViewFeatures;
using PsychologyApp.WebApi.Entities.Models;
using PsychologyApp.WebApi.Requests;

namespace PsychologyApp.WebApi.Services
{
    public interface IUserService<T> where T : class
    {
        public Task<bool> CheckUserAuthorizationAsync(UserAuthorizationRequest request);
        public Task<bool> SendCodeAsync(string email);
        public Task<bool> RecoverUserPasswordAsync();
        public Task<T> RegisterUserAsync(T user);
        public Task<T> GetUserInfoAsync(int userId);
        public Task<T> ChangeUserInfoAsync(int userId);
        public Task<T> DeleteUserAsync(int userId);
    }
}
