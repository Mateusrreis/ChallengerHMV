using System;

namespace CreateTokenLambda.Models.ResponseDtos
{
    public class ScheduleCalendarResponse
    {
        public bool IsScheduleCalendar { get; set; }
        public string NamePatient { get; set; }
        public string NameDoctor { get; set; }
        public DateTime CreatedIn { get; set; }
    }
}
