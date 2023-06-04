using PsychologyApp.WebApi.Entities.Models;

namespace PsychologyApp.WebApi.Services.Impl
{
    public class TherapyService : ITherapyService
    {
        public Task<bool> CreateOrEditTherapyAsync(int psychoId, TherapyModel therapy)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteTherapyAsync(int psycoId, int therapyId)
        {
            throw new NotImplementedException();
        }

        public Task<TherapyModel> GetTherapyAsync(int psychoId, int therapyId)
        {
            throw new NotImplementedException();
        }

        public Task<TherapyModel> GetTherapyListByIdAsync(int psychoId)
        {
            throw new NotImplementedException();
        }

        public Task<TherapyModel> GetTherapyListByUnicodeAsync(int unicode)
        {
            throw new NotImplementedException();
        }
    }
}
