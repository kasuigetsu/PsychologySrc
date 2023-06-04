using PsychologyApp.WebApi.Entities.Models;
using PsychologyApp.WebApi.Requests;

namespace PsychologyApp.WebApi.Services
{
    public interface IPsychologistService:IUserService<PsychologistModel>
    {
        public Task<PsychologistModel> GetPsychologistInfoByUnicodeAsync(int unicode);
        public Task<bool> FillOutPatientTreatmentInfoAsync(FillOutPatientTreatmentInfoRequest request);
    }
}
