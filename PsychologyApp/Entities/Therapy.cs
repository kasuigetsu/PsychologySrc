namespace PsychologyApp.WebApi.Entities
{
    public class Therapy : BaseObject
    {
        public string Title { get; set; }
        public string Description { get;set; }
        public double Cost { get; set; }
    }
}
