namespace PsychologyApp.WebApi.Entities
{
    public class Psychologist : BaseObject
    {        
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public DateTime? BirthdayDate { get; set; }
        public string EducationInfo { get; set; }
        public string ExperienceInfo { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public DateTime startDate { get; set;}
        public DateTime endDate { get; set;}
        public string Weekends { get; set; }
        public string Unicode { get; set; }
        public bool IsReceiveNotif { get; set; }
    }
}
