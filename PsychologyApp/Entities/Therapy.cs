namespace PsychologyApp.WebApi.Entities
{
    public class Therapy
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get;set; }
        public double? Cost { get; set; }
        public bool IsDeleted { get; set; }
        public int? psychoId { get; set; }
        public bool NeedShow { get; set; }
    }
}
