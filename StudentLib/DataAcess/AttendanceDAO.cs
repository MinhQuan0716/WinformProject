using StudentLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentLib.DataAcess
{
    public class AttendanceDAO
    {
        //using singleton pattern 
        private static AttendanceDAO instance = null;
        private static readonly object instanceLock = new object();
        private AttendanceDAO() { }
        //-----------------------------------//
        public static AttendanceDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new AttendanceDAO();
                    }
                    return instance;
                }
            }
        }
        public IEnumerable<Attendance> GetAttendanceList()
        {
            var attendance = new List<Attendance>();
            try
            {
                using var context = new StudentManagementContext();
                attendance = context.Attendances.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return attendance;
        }
        public List<Attendance> GetAttendanceByStudentID(int sid) 
        {
            List<Attendance> attendance = null;
            try
            {
                using var context = new StudentManagementContext();
                attendance= context.Attendances.Where(c => c.AccountId == sid).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return attendance;
        }
        public Attendance GetAttendanceByID(int aid)
        {
            Attendance attendance = null;
            try
            {
                using var context = new StudentManagementContext();
                attendance = context.Attendances.SingleOrDefault(c => c.AttendanceId == aid);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return attendance;
        }
        public void AddNew(Attendance attendance)
        {
            try
            {
                Attendance _attend = GetAttendanceByID(attendance.AttendanceId);
                if (_attend == null)
                {
                    using var context = new StudentManagementContext();
                    context.Attendances.Add(attendance);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Update(Attendance attendance)
        {
            try
            {
                Attendance _attend = GetAttendanceByID(attendance.AttendanceId);
                if (_attend != null)
                {
                    using var context = new StudentManagementContext();
                    context.Attendances.Update(attendance);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Remove(int id)
        {
            try
            {
                Attendance _attend = GetAttendanceByID(id);
                if (_attend != null)
                {
                    using var context = new StudentManagementContext();
                    context.Attendances.Remove(_attend);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

