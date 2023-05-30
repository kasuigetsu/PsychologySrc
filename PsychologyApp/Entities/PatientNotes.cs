namespace PsychologyApp.WebApi.Entities
{
    public class PatientNotes : BaseObject
    {
        public string Title { get; set; }
        public JsonContent Content { get; set; }    
        public int PatientId { get; set; }
    }
}
