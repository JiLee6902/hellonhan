using BusinessObject.Model;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface ICourseRepository
    {
        IEnumerable<Course> List();
        void Add(Course course);
        void Update(Course course);
        void Remove(Course course);
        Course FindById(int id);
        IEnumerable<Course> FindAllBy(CourseFilter filter);
    }
}
