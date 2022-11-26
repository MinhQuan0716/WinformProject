using StudentLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentLib.DataAcess
{
    public  class ExamResultDAO
    {
        private static ExamResultDAO instance = null;
        private static readonly object instanceLock = new object();
        private ExamResultDAO() { }
        //-----------------------------------//
        public static ExamResultDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ExamResultDAO();
                    }
                    return instance;
                }
            }
        }
        public IEnumerable<ExamResult> GetExamResultList()
        {
            var result = new List<ExamResult>();
            try
            {
                using var context = new StudentManagementContext();
                result = context.ExamResults.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }
        public List<ExamResult> GetResultByStudentID(int sid)
        {
            List<ExamResult> result = null;
            try
            {
                using var context = new StudentManagementContext();
                result = context.ExamResults.Where(c => c.AccountId == sid).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }
        public ExamResult GetExamResultByID(string id)
        {
            ExamResult result = null;
            try
            {
                using var context = new StudentManagementContext();
                result = context.ExamResults.SingleOrDefault(c => c.ExamId.Equals(id));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }
        public void AddNew(ExamResult result)
        {
            try
            {
                ExamResult _result = GetExamResultByID(result.ExamId);
                if (_result == null)
                {
                    using var context = new StudentManagementContext();
                    context.ExamResults.Add(result);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Update(ExamResult result)
        {
            try
            {
                ExamResult _result = GetExamResultByID(result.ExamId);
                if (_result != null)
                {
                    using var context = new StudentManagementContext();
                    context.ExamResults.Update(result);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Remove(String id)
        {
            try
            {
                ExamResult _result = GetExamResultByID(id);
                if (_result != null)
                {
                    using var context = new StudentManagementContext();
                    context.ExamResults.Remove(_result);
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

