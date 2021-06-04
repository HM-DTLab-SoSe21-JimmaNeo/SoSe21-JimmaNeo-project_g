using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace SEIIApp.Shared.DomainTdo
{

    // This contains everything that is needed for new Chapterelements.
    // Btw, this is very bad code, but we dont have time to make this properly, so...
    public class UltimateChapterElementDefinitionDto
    {
        public int Id { get; set; }

        public ChapterElementType ChapterElementType { get; set; }

        //Text

        public String Title { get; set; }

        public String ContentText { get; set; }

        //Picture

        public String Description { get; set; }

        public Blob Picture { get; set; }

        // Quiz
        public string QuizName { get; set; }

        public List<QuestionDefinitionDto> Questions { get; set; }

        //Video 

        //<-- Description already present in picture
        public Uri VideoUri { get; set; }
    }
}
