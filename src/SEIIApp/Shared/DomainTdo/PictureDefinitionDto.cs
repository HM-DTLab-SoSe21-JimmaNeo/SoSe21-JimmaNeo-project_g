using System;

namespace SEIIApp.Shared.DomainTdo
{

    // Data transfer object for the picture chapter element.
    public class PictureDefinitionDto: ChapterElementDefinitionDto
    {

        public ChapterElementType Type = ChapterElementType.Picture;

        public String Description { get; set; }

        public Uri PictureUri { get; set; }

    }
}
