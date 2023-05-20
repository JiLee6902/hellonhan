using BusinessObject.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;


namespace DataAccess
{
    public class EnrollmentDAO
    {
        private static EnrollmentDAO instance = null;
        private static readonly object instanceLock = new object();

        private EnrollmentDAO() { }
        public static EnrollmentDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new EnrollmentDAO();
                    }
                    return instance;
                }

            }
        }

        public IEnumerable<Enrollment> List()
        {
            List<Enrollment> enrollments = new List<Enrollment>();
            try
            {
                using (var SaleManagerContext = new SaleManagerContext())
                {
                    enrollments = SaleManagerContext.Enrollments.ToList().OrderByDescending(enrollment => enrollment.CourseId).ToList();
                 

                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return enrollments;
        }

     


        public Enrollment FindOne(Expression<Func<Enrollment, bool>> predicate)
        {
            Enrollment enrollment = null;
            try
            {
                using (var saleManagerContext = new SaleManagerContext())
                {
                    enrollment = saleManagerContext.Enrollments.SingleOrDefault(predicate);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return enrollment;
        }

        public IEnumerable<Enrollment> FindAll(Expression<Func<Enrollment, bool>> predicate)
        {
            List<Enrollment> enrollments = new List<Enrollment>();
            using (var saleManagerContext = new SaleManagerContext())
            {
                enrollments = saleManagerContext.Enrollments.Where(predicate).ToList();
            }
            return enrollments;
        }

        public void Add(Enrollment enrollment)
        {
            try
            {
                Enrollment e = FindOne(item => item.EnrollmentId.Equals(enrollment.EnrollmentId));
                if (e == null)
                {
                    using (var saleManagement = new SaleManagerContext())
                    {
                        saleManagement.Enrollments.Add(enrollment);
                        saleManagement.SaveChanges();
                    }

                }
                else
                {
                    throw new Exception("The enrollment is already exist");
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Delete(Enrollment enrollment)
        {
            try
            {
                Enrollment e = FindOne(item => item.EnrollmentId.Equals(enrollment.EnrollmentId));
                if (e != null)
                {
                    using (var saleManagerContext = new SaleManagerContext())
                    {
                        saleManagerContext.Enrollments.Remove(enrollment);
                        saleManagerContext.SaveChanges();
                    }
                }
                else
                {
                    throw new Exception("The enrollment does not exist");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Update(Enrollment enrollment)
        {
            try
            {
                Enrollment e = FindOne(item => item.EnrollmentId.Equals(enrollment.EnrollmentId));
                if (e != null)
                {
                    using (var saleManager = new SaleManagerContext())
                    {
                        saleManager.Entry<Enrollment>(enrollment).State = EntityState.Modified;
                        saleManager.SaveChanges();
                    }
                }
                else
                {
                    throw new Exception("The enrollment does not exist");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
