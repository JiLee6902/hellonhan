using BusinessObject.Model;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IEnrollmentRepository
    {
        IEnumerable<Enrollment> List();
        IEnumerable<Enrollment> FindAllBy(EnrollmentFilter filter);
        void Add(Enrollment enrollment);
        void Update(Enrollment enrollment);
        void Remove(Enrollment enrollment);
        Enrollment FindById(int id);

    }
}
