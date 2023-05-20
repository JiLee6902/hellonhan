using BusinessObject.Model;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IStudentRepository
    {
        IEnumerable<Student> List();
        void Add(Student student);
        void Update(Student student);
        void Delete(Student student);
        Student FindById(int id);
        IEnumerable<Student> FindAllBy(StudentFilter filter);
        IEnumerable<Student> FindAllByStartTimeAndEndTime(DateTime start);
    }
}
