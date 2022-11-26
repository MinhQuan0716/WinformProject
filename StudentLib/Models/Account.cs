using System;
using System.Collections.Generic;

#nullable disable

namespace StudentLib.Models
{
    public partial class Account
    {
        public Account()
        {
            Attendances = new HashSet<Attendance>();
            Courses = new HashSet<Course>();
            ExamResults = new HashSet<ExamResult>();
            Schedules = new HashSet<Schedule>();
        }

        public int AccountId { get; set; }
        public string Username { get; set; }
        public string PassWord { get; set; }
        public string PhoneNumber { get; set; }
        public string Dob { get; set; }
        public DateTime DateOfJoin { get; set; }
        public int? Roleid { get; set; }
        public bool AccountStatus { get; set; }

        public virtual AccountRole Role { get; set; }
        public virtual ICollection<Attendance> Attendances { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<ExamResult> ExamResults { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}
