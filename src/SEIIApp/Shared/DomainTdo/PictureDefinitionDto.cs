using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace SEIIApp.Shared.DomainTdo
{

    // Data transfer object for the picture chapter element.
    public class PictureDefinitionDto: ChapterElementDefinitionDto
    {

        public String Description { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 1)]
        public Blob Picture { get; set; }

    }
}
