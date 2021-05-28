using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SEIIApp.Server.Domain;

namespace SEIIApp.Server.DataAccess {

    public static class TestDataInitializer {

        /// <summary>
        /// Initialze test data (just for in-memory database)
        ///    --> IMPORTANT: when the testdata isnt really correctly instantiated, the error that follows isn't really
        ///    traceable to here
        /// </summary>
        public static void InitializeTestData(Services.CourseDefinitionService courseDefinitionService,
            Services.ChapterDefinitionService chapterDefinitionService, Services.ChapterElementDefinitionService chapterElementDefinitionService) {

            for (int i = 0; i < 5; i++) {

                var course = TestDataGenerator.CreateCourseDefinition("Course " + i);
                courseDefinitionService.AddCourse(course);

                for (int j = 0; j < 3; j++)
                {
                    var chapter = TestDataGenerator.CreateChapterDefinition("Chapter " + i);
                    chapterDefinitionService.Addchapter(chapter);
                    courseDefinitionService.GetCourseById(i +1).Chapters.Add(chapter);

                    for (int k = 0; k < 6; k++)
                    {
                        var rand = new Random();
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
                        chapterDefinitionService.GetChapterById(j + 1).ChapterElements.Add(element);
                        // TODO: add videoelement
                    }

                }

            }

        }

    }

}
