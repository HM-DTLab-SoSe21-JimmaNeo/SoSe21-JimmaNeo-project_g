using System;
using System.ComponentModel.DataAnnotations;

namespace SEIIApp.Server.Domain
{

    // Used to provide a single datatype for all data classes, that represent elements of a chapter.
    // Must be inherited by all data classes, representing elements of a chapter.
    public class ChapterElementDefinition
    {

        [Key]
        public int Id { get; set; }

        private ChapterElementDefinition()
        {
            // Not meant to be instantiated.
        }
    }
}
