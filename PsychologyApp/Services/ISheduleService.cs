using PsychologyApp.WebApi.Entities.Models;
using PsychologyApp.WebApi.Requests;

namespace PsychologyApp.WebApi.Services
{
    public interface ISheduleService
    {
        public Task<bool> CreateSheduleAsync(CreateSheduleRequest request);        
        public Task<List<SheduleModel>> GetSheduleForPsychoAsync(int psychoId);
        public Task<List<SheduleModel>> GetSheduleForPatientAsync(int patientId, int therapyType = 0);
        public Task<bool> CreateAppointmentAsync(SheduleModel appointment);
        public Task<bool> ChangeAppointmentStatusAsync(int sheduleId,int newStatus);
    }
}
