using System;
using SEIIApp.Shared.DomainTdo;

namespace SEIIApp.Server.Domain
{

    // Represents an explanatory text.
    public class ExplanatoryTextDefinition: ChapterElementDefinition
    {

        public ChapterElementType Type = ChapterElementType.Text;

        public String Title { get; set; }

        public String ContentText { get; set; }

    }

}