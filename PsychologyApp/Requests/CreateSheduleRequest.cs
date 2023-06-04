namespace PsychologyApp.WebApi.Requests
{
    public class CreateSheduleRequest
    {
        public int psychoId { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public string Weekends { get; set; }
    }
}
