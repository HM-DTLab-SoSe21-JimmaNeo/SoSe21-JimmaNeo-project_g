using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SEIIApp.Server.Domain
{

    // Represents the chapters of a course.
    public class ChapterDefinition
    {

        [Key]
        public int ChapterId { get; set; }

        public string ChapterName { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ChangeDate { get; set; }

        public bool Visible { get; set; }

        public List<ChapterElementDefinition> ChapterElements { get; set; }

    }

}