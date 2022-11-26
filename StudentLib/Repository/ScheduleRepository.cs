using StudentLib.DataAcess;
using StudentLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentLib.Repository
{
    public class ScheduleRepository : IScheduleRepository
    {
        public void AddNew(Schedule schedule)
        {
            ScheduleDAO.Instance.AddNew(schedule);
        }

        public IEnumerable<Schedule> GetAll()=>ScheduleDAO.Instance.GetScheduleList();
      

        public Schedule GetSchedule(int id)=>ScheduleDAO.Instance.GetScheduleByID(id);

        public IEnumerable<Schedule> GetScheduleByStudent(int id) => ScheduleDAO.Instance.GetScheduleByStudentID(id);
      

        public void Remove(int id)
        {
            ScheduleDAO.Instance.Remove(id);
        }

        public void Update(Schedule schedule)
        {
            ScheduleDAO.Instance.Update(schedule);
        }
    }
}
