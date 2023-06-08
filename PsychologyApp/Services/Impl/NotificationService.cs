using Microsoft.EntityFrameworkCore;
using PsychologyApp.WebApi.Entities;
using PsychologyApp.WebApi.Entities.Models;
using PsychologyApp.WebApi.Enum;
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

        public async Task<bool> CreateApproveNotification()
        {
            var needCreate = await _ctx.Shedule
                .Where(x => x.NotifStatus == (int)NotificationStatus.Approved)
                .Where(x => x.Status != x.NotifStatus)
                .Where(x => !x.IsDeleted)
                .ToListAsync();
           
            if(!needCreate.Any())
                return false;

            foreach(var appoint in needCreate)
            {
                var date = appoint.AppointmentDate.ToString("f");

                var patientMsg = $"Ваша запись на {date} подтверждена.";              
                var patientNotif = new Notification
                {
                    Message = patientMsg,
                    Type = (int)NotificationStatus.Approved,
                    Role = (int)UserRole.Patient,
                    UserId = appoint.PatientId,                    
                    IsChecked = false,
                    IsDeleted = false
                };

                var psychoMsg = $"Запись пациента {appoint.Patient.Name} {appoint.Patient.Surname} на {date} была подтверждена";
                var psychoNotif = new Notification
                {
                    Message = psychoMsg,
                    Type = (int)NotificationStatus.Approved,
                    Role = (int)UserRole.Psychology,
                    UserId = appoint.PsychologistId,                    
                    IsChecked = false,
                    IsDeleted = false
                };

                appoint.Status = appoint.NotifStatus;

                _ctx.Notifications.Add(patientNotif);
                _ctx.Notifications.Add(psychoNotif);
            }

            await _ctx.SaveChangesAsync();
            return true;
        }

        public async Task<bool> CreateDeclineNotification()
        {
            var needCreate = await _ctx.Shedule
               .Where(x => x.NotifStatus == (int)NotificationStatus.Declined)
               .Where(x => x.Status != x.NotifStatus)
               .Where(x => !x.IsDeleted)
               .ToListAsync();

            if (!needCreate.Any())
                return false;

            foreach (var appoint in needCreate)
            {
                var date = appoint.AppointmentDate.ToLongDateString();

                var patientMsg = $"Ваша запись на {date} была отменена.";
                var patientNotif = new Notification
                {
                    Message = patientMsg,
                    Type = (int)NotificationStatus.Declined,
                    Role = (int)UserRole.Patient,
                    UserId = appoint.PatientId,
                    IsChecked = false,
                    IsDeleted = false
                };

                var psychoMsg = $"Запись пациента {appoint.Patient.Name} {appoint.Patient.Surname} на {date} была отменена.";
                var psychoNotif = new Notification
                {
                    Message = psychoMsg,
                    Type = (int)NotificationStatus.Declined,
                    Role = (int)UserRole.Psychology,
                    UserId = appoint.PsychologistId,
                    IsChecked = false,
                    IsDeleted = false
                };

                appoint.Status = appoint.NotifStatus;

                _ctx.Notifications.Add(patientNotif);
                _ctx.Notifications.Add(psychoNotif);
            }

            await _ctx.SaveChangesAsync();
            return true;
        }

        public async Task<bool> CheckAllNotifications(int userId, int role)
        {
            var needCheck = await _ctx.Notifications
                .Where(x => x.UserId == userId)
                .Where(x => x.Role == role)
                .Where(x => !x.IsDeleted)
                .ToListAsync();

            if (!needCheck.Any())
                return false;

            foreach(var notif in needCheck)            
                notif.IsChecked = true;
            
            await _ctx.SaveChangesAsync();
            return true;
        }

        public async Task<List<Notification>> GetUserNotifications(int userId, int role)
        {
            var notifications = await _ctx.Notifications
                .Where(x => x.UserId == userId)
                .Where(x => x.Role == role)
                .Where(x => !x.IsChecked)
                .Where(x => !x.IsDeleted)
                .Take(50)
                .ToListAsync();

            return notifications;
        }
    }
}
