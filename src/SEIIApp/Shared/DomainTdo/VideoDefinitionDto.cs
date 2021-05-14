using System;

namespace SEIIApp.Shared.DomainTdo
{

    // Data transfer object for the video chapter element.
    public class VideoDefinitionDto: ChapterElementDefinitionDto
    {

        public ChapterElementType Type = ChapterElementType.Video;

        public String Description { get; set; }

        public Uri VideoUri { get; set; }

    }
}
