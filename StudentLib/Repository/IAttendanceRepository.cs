using StudentLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentLib.Repository
{
    public  interface IAttendanceRepository
    {
        IEnumerable<Attendance> GetAll();
        Attendance GetAttendance(int id);
        List<Attendance> GetAttendanceByStudent(int id);
        void AddNew(Attendance attendance);
        void Update(Attendance attendance);
        void Remove(int id);
    }
}
