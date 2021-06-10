﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEIIApp.Shared.DomainTdo
{

    // Data transfer object for the answer of a question of a quiz chapter element.
    public class AnswerDefinitionDto
    {

        [Required]
        [StringLength(250, MinimumLength = 1)]
        public string AnswerText { get; set; }

        public bool IsCorrectAnswer { get; set; }

    }

}
