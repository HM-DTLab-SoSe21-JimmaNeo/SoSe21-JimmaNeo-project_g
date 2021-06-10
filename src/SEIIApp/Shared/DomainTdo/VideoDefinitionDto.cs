using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace SEIIApp.Shared.DomainTdo
{

    // Data transfer object for a video chapter element.
    public class VideoDefinitionDto : ChapterElementDefinitionDto
    {

        [Required]
        public String Description { get; set; }

        // Used if you want to reference your video via an uri.
        [StringLength(100, MinimumLength = 1)]
        public Uri VideoUri { get; set; }

        // Used if you want to store your video directly in the database.
        // Maximum size for the video is 2 GB (https://docs.microsoft.com/en-us/dynamics365/business-central/dev-itpro/developer/methods-auto/blob/blob-data-type)
        public Blob Video { get; set; }

    }

}
