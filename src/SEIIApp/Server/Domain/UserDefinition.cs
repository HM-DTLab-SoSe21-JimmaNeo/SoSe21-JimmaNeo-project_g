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

        // This is kind of a foreign key
        public List<AsignedCoursesIdClass> AsignedCoursesId { get; set; }

        // A user CAN potentially have more then one role, and role is saved in authentifications
        public List<AuthDefinition> AuthDefinitions { get; set; }

    }

    // Used for Apis
    public class UserDefinitionCourses : UserDefinition
    {
        public List<CourseDefinition>  AsignedCourses { get; set; }
    }

    // https://forums.asp.net/t/2096921.aspx?list+string+is+not+a+supported+primitive+type+or+a+valid+entity+type
    // This is just stupid, but it works.
    // 2 options here, use this class or use array (maybe), both are stupid
    public class AsignedCoursesIdClass
    {
        [Key]
        public int ID { get; set; }

        public int AsignedCoursesId { get; set; }

    }

}
