using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SEIIApp.Server.Domain;
using SEIIApp.Shared.DomainTdo;

namespace SEIIApp.Server.DataAccess {

    public static class TestDataInitializer {

        /// <summary>
        /// Initialze test data (just for in-memory database)
        ///    --> IMPORTANT: when the testdata isnt really correctly instantiated, the error that follows isn't really
        ///    traceable to here
        /// </summary>
        public static void InitializeTestData(Services.CourseDefinitionService courseDefinitionService,  Services.ChapterDefinitionService chapterDefinitionService, 
            Services.ChapterElementDefinitionService chapterElementDefinitionService, Services.LoginService loginService, Services.UserDefinitionService userDefinitionService) {

            var authTest = TestDataGenerator.CreateAuthentifizierung("test", "test", RoleType.Student);
            loginService.AddAuth(authTest);

            var authAdmin2 = TestDataGenerator.CreateAuthentifizierung("admin", "admin", RoleType.Admin);
            loginService.AddAuth(authAdmin2);
            
            var authTeacher2 = TestDataGenerator.CreateAuthentifizierung("teacher", "teacher", RoleType.Teacher);
            loginService.AddAuth(authTeacher2);

            var userAdmin = TestDataGenerator.CreateUser("adminMail@mailinator.com");
            var authAdmin = TestDataGenerator.CreateAuthentifizierung("admin", "admin", RoleType.Admin);
            userAdmin.AuthDefinitions.Add(authAdmin);
            userAdmin.AuthDefinitions.Add(authAdmin2);

            var authStudent2 = TestDataGenerator.CreateAuthentifizierung("user", "user", RoleType.Student);
            loginService.AddAuth(authStudent2);
            var userStudent = TestDataGenerator.CreateUser("studentMail@mailinator.com");
            var authStudent = TestDataGenerator.CreateAuthentifizierung("student", "student", RoleType.Student);
            userStudent.AuthDefinitions.Add(authStudent);
            userStudent.AuthDefinitions.Add(authStudent2);

            var userTeacher = TestDataGenerator.CreateUser("teacherMail@mailinator.com");
            var authTeacher = TestDataGenerator.CreateAuthentifizierung("teacher", "teacher", RoleType.Teacher);
            userTeacher.AuthDefinitions.Add(authTeacher);
            userTeacher.AuthDefinitions.Add(authTeacher2);


            for (int i = 0; i < 5; i++) {

                var course = TestDataGenerator.CreateCourseDefinition("Course " + i);
                courseDefinitionService.AddCourse(course);

                for (int j = 0; j < 3; j++)
                {
                    var chapter = TestDataGenerator.CreateChapterDefinition("Chapter " + i);
                    chapterDefinitionService.Addchapter(chapter);
                    course.Chapters.Add(chapter);


                    for (int k = 0; k < 6; k++)
                    {
                        ChapterElementDefinition element;

                        if (k == 1 || k == 2)
                        {
                            element = TestDataGenerator.CreateExplanatoryTextDefinition("ExampleText" + k);
                            element.ChapterElementType = Shared.DomainTdo.ChapterElementType.Text;
                        } else if(k == 3 || k == 4)
                        {
                            element = TestDataGenerator.CreatePictureDefinition("ExamplePicture" + k);
                            element.ChapterElementType = Shared.DomainTdo.ChapterElementType.Picture;
                        }else
                        {
                            var quiz = TestDataGenerator.CreateQuizDefinition();
                            quiz.QuizName = "Quiz " + k;
                            element = quiz;
                            element.ChapterElementType = Shared.DomainTdo.ChapterElementType.Quiz;
                        }

                        chapterElementDefinitionService.AddChapterElement(element);
                        chapter.ChapterElements.Add(element);
                        // TODO: add videoelement
                    }

                }

                var courseId = new AsignedCoursesIdClass();
                courseId.AsignedCoursesId = course.CourseId;
                userAdmin.AsignedCoursesId.Add(courseId);


                if (i == 0 || i == 1)
                {
                    var courseIdVar1 = new AsignedCoursesIdClass();
                    courseIdVar1.AsignedCoursesId = course.CourseId;
                    userStudent.AsignedCoursesId.Add(courseIdVar1);
                }
                if(i == 0 || i == 1 || i== 2)
                {
                    var courseIdVar2 = new AsignedCoursesIdClass();
                    courseIdVar2.AsignedCoursesId = course.CourseId;
                    userTeacher.AsignedCoursesId.Add(courseIdVar2);
                }

            }
            userDefinitionService.AddUser(userAdmin);
            userDefinitionService.AddUser(userStudent);
            userDefinitionService.AddUser(userTeacher);

        }

    }

}
