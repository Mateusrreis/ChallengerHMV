using System;

namespace CreateTokenLambda.Models
{
    public class ScheduleCalendarRequestDto
    {
        public DateTime Date { get; set; }
        public TimeSpan Hour { get; set; }
        public string NameDoctor { get; set; }
        public string NamePatient { get; set; }
        public DateTime CreatedIn { get; set; }
        public DateTime UpdatedIn { get; set; }
    }
}
