using Microsoft.EntityFrameworkCore;

namespace PsychologyApp.WebApi.Entities
{
    [Index(nameof(PhoneNumber), nameof(EmailAddress), nameof(Unicode), IsUnique = true)]   
    public class Psychologist
    {   
        public int Id { get; set; }        
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Patronymic { get; set; }
        public DateTime? BirthdayDate { get; set; }
        public string EducationInfo { get; set; }
        public string ExperienceInfo { get; set; }
        public string? PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public DateTime? StartDate { get; set;}
        public DateTime? EndDate { get; set;}
        public string? Weekends { get; set; }
        public string Unicode { get; set; }
        public bool IsReceiveNotif { get; set; }        
        public bool IsDeleted { get; set; }
    }
}
