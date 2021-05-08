using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SEIIApp.Server.DataAccess;
using SEIIApp.Server.Domain;
using System.Linq;

namespace SEIIApp.Server.Services {
    public class CourseDefinitionService {

        private DatabaseContext DatabaseContext { get; set; }
        private IMapper Mapper { get; set; }
        public CourseDefinitionService(DatabaseContext db, IMapper mapper) {
            this.DatabaseContext = db;
            this.Mapper = mapper;
        }

        private IQueryable<CourseDefinition> GetQueryableForCourseDefinitions() {
            return DatabaseContext
                .CourseDefinitions
                .Include(course => course.Chapter);
        }

        /// <summary>
        /// Returns all courses. Includes also the chapters.
        /// </summary>
        public CourseDefinition[] GetAllCourses() {
            return GetQueryableForCourseDefinitions().ToArray();
        }

        /// <summary>
        /// Returns the course with the given id. Includes also chapters.
        /// </summary>
        public CourseDefinition GetCourseById(int id) {
            return GetQueryableForCourseDefinitions().Where(course => course.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// Adds a course.
        /// </summary>
        public CourseDefinition AddCourse(CourseDefinition course) {
            DatabaseContext.CourseDefinitions.Add(course);
            DatabaseContext.SaveChanges();
            return course;
        }

        /// <summary>
        /// Updates a course.
        /// </summary>
        public CourseDefinition UpdateCourse(CourseDefinition course) {

            var existingCourse = GetCourseById(course.Id);

            Mapper.Map(course, existingCourse); //we can map into the same object type

            DatabaseContext.CourseDefinitions.Update(existingCourse);
            DatabaseContext.SaveChanges();
            return existingCourse;
        }

        /// <summary>
        /// Removes a course and all dependencies.
        /// </summary>
        public void RemoveCourse(CourseDefinition course) {
            DatabaseContext.CourseDefinitions.Remove(course);
            DatabaseContext.SaveChanges();
        }

    }
}
