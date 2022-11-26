using StudentLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentLib.DataAcess
{
    public  class CourseDAO
    {
        //using singleton pattern 
        private static CourseDAO instance = null;
        private static readonly object instanceLock = new object();
        private CourseDAO() { }
        //-----------------------------------//
        public static CourseDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new CourseDAO();
                    }
                    return instance;
                }
            }
        }
        public IEnumerable<Course> GetCourseList()
        {
            var Course = new List<Course>();
            try
            {
                using var context = new StudentManagementContext();
                Course = context.Courses.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Course;
        }
      
        public Course GetCourseByID(string courseID)
        {
           Course course= null;
            try
            {
                using var context = new StudentManagementContext();
                course = context.Courses.SingleOrDefault(c => c.CourseId.Equals(courseID));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return course;
        }
        public List<Course> GetCourseByTeacherName(string name)
        {
           List< Course> course = null;
            try
            {
                using var context = new StudentManagementContext();
                course = context.Courses.Where(c => c.TeacherName.Equals(name)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return course;
        }
        public void AddNew(Course course)
        {
            try
            {
                Course _course = GetCourseByID(course.CourseId);
                if (_course == null)
                {
                    using var context = new StudentManagementContext();
                    context.Courses.Add(course);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Update(Course course)
        {
            try
            {
                Course _course = GetCourseByID(course.CourseId);
                if (_course != null)
                {
                    using var context = new StudentManagementContext();                    
                    context.Courses.Update(course);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Remove(string id)
        {
            try
            {
                Course _course = GetCourseByID(id);
                if (_course != null)
                {
                    using var context = new StudentManagementContext();
                    context.Courses.Remove(_course);
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

    

