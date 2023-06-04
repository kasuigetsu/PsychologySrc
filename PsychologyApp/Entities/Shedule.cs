using Microsoft.EntityFrameworkCore;
using System.Net.Mail;

namespace PsychologyApp.WebApi.Entities
{    
    public class Shedule
    {        
        public int Id { get; set; }
        public int PsychologistId { get; set; }
        public int PatientId { get; set; }
        public DateTime AppointmentDate { get; set; }        
        public int Status { get; set; }
        public int NotifStatus { get; set; }
        public int TherapyId { get; set; }
        public bool IsDeleted { get; set; }
        public Psychologist Psychologist { get; set; }
        public Patient Patient { get; set; }
        public Therapy Therapy { get; set;}
    }
}
