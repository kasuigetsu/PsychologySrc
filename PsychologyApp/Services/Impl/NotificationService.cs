using Microsoft.EntityFrameworkCore;
using PsychologyApp.WebApi.Entities.Models;
using PsychologyApp.WebApi.Models;

namespace PsychologyApp.WebApi.Services.Impl
{
    public class NotificationService : INotificationService
    {
        private PsychologyContext _ctx;

        public NotificationService()
        {
            _ctx = new PsychologyContext();
        }

        public Task<bool> CreateNotification(int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<NotificationModel>> GetPatientNotifications(int userId)
        {
            //var notifications = await _ctx.Notifications
            //    .Where(x => x.Shedule.PatientId == userId)
            //    .Where(x => !x.IsDeleted)
            //    .ToListAsync();

            throw new NotImplementedException();
        }

        public Task<List<NotificationModel>> GetPsychologistNotifications(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
