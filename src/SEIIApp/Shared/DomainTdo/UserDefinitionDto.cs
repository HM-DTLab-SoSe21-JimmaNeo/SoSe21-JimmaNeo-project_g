using SEIIApp.Shared.DomainTdo;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SEIIApp.Shared.DomainTdo
{

    // Data transfer object for a user.
    public class UserDefinitionBaseDto
    {

        public int UserId { get; set; }

        [Required]
        public string Email { get; set; }

        public string Description { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ChangeDate { get; set; }

        // A user CAN potentially have more then one role, and role is saved in authentifications
        public AuthDefinitionDto[] AuthDefinitions { get; set; }

    }

    // Data transfer object for a user which also contains the assigned courses of the user.
    public class UserDefinitionDto : UserDefinitionBaseDto
    {
        public CourseDefinitionBaseDto[] AsignedCourses { get; set; }

    }

}