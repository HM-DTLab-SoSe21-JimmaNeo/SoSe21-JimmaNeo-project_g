using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace SEIIApp.Shared.DomainTdo
{

    // Data transfer object for an authentification.
    public class AuthDefinitionDto
    {

        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 1)]
        public String UserName { get; set; }

        public RoleType Role { get; set; }

    }

    // Data transfer object for an authentification which also contains the password.
    public class LoginDto : AuthDefinitionDto
    {
        public String Password { get; set; }
    }

}