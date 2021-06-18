using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace SEIIApp.Shared.DomainTdo
{

    // This contains everything that is needed for new Chapterelements.
    // When you want to create a new Chapterelement, his fields have to be in here, else it wont work.

    // Btw, this is very bad code, but we dont have time to make this properly, so...
    public class UltimateChapterElementDefinitionDto
    {
        // Used for all chapter elements:
        public int Id { get; set; }

        public ChapterElementType ChapterElementType { get; set; }


        // Specific for an explanatory text chapter element:
        public String Title { get; set; }

        public String ContentText { get; set; }


        // Specific for a picture chapter element:
        public String Description { get; set; }

        public Uri PictureUri { get; set; }

        public Blob Picture { get; set; }


        // Specific for a quiz chapter element:
        public string QuizName { get; set; }

        public List<QuestionDefinitionDto> Questions { get; set; }


        // Specific for a video chapter element:
        //<-- Description already present in picture.

        public Uri VideoUri { get; set; }

        public Blob Video { get; set; }

    }

}
