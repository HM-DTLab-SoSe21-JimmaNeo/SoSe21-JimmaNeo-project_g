using System;
using System.ComponentModel.DataAnnotations;

namespace SEIIApp.Shared.DomainTdo
{

    // Data transfer object for a course.
    public class CourseDefinitionBaseDto
    {

        public int CourseId { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string CourseName { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ChangeDate { get; set; }

        public bool Visible { get; set; }

    }

    // Data transfer object for a course which also contains the chapters of the course.
    public class CourseDefinitionDto : CourseDefinitionBaseDto
    {

        [ValidateComplexType]
        public ChapterDefinitionDto[] Chapters { get; set; }

    }

}
