using System;

namespace SEIIApp.Shared.DomainTdo
{

    // Data transfer object for the explanatory text chapter element.
    public class ExplanatoryTextDefinitionDto: ChapterElementDefinitionDto
    {

        public ChapterElementType Type = ChapterElementType.Text;

        public String Title { get; set; }

        public String ContentText { get; set; }

    }

}