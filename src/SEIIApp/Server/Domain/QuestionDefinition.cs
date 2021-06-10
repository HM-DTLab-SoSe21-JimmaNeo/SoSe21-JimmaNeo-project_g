using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SEIIApp.Server.Domain
{

    // Represents a question of a quiz chapter element.
    public class QuestionDefinition
    {

        [Key]
        public int Id { get; set; }

        public string QuestionText { get; set; }

        public List<AnswerDefinition> Answers { get; set; }

    }

}
