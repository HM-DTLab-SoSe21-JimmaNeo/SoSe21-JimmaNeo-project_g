using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEIIApp.Server.DataAccess {

    public static class TestDataInitializer {

        /// <summary>
        /// Initialze test data (just for in-memory database)
        /// </summary>
        public static void InitializeTestData(Services.QuizDefinitionService quizDefinitionService, Services.CourseDefinitionService courseDefinitionService, Services.ChapterDefinitionService chapterDefinitionService) {
            for (int i = 0; i < 10; i++) {
                var quiz = TestDataGenerator.CreateQuizDefinition();
                quiz.QuizName = "Quiz " + i;
                quizDefinitionService.AddQuiz(quiz);              
            }

            for (int i = 0; i < 5; i++) {

                var course = TestDataGenerator.CreateCourseDefinition();
                course.CourseName = "Course " + i;
                courseDefinitionService.AddCourse(course);

                for (int j = 0; j < 3; j++)
                {
                    var chapter = TestDataGenerator.CreateChapterDefinition();
                    chapter.ChapterName = "Chapter " + i;
                    chapterDefinitionService.Addchapter(chapter);
                    courseDefinitionService.GetCourseById(i +1).Chapters.Add(chapter);

                }

            }

        }

    }

}
