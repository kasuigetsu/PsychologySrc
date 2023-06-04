using PsychologyApp.WebApi.Entities.Models;

namespace PsychologyApp.WebApi.Services.Impl
{
    public class NotificationService : INotificationService
    {
        public Task<bool> CreateNotification(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<List<NotificationModel>> GetNotifications(int userId, int userRole)
        {
            throw new NotImplementedException();
        }
    }
}
