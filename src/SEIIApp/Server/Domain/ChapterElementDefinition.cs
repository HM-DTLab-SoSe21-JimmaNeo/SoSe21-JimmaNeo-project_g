using System;
using System.ComponentModel.DataAnnotations;
using SEIIApp.Shared.DomainTdo;

namespace SEIIApp.Server.Domain
{

    // Used to provide a single datatype for all data classes, that represent elements of a chapter.
    // Must be inherited by all data classes, representing elements of a chapter.
    public class ChapterElementDefinition
    {

        [Key]
        public int Id { get; set; }

        public ChapterElementType elementType
        {
            get
            {
                return this.elementType;
            }

            set
            {
                if (Enum.IsDefined(typeof(ChapterElementDefinition), value))
                    this.elementType = (ChapterElementType)value;
                else
                    throw new ArgumentException("The type you are trying to create a chapter element of does not exist!");
            }
        }

        private ChapterElementDefinition()
        {
            // Not meant to be instantiated.
        }
    }
}
