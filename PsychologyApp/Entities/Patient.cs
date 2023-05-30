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
        public JsonContent Anamnesis { get; set; }
        public int? PsychologistId { get; set; }
    }
}
