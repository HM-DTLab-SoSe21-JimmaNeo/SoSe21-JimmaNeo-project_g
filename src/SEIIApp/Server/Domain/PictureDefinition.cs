using System;
using SEIIApp.Shared.DomainTdo;

namespace SEIIApp.Server.Domain
{

    // Represents an picture element for chapters.
    public class PictureDefinition: ChapterElementDefinition
    {

        public String Description { get; set; }

        public Uri PictureUri { get; set; }


        public override ChapterElementType GetChapterElementType()
        {
            return ChapterElementType.Picture;
        }

    }
}
