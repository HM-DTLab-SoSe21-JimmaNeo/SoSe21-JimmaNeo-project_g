using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SEIIApp.Server.Domain
{

    // Represents a user.
    public class UserDefinition
    {

        [Key]
        public int UserId { get; set; }

        public string Email { get; set; }

        public string Description { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ChangeDate { get; set; }

        public List<CourseDefinition> AsignedCourses { get; set; }

        // A user CAN potentially have more then one role, and role is saved in authentifications
        public List<AuthDefinition> AuthDefinitions { get; set; }

    }

}
