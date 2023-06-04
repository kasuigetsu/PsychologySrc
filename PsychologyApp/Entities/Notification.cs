namespace PsychologyApp.WebApi.Entities
{
    public class Notification : BaseObject
    {
        public string Message { get; set; }
        /// <summary>
        /// 1 - approved
        /// 2 - pending
        /// 3 - declined
        /// </summary>
        public int Type { get; set; }
        /// <summary>
        /// 1 - psychologist
        /// 2 - patient
        /// </summary>
        public int Role { get; set; }
        public string Reason { get; set; }
        public bool IsSend { get; set; }
        public bool IsChecked { get; set; }
        public int SheduleId { get; set; }
    }
}
