using StudentLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentLib.Repository
{
   public  interface IScheduleRepository
    {
        IEnumerable<Schedule> GetAll();
       Schedule GetSchedule(int id);
        void AddNew(Schedule schedule);
        void Update(Schedule schedule);
        void Remove(int id);
        IEnumerable<Schedule> GetScheduleByStudent(int id);
    }
}
