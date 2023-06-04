using PsychologyApp.WebApi.Entities;
using PsychologyApp.WebApi.Entities.Models;
using PsychologyApp.WebApi.Requests;

namespace PsychologyApp.WebApi.Services.Impl
{
    public class PatientService : IPatientService
    {
        #region Authorization/Registration

        public Task<bool> CheckUserAuthorizationAsync(UserAuthorizationRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<PatientModel> RegisterUserAsync(PatientModel user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SendCodeAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RecoverUserPasswordAsync()
        {
            throw new NotImplementedException();
        }

        #endregion

        public Task<PatientModel> GetUserInfoAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<PatientModel> ChangeUserInfoAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<PatientModel> DeleteUserAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ChangeSubscribePsychologistStatusAsync(string unicode)
        {
            throw new NotImplementedException();
        }

        public Task<List<PatientModel>> GetPatientsAsync(int psychoId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddNoteAsync(PatientNoteModel newNote)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EditNoteAsync(PatientNoteModel note)
        {
            throw new NotImplementedException();
        }

        public Task<List<PatientNote>> GetPatientNotesAsync(int userId)
        {
            throw new NotImplementedException();
        }     
    }
}
