using PsychologyApp.WebApi.Entities;
using PsychologyApp.WebApi.Entities.Models;

namespace PsychologyApp.WebApi.Services
{
    public interface ITherapyService
    {
        public Task<Therapy> GetTherapyAsync(int therapyId, int psychoId);
        public Task<List<Therapy>> GetTherapyListAsync(int psychoId, bool IsPatient = false);        
        public Task<bool> CreateTherapyAsync(TherapyModel therapy, int psychoId);
        public Task<bool> EditTherapyAsync(TherapyModel therapy, int psychoId);
        public Task<bool> DeleteTherapyAsync(int therapyId, int psychoId);
    }
}
