using PsychologyApp.WebApi.Entities.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;

namespace PsychologyApp.WebApi.Helpers
{
    public class Helper
    {   
        public string HashPassword(string password)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(password));

            return Convert.ToBase64String(hash);
        }
        
        public static string GenerateUnicode(List <string> unicodes = null)
        {
            Random random = new Random();

            var result = string.Join("",                            // создаем строку
                    Enumerable.Range(0, 7)                          // из последовательности длины 7
                        .Select(i =>
                            i % 2 == 0 ?                            // на четных местах
                            (char)('A' + random.Next(26)) + "" :    // генерируем букву
                             random.Next(1, 10) + ""));             // на нечетных цифру

            if (unicodes.Contains(result))
                GenerateUnicode(unicodes);

            return result;                      
        }

        public string IsValidPassword(string password) 
        {
            if (password.Length < 8)
                return "Минимальная длина пароля составляет 8 символов";

            if (password.Length > 16)
                return "Длина пароля не должна превышать 16 символов";

            return string.Empty;
        }

        public string IsValidPsycho(PsychologistModel user)
        {            
            if (user.Name == null || user.Surname == null || user.EducationInfo == null ||
                    user.ExperienceInfo == null || user.EmailAddress == null || user.Password == null)
                return "Пожалуйста заполните все обязательные поля";

            if (MailHelper.IsValidEmail(user.EmailAddress))
                return "Ваша почта имеет неверный формат";

            var checkPass = IsValidPassword(user.Password);
            if (checkPass != null)
                return checkPass;

            return string.Empty;            
        }

        public string IsValidPatient(PatientModel user)
        {
            if (user.Name == null || user.Surname == null
                    || user.EmailAddress == null || user.Password == null)
                return "Пожалуйста заполните все обязательные поля";

            if (MailHelper.IsValidEmail(user.EmailAddress))
                return "Ваша почта имеет неверный формат";

            var checkPass = IsValidPassword(user.Password);
            if (checkPass != null)
                return checkPass;

            return string.Empty;
        }
    }    
}
