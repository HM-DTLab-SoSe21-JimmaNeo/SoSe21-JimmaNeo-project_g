using System;

namespace SEIIApp.Shared.DomainTdo
{

    // Used to provide a single datatype for all data classes, that represent elements of a chapter.
    // Must be inherited by all data classes, representing elements of a chapter.
    public class ChapterElementDefinitionDto
    {

        public int Id { get; set; }


        public virtual ChapterElementType GetChapterElementType()
        {
            throw new Exception("The superclass of the chapter elements doesn't have a chaper element type and mustn't be instantiated!");
        }

    }
}
