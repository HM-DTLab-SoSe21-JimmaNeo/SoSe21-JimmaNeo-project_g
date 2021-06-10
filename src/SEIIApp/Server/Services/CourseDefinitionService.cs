using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SEIIApp.Server.DataAccess;
using SEIIApp.Server.Domain;
using System.Linq;

namespace SEIIApp.Server.Services
{

    public class CourseDefinitionService
    {

        private DatabaseContext DatabaseContext { get; set; }
        private IMapper Mapper { get; set; }

        public CourseDefinitionService(DatabaseContext db, IMapper mapper)
        {
            this.DatabaseContext = db;
            this.Mapper = mapper;
        }

        private IQueryable<CourseDefinition> GetQueryableForCourseDefinitions()
        {
            return DatabaseContext.CourseDefinitions
                .Include(course => course.Chapters);
        }

        /// <summary>
        /// Returns all courses as an array, also contains the chapters of the courses.
        /// </summary>
        public CourseDefinition[] GetAllCourses()
        {
            return GetQueryableForCourseDefinitions().ToArray();
        }

        /// <summary>
        /// Returns the course with the given id, also includes the chapters of the course.
        /// </summary>
        public CourseDefinition GetCourseById(int id)
        {
            CourseDefinition coursedefinition = GetQueryableForCourseDefinitions().Where(course => course.CourseId == id).FirstOrDefault();
            return coursedefinition;
        }

        /// <summary>
        /// Adds a course and returns it.
        /// </summary>
        public CourseDefinition AddCourse(CourseDefinition course)
        {
            course.CreationDate = DateTime.Now;
            course.ChangeDate = DateTime.Now;
            DatabaseContext.CourseDefinitions.Add(course);
            DatabaseContext.SaveChanges();
            return course;
        }

        /// <summary>
        /// Updates a course and returns it.
        /// </summary>
        public CourseDefinition UpdateCourse(CourseDefinition course)
        {
            course.ChangeDate = DateTime.Now;
            DatabaseContext.CourseDefinitions.Update(course);
            DatabaseContext.SaveChanges();
            return course;
        }

        /// <summary>
        /// Removes a course and all dependencies.
        /// </summary>
        public void RemoveCourse(CourseDefinition course)
        {
            DatabaseContext.CourseDefinitions.Remove(course);
            DatabaseContext.SaveChanges();
        }

    }

}
