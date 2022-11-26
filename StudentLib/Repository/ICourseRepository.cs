using StudentLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentLib.Repository
{
    public  interface ICourseRepository
    {
        IEnumerable<Course> GetCourses();
        Course GetCourse(string id);
       List< Course> GetCourseByTeacherName(string name);
        void AddNew(Course course);
        void Update(Course course);
        void Remove(string id);
    }
}
