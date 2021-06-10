using System;
using System.Reflection.Metadata;

namespace SEIIApp.Server.Domain
{

    // Represents a video chapter element.
    public class VideoDefinition : ChapterElementDefinition
    {

        public String Description { get; set; }

        // Used if you want to reference your video via an uri.
        public Uri VideoUri { get; set; }

        // Used if you want to store your video directly in the database.
        // Maximum size for the video is 2 GB (https://docs.microsoft.com/en-us/dynamics365/business-central/dev-itpro/developer/methods-auto/blob/blob-data-type)
        public Blob Video { get; set; }

    }

}
