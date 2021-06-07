using SEIIApp.Shared.DomainTdo;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SEIIApp.Server.Domain
{

    // Represents the XXX
    public class AuthDefinition
    {

        [Key]
        public int Id { get; set; }

        public String UserName { get; set; }

        public String Password { get; set; }

        public RoleType Role { get; set; }


    }

}