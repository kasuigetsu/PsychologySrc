using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace PsychologyApp.WebApi.Entities
{
    [Index(nameof(PhoneNumber), nameof(EmailAddress), nameof(Unicode), IsUnique = true)]   
    public class Psychologist
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("surname")]
        public string Surname { get; set; }
        [Column("patronymic")]
        public string? Patronymic { get; set; }
        [Column("birthday_date")]
        public DateTime? BirthdayDate { get; set; }
        [Column("education_info")]
        public string EducationInfo { get; set; }
        [Column("experience_info")]
        public string ExperienceInfo { get; set; }
        [Column("phone_number")]
        public string? PhoneNumber { get; set; }
        [Column("email_address")]
        public string EmailAddress { get; set; }
        [Column("password")]
        public string Password { get; set; }
        [Column("start_date")]
        public DateTime? StartDate { get; set;}
        [Column("end_date")]
        public DateTime? EndDate { get; set;}
        [Column("weekends")]
        public string? Weekends { get; set; }
        [Column("unicode")]
        public string Unicode { get; set; }
        [Column("is_receive_notif")]
        public bool IsReceiveNotif { get; set; }
        [Column("is_deleted")]
        public bool IsDeleted { get; set; }
    }
}
