using StudentLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentLib.DataAcess;
namespace StudentLib.Repository
{
    public class ExamTypeRepository : IExamTypeRepository
    {
        public IEnumerable<ExamType> GetTypes()=>ExamTypeDAO.Instance.GetExamTypes();
        
    }
}
