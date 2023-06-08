namespace PsychologyApp.WebApi.Entities.Models
{
    public class PatientNoteModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Content { get; set; }
        public int PatientId { get; set; }            
    }
}
