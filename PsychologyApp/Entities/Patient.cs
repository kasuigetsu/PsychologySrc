using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security;

namespace PsychologyApp.WebApi.Entities
{
    [Index(nameof(PhoneNumber), nameof(EmailAddress), IsUnique = true)]    
    public class Patient
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
        [Column("phone_number")]
        public string? PhoneNumber { get; set; }
        [Column("email_address")]
        public string EmailAddress { get; set; }
        [Column("password")]
        public string Password { get; set; }
        [Column("anamnesis")]
        public string? Anamnesis { get; set; }
        [Column("recommendations")]
        public string? Recommendations { get; set; }
        [Column("is_receive_notif")]
        public bool IsReceiveNotif { get; set; }
        [Column("psychologist_id")]
        public int? PsychologistId { get; set; }
        [Column("is_deleted")]
        public bool IsDeleted { get; set; }

        public Psychologist Psychologist { get; set; }
    }
}
