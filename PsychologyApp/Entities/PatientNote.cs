using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mail;

namespace PsychologyApp.WebApi.Entities
{    
    public class PatientNote
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("title")]
        public string Title { get; set; }
        [Column("content")]
        public string? Content { get; set; }
        [Column("patient_id")]
        public int PatientId { get; set; }
        [Column("is_deleted")]
        public bool IsDeleted { get; set; }
        
        public Patient Patient { get; set; }
    }
}
