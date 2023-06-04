namespace PsychologyApp.WebApi.Entities
{
    public class PatientNote : BaseObject
    {
        public string Title { get; set; }
        public string Content { get; set; }    
        public int PatientId { get; set; }
    }
}
