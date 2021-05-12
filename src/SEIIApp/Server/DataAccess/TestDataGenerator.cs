using System;
using SEIIApp.Server.Domain;
using System.Collections.Generic;

namespace SEIIApp.Server.DataAccess {

    public static class TestDataGenerator {

        /// <summary>
        /// Creates a test explanatory text definition, with some text and a title.
        /// </summary>
        public static ExplanatoryTextDefinition CreateChapterDefinition(String title, String contentText)
        {
            var explanatoryText = new ExplanatoryTextDefinition();
            explanatoryText.Title = title;
            explanatoryText.ContentText = contentText;

            return explanatoryText;
        }

        /// <summary>
        /// Creates a test chapter definition, which is visible.
        /// </summary>
        public static ChapterDefinition CreateChapterDefinition()
        {
            var chapter = new ChapterDefinition();
            chapter.CreationDate = DateTime.Now;
            chapter.ChangeDate = chapter.CreationDate;
            chapter.Visible = true;

            // TODO: Add chapter elements.

            return chapter;
        }

        /// <summary>
        /// Creates a test quiz definition, with the number of questions and the number of answers per question defined
        /// </summary>
        public static QuizDefinition CreateQuizDefinition(int toIncludeTestQuestions = 3, int toIncludeTestAnswers = 5) {
            var quiz = new QuizDefinition();
            quiz.Questions = new List<QuestionDefinition>();

            for (int q = 0; q < toIncludeTestQuestions; q++) {
                var question = new QuestionDefinition();
                question.QuestionText = "Question " + q.ToString();
                question.Answers = new List<AnswerDefinition>();
                

                for (int a = 0; a < toIncludeTestAnswers; a++) {
                    var answer = new AnswerDefinition();
                    answer.AnswerText = $"Answer for q {q}, a is {a}";
                    question.Answers.Add(answer);
                }

                quiz.Questions.Add(question);
            }
            return quiz;
        }

        public static CourseDefinition CreateCourseDefinition(){
            var course = new CourseDefinition();
            course.CreationDate = DateTime.Now;
            course.ChangeDate = DateTime.Now;
            course.Visible = true;

            // TODO: ADD chapters

            return course;
        }

    }
}
