using System;
using System.ComponentModel.DataAnnotations;

namespace SEIIApp.Shared.DomainTdo
{

    // Data transfer object for the explanatory text chapter element.
    public class ExplanatoryTextDefinitionDto: ChapterElementDefinitionDto
    {

        [Required]
        [StringLength(100, MinimumLength = 1)]
        public String Title { get; set; }

        public String ContentText { get; set; }


        public override ChapterElementType GetChapterElementType()
        {
            return ChapterElementType.Text;
        }

    }

}