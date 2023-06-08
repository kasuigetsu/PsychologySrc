using Microsoft.EntityFrameworkCore;
using PsychologyApp.WebApi.Entities;
using PsychologyApp.WebApi.Entities.Models;
using PsychologyApp.WebApi.Helpers;
using PsychologyApp.WebApi.Models;
using PsychologyApp.WebApi.Requests;

namespace PsychologyApp.WebApi.Services.Impl
{
    public class PatientService : IPatientService
    {
        private PsychologyContext _ctx;
        private Helper _helper;

        public PatientService()
        {
            _ctx = new PsychologyContext();
            _helper = new Helper();
        }

        #region Authorization/Registration

        public async Task<bool> CheckUserAuthorizationAsync(UserAuthorizationRequest request)
        {
            var user = await _ctx.Patients
               .Where(x => x.Id == request.Id)
               .Where(x => !x.IsDeleted)
               .FirstOrDefaultAsync();

            if (user == null)
                throw new Exception("Пользователь не найден");

            var hashPass = _helper.HashPassword(request.Password);
            var result = request.EmailAddress == user.EmailAddress && hashPass == user.Password;

            return result;
        }

        public async Task<bool> RegisterUserAsync(PatientModel user)
        {
            var IsValid = _helper.IsValidPatient(user);
            if (IsValid != null)
                throw new Exception(IsValid);

            var users = await _ctx.Patients
                  .Where(x => !x.IsDeleted)
                  .ToListAsync();

            var isUniq = users
                .Where(x => x.EmailAddress == user.EmailAddress)
                .FirstOrDefault();

            if (isUniq != null)
                throw new Exception("Почта уже используется");
                        
            var hashPassword = _helper.HashPassword(user.Password);

            var newUser = new Patient
            {
                Name = user.Name,
                Surname = user.Surname,
                Patronymic = user.Patronymic,
                BirthdayDate = user.BirthdayDate,                
                PhoneNumber = user.PhoneNumber,
                EmailAddress = user.EmailAddress,
                Password = hashPassword,                
                IsReceiveNotif = false,
                IsDeleted = false,
            };

            _ctx.Patients.Add(newUser);
            await _ctx.SaveChangesAsync();

            return true;
        }

        public async Task<bool> RecoverUserPasswordAsync(int userId, string newPassword)
        {
            var user = await _ctx.Patients
               .Where(x => x.Id == userId)
               .Where(x => !x.IsDeleted)
               .FirstOrDefaultAsync();

            if (user == null)
                throw new Exception("Пользователь не найден");

            user.Password = _helper.HashPassword(newPassword);

            await _ctx.SaveChangesAsync();

            return true;
        }

        public Task<bool> SendCodeAsync(string email)
        {
            throw new NotImplementedException();
        }      

        #endregion

        public async Task<Patient> GetUserInfoAsync(int userId)
        {
            var user = await _ctx.Patients
               .Where(x => x.Id == userId)
               .Where(x => !x.IsDeleted)
               .FirstOrDefaultAsync();

            if (user == null)
                throw new Exception("Пользователь не найден");

            return user;
        }

        public async Task<bool> ChangeUserInfoAsync(PatientModel user)
        {
            var IsValid = _helper.IsValidPatient(user);
            if (IsValid != null)
                throw new Exception(IsValid);

            var oldUser = await _ctx.Patients
                .Where(x => x.Id == user.Id)
                .Where(x => !x.IsDeleted)
                .FirstOrDefaultAsync();

            if (oldUser == null)
                throw new Exception("Пользователь не найден");

            oldUser.Name = user.Name;
            oldUser.Surname = user.Surname;
            oldUser.Patronymic = user.Patronymic;
            oldUser.BirthdayDate = user.BirthdayDate;
            oldUser.PhoneNumber = user.PhoneNumber;
            oldUser.EmailAddress = user.EmailAddress;
            oldUser.Password = _helper.HashPassword(user.Password);

            await _ctx.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteUserAsync(int userId)
        {
            var user = await _ctx.Patients
                .Where(x => x.Id == userId)
                .Where(x => !x.IsDeleted)
                .FirstOrDefaultAsync();

            if (user == null)
                throw new Exception("Пользователь не найден");

            user.IsDeleted = true;
            await _ctx.SaveChangesAsync();

            return true;
        }

        public async Task<bool> ChangeSubscribePsychologistAsync(int userId, string unicode)
        {
            var user = await _ctx.Patients
                .Where(x => x.Id == userId)
                .Where(x => !x.IsDeleted)
                .FirstOrDefaultAsync();

            if (user == null)
                throw new Exception("Пользователь не найден");

            var psychologist = await _ctx.Psychologist
                .Where(x => x.Unicode == unicode)
                .Where(x => !x.IsDeleted)
                .FirstOrDefaultAsync();

            if (psychologist == null)
                throw new Exception("Психолог не найден");

            user.PsychologistId = psychologist.Id;
            await _ctx.SaveChangesAsync();

            return true;
        }

        public async Task<List<Patient>> GetPatientsAsync(int psychoId)
        {
            var users = await _ctx.Patients
                .Where(x => x.PsychologistId == psychoId)
                .Where(x => x.IsDeleted)
                .ToListAsync();

            if (!users.Any())
                throw new Exception("Список пациентов пуст");

            return users;   
        }

        public async Task<bool> CreateNoteAsync(PatientNoteModel note)
        {
            if (note.Title == null)
                throw new Exception("Заполните заголовок заметки");
            if (note.PatientId == 0)
                throw new Exception($"Ошибка добавления заметки, id: {note.Id}");

            var newNote = new PatientNote
            {
                Title = note.Title,
                Content = note.Content,
                PatientId = note.PatientId,
                IsDeleted = false
            };

            _ctx.PatientNotes.Add(newNote);
            await _ctx.SaveChangesAsync();

            return true;
        }

        public async Task<bool> EditNoteAsync(PatientNoteModel note)
        {
            if (note.Title == null)
                throw new Exception("Заполните заголовок заметки");
            if (note.PatientId == 0)
                throw new Exception($"Ошибка обновления заметки, id: {note.Id}");

            var oldNote = await _ctx.PatientNotes
                .Where(x => x.Id == note.Id)
                .Where(x => !x.IsDeleted)
                .FirstOrDefaultAsync();

            if (oldNote == null)
                throw new Exception($"Заметка не найдена, id : {note.Id}");

            oldNote.Title = note.Title;
            oldNote.Content = note.Content;            

            await _ctx.SaveChangesAsync();

            return true;
        }

        public async Task<List<PatientNote>> GetPatientNotesAsync(int userId)
        {
            var notes = await _ctx.PatientNotes
                .Where(x => x.PatientId == userId)
                .Where(x => !x.IsDeleted)
                .ToListAsync();

            if (!notes.Any())
                throw new Exception("Список заметок пуст");

            return notes;
        }     
    }
}
