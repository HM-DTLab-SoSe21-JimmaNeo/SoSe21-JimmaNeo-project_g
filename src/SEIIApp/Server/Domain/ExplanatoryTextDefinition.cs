using System;
using SEIIApp.Shared.DomainTdo;

namespace SEIIApp.Server.Domain
{

    // Represents an explanatory text.
    public class ExplanatoryTextDefinition: ChapterElementDefinition
    {

        public String Title { get; set; }

        public String ContentText { get; set; }


        public override ChapterElementType GetChapterElementType()
        {
            return ChapterElementType.Text;
        }

    }

}