using System.ComponentModel.DataAnnotations;

namespace SEIIApp.Shared.DomainTdo
{

    // Data transfer object for a quiz chapter element.
    public class QuizDefinitionBaseDto : ChapterElementDefinitionDto
    {

        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string QuizName { get; set; }

        public ChapterElementType chapterElementType = ChapterElementType.Quiz;

    }

    // Data transfer object for a quiz chapter element which also contains the questions of the quiz.
    public class QuizDefinitionDto : QuizDefinitionBaseDto
    {

        [ValidateComplexType]
        public QuestionDefinitionDto[] Questions { get; set; }

    }

}
