namespace PsychologyApp.WebApi.Requests
{
    public class RecoverUserPasswordRequest
    {
        public int UserId { get; set; }
        public string NewPassword { get; set; }
    }
}
