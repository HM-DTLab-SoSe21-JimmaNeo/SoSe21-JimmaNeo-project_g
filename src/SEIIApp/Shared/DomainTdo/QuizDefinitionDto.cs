using System.ComponentModel.DataAnnotations;

namespace SEIIApp.Shared.DomainTdo {

    public class QuizDefinitionBaseDto : ChapterElementDefinitionDto {

        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string QuizName { get; set; }

        public ChapterElementType chapterElementType = ChapterElementType.Quiz;

    }

    public class QuizDefinitionDto : QuizDefinitionBaseDto {
        
        [ValidateComplexType]
        public QuestionDefinitionDto[] Questions { get; set; }

    }

}
