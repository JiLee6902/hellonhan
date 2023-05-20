using BusinessObject.Model;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class StudentRepository : IStudentRepository
    {
        public void Add(Student student)
        {
            StudentDAO.Instance.Add(student);
        }

        public void Delete(Student student)
        {
            StudentDAO.Instance.Delete(student);
        }

        public IEnumerable<Student> FindAllBy(StudentFilter filter)
        {
            if (filter != null)
            {
                return StudentDAO.Instance.FindAll(student => (filter.Id == null || student.Id.Equals(filter.Id)) &&
                                                              (filter.LastName == null || student.LastName.ToLower().Contains(filter.LastName.ToLower())) &&
                                                              (filter.FirstMidName == null || student.FirstMidName.ToLower().Contains(filter.FirstMidName.ToLower())) &&
                                                              (filter.EnrollmentDate == null || student.EnrollmentDate >= filter.EnrollmentDate)
                                                              );

            }
            return List();
        }



       
        public IEnumerable<Student> FindAllByStartTimeAndEndTime(DateTime start)
        {
            throw new NotImplementedException();
        }

        public Student FindById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> List()
        {
            return StudentDAO.Instance.List();
        }

        public void Update(Student student)
        {
            StudentDAO.Instance.Update(student);
        }
    }
}
