using System;
using System.Collections.Generic;

#nullable disable

namespace StudentLib.Models
{
    public partial class ExamType
    {
        public ExamType()
        {
            ExamResults = new HashSet<ExamResult>();
        }

        public string ExamtypeId { get; set; }
        public string ExamTypeName { get; set; }

        public virtual ICollection<ExamResult> ExamResults { get; set; }
    }
}
