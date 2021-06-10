using System;
using System.Reflection.Metadata;
using SEIIApp.Shared.DomainTdo;

namespace SEIIApp.Server.Domain
{

    // Represents a picture chapter element.
    public class PictureDefinition : ChapterElementDefinition
    {

        public String Description { get; set; }

        public Blob Picture { get; set; }

    }

}
