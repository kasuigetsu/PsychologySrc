using System.Security;

namespace PsychologyApp.WebApi.Entities
{
    public class Patient : BaseObject
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; } 
        public DateTime? BirthdayDate { get; set; } 
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }          
        public string Anamnesis { get; set; }
        public string Recommendations { get; set; }
        public bool IsReceiveNotif { get; set; }
        public string PsychologistId{ get; set; }
    }
}
