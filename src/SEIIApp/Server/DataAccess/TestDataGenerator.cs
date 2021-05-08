using SEIIApp.Server.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEIIApp.Server.DataAccess {

    public static class TestDataGenerator {

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

    }
}
