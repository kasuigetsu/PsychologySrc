namespace PsychologyApp.WebApi.Requests
{
    public class FillOutPatientTreatmentInfoRequest
    {
        public int patientId { get; set; }
        public string Anamnesis { get; set; }
        public string Recommendations { get; set; }
    }
}
