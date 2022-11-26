using StudentLib.DataAcess;
using StudentLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentLib.Repository
{
    public  class AttendanceRepository : IAttendanceRepository
    {
        public void AddNew(Attendance attendance)
        {
            AttendanceDAO.Instance.AddNew(attendance);
        }

        public IEnumerable<Attendance> GetAll()=>AttendanceDAO.Instance.GetAttendanceList();


        public Attendance GetAttendance(int id) => AttendanceDAO.Instance.GetAttendanceByID(id);

        public List<Attendance> GetAttendanceByStudent(int id) => AttendanceDAO.Instance.GetAttendanceByStudentID(id);
      

        public void Remove(int id)
        {
            AttendanceDAO.Instance.Remove(id);
        }

        public void Update(Attendance attendance)
        {
            AttendanceDAO.Instance.Update(attendance);
        }
    }
}
