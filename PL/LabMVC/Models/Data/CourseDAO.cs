using ALDIFASOFT_MVC.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public CourseDAO(ALDIFA_SOFT_MVC_IF4101Context context)
        {
            _context = context;
        }

        public int AddCourse(Course course)
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

        public IEnumerable<Course> GetCourses()
        {
            var courses = (from course in _context.Courses select course);
            return courses.ToList();
        }

        public Course GetCourseById(String identification)
        {
            var courses = (from course in _context.Courses where course.Initials == identification select course);
            return courses.FirstOrDefault();
        }

        public IEnumerable<Course> GetCoursesBySemester()
        {
            DateTime dateTime = DateTime.Now;
            var month = dateTime.Month;
            string currentSemester;
            if (month >= 3 && month <= 7)
            {
                currentSemester = "i";
            }
            else if (month >= 8 && month <= 12)
            {
                currentSemester = "ii";
            }
            else
            {
                currentSemester = "iii";
            }

            var courses = (from course in _context.Courses where course.Semester == currentSemester && course.Activity == true select course);
            return courses.ToList();
        }

        public int EditCourse(Course course)
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

        public int RemoveCourse(Course course)
        {
            int resultToReturn;
            var studentToRemove = _context.Courses.Find(course.Id);
            _context.Courses.Remove(studentToRemove);
            resultToReturn = _context.SaveChangesAsync().Result;
            return resultToReturn;
        }

        private bool CourseExists(int id)
        {
            return _context.Courses.Any(e => e.Id == id);
        }

    }

}
