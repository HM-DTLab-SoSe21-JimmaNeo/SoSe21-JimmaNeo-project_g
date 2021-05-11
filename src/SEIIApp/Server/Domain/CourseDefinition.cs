using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SEIIApp.Server.Domain {

    public class CourseDefinition{

        [Key]
        public int Id { get; set; }

        public string CourseName { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ChangeDate { get; set; }

        public bool Visible { get; set; }

        public List<ChapterDefinition> Chapters { get; set; }

    }

}
