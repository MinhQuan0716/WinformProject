using System;
using System.Collections.Generic;

#nullable disable

namespace StudentLib.Models
{
    public partial class Schedule
    {
        public int ScheduleId { get; set; }
        public int? AccountId { get; set; }
        public string CourseId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual Account Account { get; set; }
        public virtual Course Course { get; set; }
    }
}
