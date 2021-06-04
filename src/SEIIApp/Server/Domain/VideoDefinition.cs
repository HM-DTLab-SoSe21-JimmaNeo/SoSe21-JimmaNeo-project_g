using System;
using System.Reflection.Metadata;

namespace SEIIApp.Server.Domain
{

    // Represents an video element for chapters.
    public class VideoDefinition: ChapterElementDefinition
    {

        public String Description { get; set; }

        // Used if you want to reference your video via a uri.
        public Uri VideoUri { get; set; }

        // Used if you want to store your video directly in the database.
        // Maximum size is 2 GB (https://docs.microsoft.com/en-us/dynamics365/business-central/dev-itpro/developer/methods-auto/blob/blob-data-type)
        public Blob Video { get; set; }

    }
}
