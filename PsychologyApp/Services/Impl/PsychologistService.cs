using PsychologyApp.WebApi.Entities.Models;
using PsychologyApp.WebApi.Requests;

namespace PsychologyApp.WebApi.Services.Impl
{
    public class PsychologistService : IPsychologistService
    {
        #region Authorization
        public Task<bool> CheckUserAuthorizationAsync(UserAuthorizationRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<PsychologistModel> RegisterUserAsync(PsychologistModel user)
        {
            throw new NotImplementedException();
        }
        public Task<bool> RecoverUserPasswordAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> SendCodeAsync(string email)
        {
            throw new NotImplementedException();
        }
        #endregion

        public Task<PsychologistModel> GetUserInfoAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<PsychologistModel> GetPsychologistInfoByUnicodeAsync(int unicode)
        {
            throw new NotImplementedException();
        }

        public Task<PsychologistModel> ChangeUserInfoAsync(int userId)
        {
            throw new NotImplementedException();
        }
        public Task<PsychologistModel> DeleteUserAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> FillOutPatientTreatmentInfoAsync(FillOutPatientTreatmentInfoRequest request)
        {
           throw new NotImplementedException();
        }  
    }
}
