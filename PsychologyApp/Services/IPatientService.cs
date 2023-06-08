using PsychologyApp.WebApi.Entities;
using PsychologyApp.WebApi.Entities.Models;

namespace PsychologyApp.WebApi.Services
{
    public interface IPatientService : IUserService<Patient>
    {
        public Task<bool> ChangeUserInfoAsync(PatientModel user);
        public Task<bool> RegisterUserAsync(PatientModel user);
        public Task<bool> ChangeSubscribePsychologistAsync(int userId, string unicode);        
        public Task<bool> CreateNoteAsync(PatientNoteModel newNote);
        public Task<bool> EditNoteAsync(PatientNoteModel note);
        public Task<List<PatientNote>> GetPatientNotesAsync(int userId);
        public Task<List<Patient>> GetPatientsAsync(int psychoId);
    }
}
