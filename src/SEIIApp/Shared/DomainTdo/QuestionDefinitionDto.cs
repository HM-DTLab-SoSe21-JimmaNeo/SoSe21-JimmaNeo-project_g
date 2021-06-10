using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEIIApp.Shared.DomainTdo
{

    // Data transfer object for the question of a quiz chapter element.
    public class QuestionDefinitionDto
    {

        [Required]
        [StringLength(250, MinimumLength = 1)]
        public string QuestionText { get; set; }

        [ValidateComplexType]
        public AnswerDefinitionDto[] Answers { get; set; }

    }

}
