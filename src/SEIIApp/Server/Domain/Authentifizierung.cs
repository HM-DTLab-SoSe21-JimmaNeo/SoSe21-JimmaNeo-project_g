using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SEIIApp.Server.Domain
{

    // Represents the XXX
    public class Authentifizierung
    {

        [Key]
        public int Id { get; set; }

        public String UserName { get; set; }

        public String Password { get; set; }

        public String Role { get; set; }


    }

}