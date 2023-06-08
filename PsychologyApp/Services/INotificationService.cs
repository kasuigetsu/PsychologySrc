using PsychologyApp.WebApi.Entities;
using PsychologyApp.WebApi.Entities.Models;

namespace PsychologyApp.WebApi.Services
{
    public interface INotificationService
    {
        public Task<bool> CreateApproveNotification();
        public Task<bool> CreateDeclineNotification();
        public Task<bool> CheckAllNotifications(int userId, int role);
        public Task<List<Notification>> GetPatientNotifications(int userId);
        public Task<List<Notification>> GetPsychologistNotifications(int userId);
    }
}
