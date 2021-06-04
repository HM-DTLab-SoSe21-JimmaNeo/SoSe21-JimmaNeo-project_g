using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;
using SEIIApp.Shared.DomainTdo;

namespace SEIIApp.Server.Domain
{

    // This contains everything that is needed for new Chapterelements.

    // Btw, this is very bad code, but we dont have time to make this properly, so...

    // When you want to create a new Chapterelement, his fields have to be in here, else it wont work
    public class UltimateChapterElementDefinition
    {
        //General
        [Key]
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

        public List<QuestionDefinition> Questions { get; set; }

        //Video 

        //<-- Description already present in picture
        public Uri VideoUri { get; set; }
    }
}
