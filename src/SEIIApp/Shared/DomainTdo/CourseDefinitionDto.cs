using System.ComponentModel.DataAnnotations;


namespace SEIIApp.Shared.DomainTdo {

    public class CourseDefinitionBaseDto {
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string CourseName { get; set; }
    }

    public class CourseDefinitionDto : CourseDefinitionBaseDto {

        //TODO: Replace with real dto
        [ValidateComplexType]
        public QuestionDefinitionDto[] Questions { get; set; }
    }

}
