namespace PsychologyApp.WebApi.Requests
{
    public class CheckCodeRequest
    {        
        public int userId { get; set; }        
        public string code { get; set; }
    }
}
