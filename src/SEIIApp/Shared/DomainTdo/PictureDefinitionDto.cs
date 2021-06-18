using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace SEIIApp.Shared.DomainTdo
{

    // Data transfer object for the picture chapter element.
    public class PictureDefinitionDto : ChapterElementDefinitionDto
    {
        public String Description { get; set; }

        // Used if you want to reference your picture via an uri.
        public Uri PictureUri { get; set; }

        // Used if you want to store your picture directly in the database.
        // Maximum size for the picture is 2 GB (https://docs.microsoft.com/en-us/dynamics365/business-central/dev-itpro/developer/methods-auto/blob/blob-data-type)
        [Required]
        [StringLength(100, MinimumLength = 1)]
        public Blob Picture { get; set; }

    }

}
