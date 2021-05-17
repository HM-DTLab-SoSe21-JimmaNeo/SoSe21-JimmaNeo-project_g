using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using SEIIApp.Server.Domain;
using System;
using System.Collections.Generic;
using Xunit;

namespace SEIIApp.Server.Test {

    public class TestCourseDefinitionService {

        private Services.CourseDefinitionService CourseService { get; set; }

        public TestCourseDefinitionService() {
            var serviceCollection = ServiceHelper.GetConfiguredServiceCollection();
            var scope = ServiceHelper.CreateServiceScope(serviceCollection);
            CourseService = scope.ServiceProvider.GetRequiredService<Services.CourseDefinitionService>();
        }

        [Fact]
        public void AddCourse() {
            Domain.CourseDefinition course = new Domain.CourseDefinition();
            course.CourseName = "My first course";
            CourseService.AddCourse(course);
            course.Id.Should().NotBe(0); //id should now be set
        }

        [Fact]
        public void AddChapterToCourse() {
            //first way
            Domain.CourseDefinition course = new Domain.CourseDefinition();
            course.CourseName = "My second ";
            course.Chapters = new() {
                new Domain.ChapterDefinition() { }//inhalt
            };

            CourseService.AddCourse(course);
            course.Id.Should().NotBe(0);
            //question id should also not be 0/zero
            course.Chapters[0].Id.Should().NotBe(0);
        }

        [Fact]
        public void TestRemoveCourse() {
            var course = DataAccess.TestDataGenerator.CreateCourseDefinition();
            CourseService.AddCourse(course);
            course.Id.Should().NotBe(0);

            course = CourseService.GetCourseById(course.Id); //ask database for that quiz

            //remove that question
            CourseService.RemoveCourse(course);

            //query again
            course = CourseService.GetCourseById(course.Id);
            course.Should().BeNull();
        }

    }
}
