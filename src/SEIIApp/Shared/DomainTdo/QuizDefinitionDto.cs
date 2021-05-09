using System.ComponentModel.DataAnnotations;

namespace SEIIApp.Shared.DomainTdo {

    public class QuizDefinitionBaseDto {
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string QuizName { get; set; }
    }

    public class QuizDefinitionDto : QuizDefinitionBaseDto {
        
        [ValidateComplexType]
        public QuestionDefinitionDto[] Questions { get; set; }

    }

}
