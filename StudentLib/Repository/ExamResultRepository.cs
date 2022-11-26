using StudentLib.DataAcess;
using StudentLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentLib.Repository
{
    public class ExamResultRepository : IExamResultRepository
    {
        public void AddNew(ExamResult result)
        {
            ExamResultDAO.Instance.AddNew(result);
        }

        public IEnumerable<ExamResult> GetResult()=>ExamResultDAO.Instance.GetExamResultList();


        public ExamResult GetResultByID(string id)=>ExamResultDAO.Instance.GetExamResultByID(id);

        public List<ExamResult> GetResultByStudentID(int id)=>ExamResultDAO.Instance.GetResultByStudentID(id);
       

        public void Remove(string id)
        {
            ExamResultDAO.Instance.Remove(id);
        }

        public void Update(ExamResult result)
        {
            ExamResultDAO.Instance.Update(result);
        }
    }
}
