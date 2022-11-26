using System;
using System.Collections.Generic;

#nullable disable

namespace StudentLib.Models
{
    public partial class Course
    {
        public Course()
        {
            Attendances = new HashSet<Attendance>();
            ExamResults = new HashSet<ExamResult>();
            Schedules = new HashSet<Schedule>();
        }

        public string CourseId { get; set; }
        public string SubjectName { get; set; }
        public string TeacherName { get; set; }
        public int? TeacherId { get; set; }
        public int? NumberOfSlots { get; set; }

        public virtual Account Teacher { get; set; }
        public virtual ICollection<Attendance> Attendances { get; set; }
        public virtual ICollection<ExamResult> ExamResults { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}
