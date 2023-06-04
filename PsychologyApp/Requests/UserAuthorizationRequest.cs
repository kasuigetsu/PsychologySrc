namespace PsychologyApp.WebApi.Requests
{
    public class UserAuthorizationRequest
    {
        public int Id { get; set; }               
        public string EmailAddress { get; set; }
        public string Password { get; set; }
    }
}
