using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mail;

namespace PsychologyApp.WebApi.Entities
{    
    public class Shedule
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("psychologist_id")]
        public int PsychologistId { get; set; }
        [Column("patient_id")]
        public int PatientId { get; set; }
        [Column("appointment_date")]
        public DateTime AppointmentDate { get; set; }        
        [Column("status")]
        public int Status { get; set; }
        [Column("notif_status")]
        public int NotifStatus { get; set; }
        [Column("therapy_id")]
        public int TherapyId { get; set; }        
        [Column("is_deleted")]
        public bool IsDeleted { get; set; }
        [Column("is_weekend")]
        public bool IsWeekend { get; set; }
        public Psychologist Psychologist { get; set; }
        public Patient Patient { get; set; }
        public Therapy Therapy { get; set;}
    }
}
