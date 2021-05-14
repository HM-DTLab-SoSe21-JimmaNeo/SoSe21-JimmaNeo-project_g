using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;


namespace SEIIApp.Shared.DomainTdo {

    public class CourseDefinitionBaseDto {

        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string CourseName { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ChangeDate { get; set; }

        public bool Visible { get; set; }

    }

    public class CourseDefinitionDto : CourseDefinitionBaseDto {

        [ValidateComplexType]
        public ChapterDefinitionBaseDto[] Chapters { get; set; }
    }

}
