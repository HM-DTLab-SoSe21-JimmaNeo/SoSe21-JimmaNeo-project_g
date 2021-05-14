using System;
using System.ComponentModel.DataAnnotations;

namespace SEIIApp.Shared.DomainTdo
{

    // Data transfer object for the picture chapter element.
    public class PictureDefinitionDto: ChapterElementDefinitionDto
    {

        public ChapterElementType Type = ChapterElementType.Picture;

        public String Description { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 1)]
        public Uri PictureUri { get; set; }

    }
}
