using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SEIIApp.Server.Domain;

namespace SEIIApp.Server.DataAccess {

    public static class TestDataInitializer {

        /// <summary>
        /// Initialze test data (just for in-memory database)
        /// </summary>
        public static void InitializeTestData(Services.QuizDefinitionService quizDefinitionService, Services.CourseDefinitionService courseDefinitionService,
            Services.ChapterDefinitionService chapterDefinitionService, Services.ChapterElementDefinitionService chapterElementDefinitionService) {

            for (int i = 0; i < 10; i++) {
                var quiz = TestDataGenerator.CreateQuizDefinition();
                quiz.QuizName = "Quiz " + i;
                quizDefinitionService.AddQuiz(quiz);              
            }

            for (int i = 0; i < 5; i++) {

                var course = TestDataGenerator.CreateCourseDefinition("Course " + i);
                courseDefinitionService.AddCourse(course);

                for (int j = 0; j < 3; j++)
                {
                    var chapter = TestDataGenerator.CreateChapterDefinition("Chapter " + i);
                    chapterDefinitionService.Addchapter(chapter);
                    courseDefinitionService.GetCourseById(i +1).Chapters.Add(chapter);

                    for (int k = 0; k < 7; k++)
                    {
                        var rand = new Random();
                        ChapterElementDefinition element;

                        if (rand.Next(0, 2) == 0)
                        {
                            element = TestDataGenerator.CreateExplanatoryTextDefinition("ExampleText" + k);
                        } else
                        {
                            element = TestDataGenerator.CreatePictureDefinition("ExamplePicture" + k);
                        }
                        chapterElementDefinitionService.AddChapterElement(element);
                        chapterDefinitionService.GetChapterById(j + 1).ChapterElements.Add(element);
                    }

                }

            }

        }

    }

}
