using Microsoft.EntityFrameworkCore;
using System.Net.Mail;

namespace PsychologyApp.WebApi.Entities
{
    
    public class PatientNote
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Content { get; set; }    
        public int PatientId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
