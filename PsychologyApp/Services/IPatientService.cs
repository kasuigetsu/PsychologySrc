using PsychologyApp.WebApi.Entities;
using PsychologyApp.WebApi.Entities.Models;

namespace PsychologyApp.WebApi.Services
{
    public interface IPatientService : IUserService<PatientModel>
    {        
        public Task<bool> ChangeSubscribePsychologistStatusAsync(string unicode);        
        public Task<bool> AddNoteAsync(PatientNoteModel newNote);
        public Task<bool> EditNoteAsync(PatientNoteModel note);
        public Task<List<PatientNote>> GetPatientNotesAsync(int userId);
        public Task<List<PatientModel>> GetPatientsAsync(int psychoId);
    }
}
