using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SEIIApp.Server.Domain {

    public class CourseDefinition{

        [Key]
        public int Id { get; set; }

        public string CourseName { get; set; }

        //TODO: Replace String with the Chapter definition
        public List<QuestionDefinition> Chapter { get; set; }

    }

}
