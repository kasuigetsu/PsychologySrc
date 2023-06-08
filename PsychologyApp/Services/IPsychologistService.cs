using PsychologyApp.WebApi.Entities;
using PsychologyApp.WebApi.Entities.Models;
using PsychologyApp.WebApi.Requests;

namespace PsychologyApp.WebApi.Services
{
    public interface IPsychologistService:IUserService<Psychologist>
    {
        public Task<bool> ChangeUserInfoAsync(PsychologistModel user);
        public Task<bool> RegisterUserAsync(PsychologistModel user);        
        public Task<bool> FillOutPatientTreatmentInfoAsync(FillOutPatientTreatmentInfoRequest request);
    }
}
