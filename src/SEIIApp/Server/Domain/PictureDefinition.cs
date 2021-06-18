using System;
using System.Reflection.Metadata;
using SEIIApp.Shared.DomainTdo;

namespace SEIIApp.Server.Domain
{

    // Represents a picture chapter element.
    public class PictureDefinition : ChapterElementDefinition
    {

        public String Description { get; set; }

        // Used if you want to reference your picture via an uri.
        public Uri PictureUri { get; set; }

        // Used if you want to store your picture directly in the database.
        // Maximum size for the picture is 2 GB (https://docs.microsoft.com/en-us/dynamics365/business-central/dev-itpro/developer/methods-auto/blob/blob-data-type)
        public Blob Picture { get; set; }

    }

}
