using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentLib.Models;
namespace StudentLib.DataAcess
{
   public  class ExamTypeDAO
    {
        private static ExamTypeDAO instance = null;
        private static readonly object instanceLock = new object();
        private ExamTypeDAO() { }
        //-----------------------------------//
        public static ExamTypeDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ExamTypeDAO();
                    }
                    return instance;
                }
            }
        }
        public IEnumerable<ExamType> GetExamTypes()
        {
            var type=new List<ExamType>();
            try {
                var context = new StudentManagementContext();
                type = context.ExamTypes.ToList();
            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return type;
        }
    }
}
