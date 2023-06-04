using PsychologyApp.WebApi.Entities.Models;

namespace PsychologyApp.WebApi.Services
{
    public interface ITherapyService
    {
        public Task<TherapyModel> GetTherapyAsync(int psychoId, int therapyId);
        public Task<TherapyModel> GetTherapyListByIdAsync(int psychoId);
        public Task<TherapyModel> GetTherapyListByUnicodeAsync(int unicode);
        public Task<bool> CreateOrEditTherapyAsync(int psychoId, TherapyModel therapy);
        public Task<bool> DeleteTherapyAsync(int psycoId, int therapyId);
    }
}
