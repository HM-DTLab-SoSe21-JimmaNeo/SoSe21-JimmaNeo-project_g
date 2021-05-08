using System;

namespace SEIIApp.Shared.DomainTdo
{

    // Used to provide a single datatype for all data classes, that represent elements of a chapter.
    // Must be inherited by all data classes, representing elements of a chapter.
    public class ChapterElementDefinitionDto
    {

        public int Id { get; set; }

        public ChapterElementType elementType
        {
            get
            {
                return this.elementType;
            }

            set
            {
                if (Enum.IsDefined(typeof(ChapterElementDefinitionDto), value))
                    this.elementType = (ChapterElementType)value;
                else
                    this.elementType = ChapterElementType.Unknown;
            }
        }

        private ChapterElementDefinitionDto()
        {
            // Not meant to be instantiated.
        }
    }
}
