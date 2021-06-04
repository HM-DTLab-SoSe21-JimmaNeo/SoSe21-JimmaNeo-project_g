using System;
using System.Reflection.Metadata;
using SEIIApp.Shared.DomainTdo;

namespace SEIIApp.Server.Domain
{

    // Represents an picture element for chapters.
    public class PictureDefinition: ChapterElementDefinition
    {

        public String Description { get; set; }

        public Blob Picture { get; set; }

    }
}
