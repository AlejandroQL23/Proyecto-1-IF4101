using LabMVC.Models.Entities;
using LabMVC15_04_2021.Models.DomainD;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace LabMVC.Models.Data
{
    public class CourseDAO
    {
        private readonly IConfiguration _configuration;
        private readonly ALDIFA_SOFT_MVC_IF4101Context _context;
        string connectionString;
        public CourseDAO(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("DefaultConnection");
        }
        public CourseDAO()
        {
        }

        /// <param name="context"></param>
        public CourseDAO(ALDIFA_SOFT_MVC_IF4101Context context)
        {
            _context = context;
        }

        public IEnumerable<Entities.Course> GetCourses()
        {
            var courses = (from course in _context.Courses select course);
            return courses.ToList();
        }

        public Entities.Course GetCourseById(String identification)
        {
            var courses= (from course in _context.Courses where course.Initials == identification select course);
            return courses.FirstOrDefault();
        }

        public int AddCourse(Entities.Course course)
        {
            int resultToReturn;
            try
            {
                _context.Add(course);
                resultToReturn = _context.SaveChangesAsync().Result;
            }
            catch (DbUpdateException)
            {
                throw;
            }
            return resultToReturn;
        }

        public int RemoveCourse(Entities.Course course)
        {
            int resultToReturn;
            var studentToRemove = _context.Courses.Find(course.Id);
            _context.Courses.Remove(studentToRemove);
            resultToReturn = _context.SaveChangesAsync().Result;
            return resultToReturn;
        }

        public int EditCourse(Entities.Course course)
        {
            int resultToReturn = 0;
            try
            {
                if (!CourseExists(course.Id))
                {
                    _context.Update(course);
                    resultToReturn = _context.SaveChangesAsync().Result;
                }
            }
            catch (DbUpdateException)
            {
                throw;
            }
            return resultToReturn;
        }


        public List<Entities.Course> GetExplicitCourse()
        {
            List<Entities.Course> courses = null;
            using (var context = new ALDIFA_SOFT_MVC_IF4101Context())
            {
                courses = context.Courses.Select(courseItem => new Entities.Course()
                {
                    Id = courseItem.Id,
                    Name = courseItem.Name
                }).ToList<Entities.Course>();
            }
            return courses;
        }

        private bool CourseExists(int id)
        {
            return _context.Courses.Any(e => e.Id == id);
        }
    }

}
