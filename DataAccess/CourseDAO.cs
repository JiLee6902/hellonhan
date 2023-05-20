using BusinessObject.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess
{
    public class CourseDAO
    {
        private static CourseDAO instance = null;
        private static readonly object instanceLock = new object();
        private CourseDAO() { }
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

        public IEnumerable<Course> List()
        {
            List<Course> courses = new List<Course>();
            try
            {
                using (var SaleManagerContext = new SaleManagerContext())
                {
                    courses = SaleManagerContext.Courses.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return courses;
        }

        public Course FindOne(Expression<Func<Course, bool>> predicate)
        {
            Course course = null;
            try
            {
                using (var saleManagerContext = new SaleManagerContext())
                {
                    course = saleManagerContext.Courses.SingleOrDefault(predicate);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return course;
        }

        public IEnumerable<Course> FindAll(Expression<Func<Course, bool>> predicate)
        {
            List<Course> courses = new List<Course>();
            try
            {
                using (var saleManagerContext = new SaleManagerContext())
                {
                    courses = saleManagerContext.Courses.Where(predicate).ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return courses;
        }

        public void Add(Course course)
        {
            try
            {
                Course c = FindOne(item => item.CourseId.Equals(course.CourseId));
                if (c == null)
                {
                    using (var saleManagement = new SaleManagerContext())
                    {
                        saleManagement.Courses.Add(course);
                        saleManagement.SaveChanges();
                    }

                }
                else
                {
                    throw new Exception("The course is already exist");
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Delete(Course course)
        {
            try
            {
                Course c = FindOne(item => item.CourseId.Equals(course.CourseId));
                if (c != null)
                {
                    using (var saleManagerContext = new SaleManagerContext())
                    {
                        saleManagerContext.Courses.Remove(course);
                        saleManagerContext.SaveChanges();
                    }
                }
                else
                {
                    throw new Exception("The course does not exist");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Update(Course course)
        {
            try
            {
                Course c = FindOne(item => item.CourseId.Equals(course.CourseId));
                if (c != null)
                {
                    using (var saleManager = new SaleManagerContext())
                    {
                        saleManager.Entry<Course>(course).State = EntityState.Modified;
                        saleManager.SaveChanges();
                    }
                }
                else
                {
                    throw new Exception("The couse does not exist");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }

}
