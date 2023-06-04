namespace PsychologyApp.WebApi.Entities
{
    public class Shedule : BaseObject
    {        
        public int PsychologistId { get; set; }
        public int PatientId { get; set; }
        public DateTime AppointmentDate { get; set; }        
        public int Status { get; set; }
        public int NotifStatus { get; set; }
        public int TherapyId { get; set; }
    }
}
