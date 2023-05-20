using BusinessObject.Model;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class CourseRepository : ICourseRepository
    {
        public void Add(Course course)
        {
            CourseDAO.Instance.Add(course);
        }

        public IEnumerable<Course> FindAllBy(CourseFilter filter)
        {
            if (filter != null)
            {
                return CourseDAO.Instance.FindAll(course => (filter.CourseId == null || course.CourseId.Equals(filter.CourseId)) &&
                                                              (filter.Title == null || course.Title.ToLower().Contains(filter.Title.ToLower())) &&
                                                              (filter.Credits == null || course.Credits.Equals(filter.Credits))
                                                              );
            }
            return List();
        }

        public Course FindById(int id)
        {
            return CourseDAO.Instance.FindOne(course => course.CourseId == id);
        }

        public IEnumerable<Course> List()
        {
            return CourseDAO.Instance.List();
        }

        public void Remove(Course course)
        {
            CourseDAO.Instance.Delete(course);
        }

        public void Update(Course course)
        {
            CourseDAO.Instance.Update(course);
        }
    }
}
