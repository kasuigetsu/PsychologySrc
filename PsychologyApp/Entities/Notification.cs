namespace PsychologyApp.WebApi.Entities
{
    public class Notification : BaseObject
    {
        public JsonContent Message { get; set; }
        public int Type { get; set; }
        public bool IsSend { get; set; }
        public bool IsChecked { get; set; }
        public int SheduleId { get; set; }

    }
}
