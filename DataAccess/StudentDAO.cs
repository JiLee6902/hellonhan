using BusinessObject.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess
{
    public class StudentDAO
    {
        private static StudentDAO instance = null;
        private static readonly object instanceLock = new object();

        private StudentDAO()
        {
        }

        public static StudentDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new StudentDAO();
                    }
                    return instance;
                }
            }
        }

        public void Add(Student student)
        {
            try
            {
                Student s = FindOne(item => item.Id.Equals(student.Id));
                if (s == null)
                {
                    using (var saleManagement = new SaleManagerContext())
                    {
                        saleManagement.Students.Add(student);
                        saleManagement.SaveChanges();
                    }

                }
                else
                {
                    throw new Exception("The student is already exist");
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Delete(Student student)
        {
            try
            {
                Student s = FindOne(item => item.Id.Equals(student.Id));
                if (s != null)
                {
                    using (var saleManagerContext = new SaleManagerContext())
                    {
                        saleManagerContext.Students.Remove(student);
                        saleManagerContext.SaveChanges();
                    }
                }
                else
                {
                    throw new Exception("The student does not exist");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Student FindOne(Expression<Func<Student, bool>> predicate)
        {
            Student student = null;
            try
            {
                using (var saleManagerContext = new SaleManagerContext())
                {
                    student = saleManagerContext.Students.SingleOrDefault(predicate);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return student;
        }

        public IEnumerable<Student> FindAll(Expression<Func<Student, bool>> predicate)
        {
            List<Student> students = new List<Student>();
            try
            {
                using (var saleManagerContext = new SaleManagerContext())
                {
                    students = saleManagerContext.Students.Where(predicate).ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return students;
        }

        public IEnumerable<Student> List()
        {
            List<Student> students = new List<Student>();
            try
            {
                using (var SaleManagerContext = new SaleManagerContext())
                {
                    students = SaleManagerContext.Students.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return students;
        }

     

        public void Update(Student student)
        {
            try
            {
                Student s = FindOne(item => item.Id.Equals(student.Id));
                if (s != null)
                {
                    using (var saleManager = new SaleManagerContext())
                    {
                        saleManager.Entry<Student>(student).State = EntityState.Modified;
                        saleManager.SaveChanges();
                    }
                }
                else
                {
                    throw new Exception("The student does not exist");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
