using System;
using System.ComponentModel.DataAnnotations;

namespace SEIIApp.Shared.DomainTdo
{

    // Data transfer object for the video chapter element.
    public class VideoDefinitionDto: ChapterElementDefinitionDto
    {

        public String Description { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 1)]
        public Uri VideoUri { get; set; }


        public override ChapterElementType GetChapterElementType()
        {
            return ChapterElementType.Video;
        }

    }
}
