using System;
using SEIIApp.Server.Domain;
using System.Collections.Generic;
using System.Reflection.Metadata;
using SEIIApp.Shared.DomainTdo;

namespace SEIIApp.Server.DataAccess {

    public static class TestDataGenerator {

        /// <summary>
        /// Creates a test course definition, which is visible and has a name.
        /// </summary>
        public static CourseDefinition CreateCourseDefinition(String name)
        {
            var course = new CourseDefinition();
            course.CourseName = name;
            course.CreationDate = DateTime.Now;
            course.ChangeDate = DateTime.Now;
            course.Visible = true;
            course.Chapters = new List<ChapterDefinition>();

            return course;
        }

        /// <summary>
        /// Creates a test chapter definition, which is visible and has a name.
        /// </summary>
        public static ChapterDefinition CreateChapterDefinition(String name)
        {
            var chapter = new ChapterDefinition();
            chapter.ChapterName = name;
            chapter.CreationDate = DateTime.Now;
            chapter.ChangeDate = chapter.CreationDate;
            chapter.Visible = true;
            chapter.ChapterElements = new List<ChapterElementDefinition>();

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

        /// <summary>
        /// Creates a test explanatory text definition, with some text and a title.
        /// </summary>
        public static ExplanatoryTextDefinition CreateExplanatoryTextDefinition(String title)
        {
            var explanatoryText = new ExplanatoryTextDefinition();
            explanatoryText.Title = title;
            explanatoryText.ContentText = "Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua.";

            return explanatoryText;
        }

        /// <summary>
        /// Creates a test picture definition, with a descreption and a dummy URI.
        /// </summary>
        public static PictureDefinition CreatePictureDefinition(String description)
        {
            var picture = new PictureDefinition();
            picture.Description = description;
            picture.Picture = new Blob();

            return picture;
        }

        /// <summary>
        /// Creates a test video definition, with a descreption and a dummy URI.
        /// </summary>
        public static VideoDefinition CreateVideoDefinition(String description)
        {
            var video = new VideoDefinition();
            video.Description = description;
            video.VideoUri = new Uri("https://example.com");

            return video;
        }



        /// Authentifizierung
        public static AuthDefinition CreateAuthentifizierung(String userName, String password, RoleType role)
        {
            var newAuth = new AuthDefinition();
            newAuth.UserName = userName;
            newAuth.Password = password;
            newAuth.Role = role;

            return newAuth;

        }

        public static UserDefinition CreateUser(String email)
        {
            var userDefinition = new UserDefinition();
            userDefinition.Description = "Lorem ipsum";
            userDefinition.Email = email;
            userDefinition.AsignedCourses = new List<CourseDefinition>();
            userDefinition.AuthDefinitions = new List<AuthDefinition>();

            return userDefinition;
        }
    }
}
