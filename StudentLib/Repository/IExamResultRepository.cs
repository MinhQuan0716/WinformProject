using StudentLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentLib.Repository
{
  public  interface IExamResultRepository
    {
        IEnumerable<ExamResult> GetResult();
        ExamResult GetResultByID(string id);
        List<ExamResult> GetResultByStudentID(int id);
        void AddNew(ExamResult result);
        void Update(ExamResult result);
        void Remove(string id);
    }
}
