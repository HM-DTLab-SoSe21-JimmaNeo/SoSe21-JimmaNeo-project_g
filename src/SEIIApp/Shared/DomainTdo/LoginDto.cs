using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;


namespace SEIIApp.Shared.DomainTdo
{

    public class LoginDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 1)]
        public String userName { get; set; }
        public String Password { get; set; }

        public String Role { get; set; }


    }


}