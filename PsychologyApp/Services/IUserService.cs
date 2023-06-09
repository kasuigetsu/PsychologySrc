using Microsoft.AspNetCore.Mvc.ViewFeatures;
using PsychologyApp.WebApi.Entities.Models;
using PsychologyApp.WebApi.Requests;

namespace PsychologyApp.WebApi.Services
{
    public interface IUserService<T> where T : class
    {
        public Task<bool> CheckUserAuthorizationAsync(UserAuthorizationRequest request);
        public Task<bool> SendCodeAsync(SendCodeRequest request);
        public Task<bool> CheckCodeAsync(CheckCodeRequest request);
        public Task<bool> RecoverUserPasswordAsync(int userId, string newPassword);
        public Task<T> GetUserInfoAsync(int userId);        
        public Task<bool> DeleteUserAsync(int userId);
    }
}
