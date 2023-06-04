using Microsoft.EntityFrameworkCore;
using System.Security;

namespace PsychologyApp.WebApi.Entities
{
    [Index(nameof(PhoneNumber), nameof(EmailAddress), IsUnique = true)]    
    public class Patient
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Patronymic { get; set; } 
        public DateTime? BirthdayDate { get; set; } 
        public string? PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }          
        public string? Anamnesis { get; set; }
        public string? Recommendations { get; set; }
        public bool IsReceiveNotif { get; set; }
        public int? PsychologistId { get; set; }
        public bool IsDeleted { get; set; }

        public Psychologist Psychologist { get; set; }
    }
}
