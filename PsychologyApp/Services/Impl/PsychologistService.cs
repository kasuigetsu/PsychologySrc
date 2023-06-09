using Microsoft.EntityFrameworkCore;
using PsychologyApp.WebApi.Entities;
using PsychologyApp.WebApi.Entities.Models;
using PsychologyApp.WebApi.Enum;
using PsychologyApp.WebApi.Helpers;
using PsychologyApp.WebApi.Models;
using PsychologyApp.WebApi.Requests;

namespace PsychologyApp.WebApi.Services.Impl
{
    public class PsychologistService : IPsychologistService
    {
        private PsychologyContext _ctx;
        private Helper _helper;
        public PsychologistService() 
        { 
            _ctx = new PsychologyContext();
            _helper = new Helper();
        }

        #region Authorization
        public async Task<bool> CheckUserAuthorizationAsync(UserAuthorizationRequest request)
        {
            var user = await _ctx.Psychologist
                .Where(x => x.Id == request.Id)
                .Where(x => !x.IsDeleted)
                .FirstOrDefaultAsync();

            if (user == null)
                throw new Exception("Пользователь не найден");

            var hashPass = _helper.HashPassword(request.Password);
            var result = request.EmailAddress == user.EmailAddress && hashPass == user.Password;
            
            return result;
        }

        public async Task<bool> RegisterUserAsync(PsychologistModel user)
        {
            try
            { 
                var IsValid = _helper.IsValidPsycho(user);
                if (IsValid != null)
                    throw new Exception(IsValid);

                var users = await _ctx.Psychologist
                    .Where(x => !x.IsDeleted)
                    .ToListAsync();

                var isUniq = users
                    .Where(x => x.EmailAddress == user.EmailAddress)                    
                    .FirstOrDefault();

                if (isUniq != null)
                    throw new Exception("Почта уже используется");
                
                var userUnicodes = users.Select(x => x.Unicode).ToList();
                var unicode = Helper.GenerateUnicode(userUnicodes);
                var hashPassword = _helper.HashPassword(user.Password);

                var newUser = new Psychologist
                    {
                        Name = user.Name,
                        Surname = user.Surname,
                        Patronymic = user.Patronymic,                        
                        BirthdayDate = user.BirthdayDate,
                        EducationInfo = user.EducationInfo,
                        ExperienceInfo = user.ExperienceInfo,
                        PhoneNumber = user.PhoneNumber,
                        EmailAddress = user.EmailAddress,
                        Password = hashPassword,                      
                        Unicode = unicode,
                        IsReceiveNotif = false,
                        IsDeleted = false,
                    };
                
                _ctx.Psychologist.Add(newUser);
                await _ctx.SaveChangesAsync();

                return true;
             }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }            
        }

        public async Task<bool> RecoverUserPasswordAsync(int userId, string newPassword)
        {
            var user = await _ctx.Psychologist
                .Where(x => x.Id == userId)
                .Where(x => !x.IsDeleted)
                .FirstOrDefaultAsync();

            if (user == null)
                throw new Exception("Пользователь не найден");

            user.Password = _helper.HashPassword(newPassword);
                        
            await _ctx.SaveChangesAsync();

            return true;            
        }

        public async Task<bool> SendCodeAsync(SendCodeRequest request)
        {   
            var newCode = Helper.GenerateUnicode();
            var isSend = MailHelper.SendEmail(request.email, newCode);

            var newCodeBusket = new CodeBusket
            {
                userId = request.userId,
                userRole = (int)UserRole.Psychologist,
                code = newCode,
                IsDeleted = false
            };

            _ctx.CodeBusket.Add(newCodeBusket);
            await _ctx.SaveChangesAsync();

            return isSend;
        }

        public async Task<bool> CheckCodeAsync(CheckCodeRequest request)
        {
            var codeBusket = await _ctx.CodeBusket
               .Where(x => x.userId == request.userId)
               .Where(x => x.userRole == (int)UserRole.Psychologist)
               .Where(x => !x.IsDeleted)
               .FirstOrDefaultAsync();

            if (codeBusket == null)
                throw new Exception("Код не найден. Попробуйте отправить его еще раз.");

            if (codeBusket.code != request.code)
                throw new Exception("Вы ввели неверный код, попробуйте еще раз.");
            else
            {
                codeBusket.IsDeleted = true;
            }

            return true;
        }

        #endregion

        public async Task<Psychologist> GetUserInfoAsync(int userId)
        {
            var user = await _ctx.Psychologist
                .Where(x => x.Id == userId)
                .Where(x => !x.IsDeleted)
                .FirstOrDefaultAsync();

            if (user == null)
                throw new Exception("Пользователь не найден");

            return user;
        }

        public async Task<bool> ChangeUserInfoAsync(PsychologistModel user)
        {
            var IsValid = _helper.IsValidPsycho(user);
            if (IsValid != null)
                throw new Exception(IsValid);

            var oldUser = await _ctx.Psychologist
                .Where(x => x.Id == user.Id)
                .Where(x => !x.IsDeleted)
                .FirstOrDefaultAsync();

            if (oldUser == null)
                throw new Exception("Пользователь не найден");
            
            oldUser.Name = user.Name;
            oldUser.Surname = user.Surname;
            oldUser.Patronymic = user.Patronymic;
            oldUser.BirthdayDate = user.BirthdayDate;   
            oldUser.EducationInfo = user.EducationInfo;
            oldUser.ExperienceInfo = user.ExperienceInfo;
            oldUser.PhoneNumber = user.PhoneNumber;
            oldUser.EmailAddress = user.EmailAddress;
            oldUser.Password = _helper.HashPassword(user.Password);

            await _ctx.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteUserAsync(int userId)
        {
            var user = await _ctx.Psychologist
                .Where(x => x.Id == userId)
                .Where(x => !x.IsDeleted)
                .FirstOrDefaultAsync();

            if(user == null)
                throw new Exception("Пользователь не найден");

            user.IsDeleted = true;
            await _ctx.SaveChangesAsync();

            return true;
        }

        public async Task<bool> FillOutPatientTreatmentInfoAsync(FillOutPatientTreatmentInfoRequest request)
        {
            var patient = await _ctx.Patients
                 .Where(x => x.Id == request.patientId)
                 .Where(x => !x.IsDeleted)
                 .FirstOrDefaultAsync();

            if (patient == null)
                throw new Exception("Пользователь не найден");

            patient.Anamnesis = request.Anamnesis;
            patient.Recommendations = request.Recommendations;

            await _ctx.SaveChangesAsync();

            return true;
        }
      
    }
}
