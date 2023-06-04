using PsychologyApp.WebApi.Entities.Models;
using PsychologyApp.WebApi.Requests;

namespace PsychologyApp.WebApi.Services.Impl
{
    public class SheduleService : ISheduleService
    {
        public Task<bool> ChangeAppointmentStatusAsync(int sheduleId, int newStatus)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreateAppointmentAsync(SheduleModel appointment)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreateSheduleAsync(CreateSheduleRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<List<SheduleModel>> GetSheduleForPatientAsync(int patientId, int therapyType = 0)
        {
            throw new NotImplementedException();
        }

        public Task<List<SheduleModel>> GetSheduleForPsychoAsync(int psychoId)
        {
            throw new NotImplementedException();
        }
    }
}
