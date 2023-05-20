using BusinessObject.Model;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        public void Add(Enrollment enrollment)
        {
            EnrollmentDAO.Instance.Add(enrollment);
        }

        public Enrollment FindById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Enrollment> List() => EnrollmentDAO.Instance.List();

        public void Remove(Enrollment enrollment)
        {
            throw new NotImplementedException();
        }

        public void Update(Enrollment enrollment)
        {
            EnrollmentDAO.Instance.Update(enrollment);
        }

        public IEnumerable<Enrollment> FindAllBy(EnrollmentFilter filter)
        {
            if (filter != null)
            {
                return EnrollmentDAO.Instance.FindAll(enrollment => (filter.EnrollmentId == null || enrollment.EnrollmentId.Equals(filter.EnrollmentId)) &&
                                                                    (filter.StudentId == null || enrollment.StudentId.Equals(filter.StudentId)) &&
                                                                    (filter.CourseId == null || enrollment.CourseId.Equals(filter.CourseId)) &&
                                                                    (filter.Grade == null || enrollment.Grade.Equals(filter.Grade)));


            }
            return List();
        }

    }
}
