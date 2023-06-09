using System.Net.Mail;
using System.Net;
using System.ComponentModel.DataAnnotations;

namespace PsychologyApp.WebApi.Helpers
{
    public class MailHelper
    {
        private const string psychoAddress = $"U&MePsychology@gmail.com";

        public static bool IsValidEmail(string userEmail)
        {
            var email = new EmailAddressAttribute();
            return email.IsValid(userEmail);
        }

        public static bool SendEmail(string emailAddress, string code)
        {
            try
            {
                if (!IsValidEmail(emailAddress))
                    throw new Exception("Электронная почта введена некорректно");

                MailAddress from = new MailAddress(psychoAddress);
                MailAddress to = new MailAddress(emailAddress);
                MailMessage m = new MailMessage(from, to);

                // тема письма
                m.Subject = "U&Me Psychology : подтверждение пароля";
                // текст письма
                m.Body = $"<h2>Ваш код для восстановления пароля: {code}</h2>";
                // письмо представляет код html
                m.IsBodyHtml = true;
                // адрес smtp-сервера и порт, с которого будем отправлять письмо
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                // логин и пароль
                smtp.Credentials = new NetworkCredential("U&MePsychology@gmail.com", "Demo1234");
                smtp.EnableSsl = true;
                smtp.Send(m);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
    }
}
