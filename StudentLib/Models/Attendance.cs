using System;
using System.Collections.Generic;

#nullable disable

namespace StudentLib.Models
{
    public partial class Attendance
    {
        public int AttendanceId { get; set; }
        public string CourseId { get; set; }
        public int? AccountId { get; set; }
        public int? Slot { get; set; }
        public bool? AttStatus { get; set; }
        public string StudentName { get; set; }
        public DateTime? ClassDate { get; set; }

        public virtual Account Account { get; set; }
        public virtual Course Course { get; set; }
    }
}
