using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEIIApp.Shared.DomainTdo
{

    /// <summary>
    /// Contains the user in a course.
    /// </summary>
    public class UserInCourseDto
    {
        public int CourseId{ get; set; }

        public UserDefinitionBaseDto[] Users{ get; set; }

    }

}
