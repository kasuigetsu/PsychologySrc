using PsychologyApp.WebApi.Entities;
using PsychologyApp.WebApi.Entities.Models;
using PsychologyApp.WebApi.Requests;

namespace PsychologyApp.WebApi.Services
{
    public interface ISheduleService
    {
        public Task<bool> CreateSheduleAsync(CreateSheduleRequest request);        
        public Task<List<Shedule>> GetSheduleForPsychoAsync(int psychoId);
        public Task<List<Shedule>> GetSheduleForPatientAsync(int psychoId, int patientId = 0);
        public Task<bool> CreateAppointmentAsync(SheduleModel appointment);
        public Task<bool> ChangeAppointmentStatusAsync(int sheduleId, int newStatus, bool IsPsycho);
    }
}
