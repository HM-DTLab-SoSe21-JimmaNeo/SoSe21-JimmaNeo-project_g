using System;
using SEIIApp.Shared.DomainTdo;
using System.Collections.Generic;

namespace SEIIApp.Server.Domain {

    public class QuizDefinition : ChapterElementDefinition{

        public string QuizName { get; set; }

        public List<QuestionDefinition> Questions { get; set; }

    }
}
