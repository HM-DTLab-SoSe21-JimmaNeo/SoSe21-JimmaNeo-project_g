using System;
using SEIIApp.Shared.DomainTdo;
using System.Collections.Generic;

namespace SEIIApp.Server.Domain
{

    // Represents a quiz chapter element.
    public class QuizDefinition : ChapterElementDefinition
    {

        public string QuizName { get; set; }

        public List<QuestionDefinition> Questions { get; set; }

    }

}
