using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;


namespace SEIIApp.Shared.DomainTdo
{

    public class AuthDefinitionDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 1)]
        public String UserName { get; set; }

        public RoleType Role { get; set; }
    }

    public class LoginDto : AuthDefinitionDto
    {

        public String Password { get; set; }

    }

}