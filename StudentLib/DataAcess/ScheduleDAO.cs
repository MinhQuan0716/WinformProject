using StudentLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentLib.DataAcess
{
    public  class ScheduleDAO
    {
        private static ScheduleDAO instance = null;
        private static readonly object instanceLock = new object();
        private ScheduleDAO() { }
        //-----------------------------------//
        public static ScheduleDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ScheduleDAO();
                    }
                    return instance;
                }
            }
        }
        public IEnumerable<Schedule> GetScheduleList()
        {
            var schedule = new List<Schedule>();
            try
            {
                using var context = new StudentManagementContext();
                schedule = context.Schedules.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return schedule;
        }
        public IEnumerable<Schedule> GetScheduleByStudentID(int sid)
        {
            var schedule = new List<Schedule>();
            try
            {
                using var context = new StudentManagementContext();
                schedule = context.Schedules.Where(c => c.AccountId == sid ).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return schedule;
        }
        public Schedule GetScheduleByID(int aid)
        {
            Schedule schedule = null;
            try
            {
                using var context = new StudentManagementContext();
                schedule = context.Schedules.SingleOrDefault(c => c.ScheduleId == aid);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return schedule;
        }
        public void AddNew(Schedule schedule)
        {
            try
            {
                Schedule _schedule = GetScheduleByID(schedule.ScheduleId);
                if (_schedule == null)
                {
                    using var context = new StudentManagementContext();
                    context.Schedules.Add(schedule);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Update(Schedule schedule)
        {
            try
            {
                Schedule _schedule = GetScheduleByID(schedule.ScheduleId);
                if (_schedule != null)
                {
                    using var context = new StudentManagementContext();
                    context.Schedules.Update(schedule);
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
                Schedule _schedule = GetScheduleByID(id);
                if (_schedule != null)
                {
                    using var context = new StudentManagementContext();
                    context.Schedules.Remove(_schedule);
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

