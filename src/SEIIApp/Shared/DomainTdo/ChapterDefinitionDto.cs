using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;


namespace SEIIApp.Shared.DomainTdo
{

    public class ChapterDefinitionBaseDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string ChapterName { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ChangeDate { get; set; }

        public bool Visible { get; set; }

    }

    public class ChapterDefinitionDto : ChapterDefinitionBaseDto
    {

        [ValidateComplexType]
        public ChapterElementDefinitionDto[] ChapterElements { get; set; }
    }

}