using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement
{
    public class AttendanceResponse
    {
        public int AttendanceId { get; set; }
        public string CourseId { get; set; }

        public String StudentName { get; set; }
        public int? Slot { get; set; }
        public int AccountId { get; set; }
        public DateTime ClassDate { get; set; }
        public bool AttStatus { get; set; }
        public string AccountName { get; set; }
 
    }
}
