using PsychologyApp.WebApi.Entities.Models;

namespace PsychologyApp.WebApi.Services
{
    public interface INotificationService
    {
        public Task<bool> CreateNotification(int userId);
        public Task<List<NotificationModel>> GetNotifications(int userId, int userRole);        
    }
}
