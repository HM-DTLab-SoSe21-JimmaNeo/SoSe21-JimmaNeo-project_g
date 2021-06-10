using System;
using System.ComponentModel.DataAnnotations;

namespace SEIIApp.Shared.DomainTdo
{

    // Data transfer object for a chapter.
    public class ChapterDefinitionBaseDto
    {

        public int ChapterId { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string ChapterName { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ChangeDate { get; set; }

        public bool Visible { get; set; }

    }

    // Data transfer object for a chapter which also containins the chapter elements of the chapter.
    public class ChapterDefinitionDto : ChapterDefinitionBaseDto
    {

        [ValidateComplexType]
        public ChapterElementDefinitionDto[] ChapterElements { get; set; }

    }

}