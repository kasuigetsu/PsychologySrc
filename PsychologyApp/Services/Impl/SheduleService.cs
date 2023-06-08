using Microsoft.EntityFrameworkCore;
using PsychologyApp.WebApi.Entities;
using PsychologyApp.WebApi.Entities.Models;
using PsychologyApp.WebApi.Enum;
using PsychologyApp.WebApi.Helpers;
using PsychologyApp.WebApi.Models;
using PsychologyApp.WebApi.Requests;

namespace PsychologyApp.WebApi.Services.Impl
{
    public class SheduleService : ISheduleService
    {
        private PsychologyContext _ctx;
        public const int countHoursCantDecline = 6;

        public SheduleService()
        {
            _ctx = new PsychologyContext();            
        }

        public async Task<bool> ChangeAppointmentStatusAsync(int sheduleId, int newStatus, bool IsPsycho)
        {
            var shedule = await _ctx.Shedule
                .Where(x => x.Id == sheduleId)
                .Where(x => !x.IsDeleted)
                .FirstOrDefaultAsync();

            if (shedule == null)
                throw new Exception("Запись не найдена");

            if(newStatus == (int)NotificationStatus.Declined)
            {
                var nowDate = DateTime.Now;
                var appointDate = shedule.AppointmentDate;

                if(appointDate.AddHours(countHoursCantDecline) > nowDate && !IsPsycho)
                    throw new Exception("Вы не можете отменить запись за 6 часов до приема. Обратитесь к Вашему психологу для отмены записи.");
            }

            shedule.NotifStatus = newStatus;

            await _ctx.SaveChangesAsync();
            return true;
        }

        public async Task<bool> CreateAppointmentAsync(SheduleModel appointment)
        {
            if (appointment.PsychologistId == 0 || appointment.PatientId == 0)
                throw new Exception("Не все поля заполнены");

            var newAppointment = await _ctx.Shedule
                .Where(x => x.PsychologistId == appointment.PsychologistId)
                .Where(x => x.AppointmentDate == appointment.AppointmentDate)
                .Where(x => x.TherapyId == 0)
                .Where(x => x.PatientId == 0)
                .Where(x => !x.IsDeleted)
                .FirstOrDefaultAsync();

            if (newAppointment == null)
                throw new Exception("Не удалось создать запись");

            newAppointment.PatientId = appointment.PatientId;
            newAppointment.TherapyId = appointment.TherapyId;
            newAppointment.Status = (int)NotificationStatus.Pending;

            await _ctx.SaveChangesAsync();
            return true;
        }

        public Task<bool> CreateSheduleAsync(CreateSheduleRequest request)
        {
            var shedule = new List<Shedule>();

            var wkndsDict = new Dictionary<string, DayOfWeek>()
            {
                { "su",  DayOfWeek.Sunday },
                { "mo",  DayOfWeek.Monday },
                { "tu",  DayOfWeek.Tuesday },
                { "we",  DayOfWeek.Wednesday },
                { "th",  DayOfWeek.Thursday },
                { "fr",  DayOfWeek.Friday },
                { "sa",  DayOfWeek.Saturday },
            };

            var wknds = request.Weekends.Split("&");



            throw new NotImplementedException();
        }

        public async Task<List<Shedule>> GetSheduleForPatientAsync(int psychoId, int patientId = 0)
        {
            var shedule = await _ctx.Shedule
               .Where(x => x.PsychologistId == psychoId)
               .Where(x => x.PatientId == patientId)
               .Where(x => !x.IsDeleted)
               .ToListAsync();

            if (!shedule.Any())
                throw new Exception("Расписание не найдено");           

            return shedule;
        }

        public async Task<List<Shedule>> GetSheduleForPsychoAsync(int psychoId)
        {
            var shedule = await _ctx.Shedule
                .Where(x => x.PsychologistId == psychoId)
                .Where(x => !x.IsDeleted)
                .ToListAsync();

            if (!shedule.Any())
                throw new Exception("Расписание не найдено");

            return shedule;                 
        }   
    }
}
