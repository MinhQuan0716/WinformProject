using System;
using System.Collections.Generic;

#nullable disable

namespace StudentLib.Models
{
    public partial class ExamResult
    {
        public string ExamId { get; set; }
        public string CourseId { get; set; }
        public int? AccountId { get; set; }
        public DateTime? ExamStartDate { get; set; }
        public int? Totaltime { get; set; }
        public string ExamType { get; set; }
        public bool? ExamStatus { get; set; }
        public int? Marks { get; set; }
        public string Status { get; set; }

        public virtual Account Account { get; set; }
        public virtual Course Course { get; set; }
        public virtual ExamType ExamTypeNavigation { get; set; }
    }
}
