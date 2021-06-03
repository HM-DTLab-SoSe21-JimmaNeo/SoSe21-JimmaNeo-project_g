using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SEIIApp.Server.DataAccess;
using SEIIApp.Server.Domain;
using System.Linq;

namespace SEIIApp.Server.Services {
    public class LoginService {

        private DatabaseContext DatabaseContext { get; set; }
        private IMapper Mapper { get; set; }
        public LoginService(DatabaseContext db, IMapper mapper) {
            this.DatabaseContext = db;
            this.Mapper = mapper;
        }

        /// <summary>
        /// Returns the course with the given role. Includes also chapters.
        /// </summary>
        public String GetRole(String userName, String password) {

            var result = (from auth in DatabaseContext.Authentifizierungen where auth.UserName == userName && auth.Password == password select auth.Role).FirstOrDefault();
            return result;

        }

        public Authentifizierung GetAuth(String userName, String password)
        {

            var result = (from auth in DatabaseContext.Authentifizierungen where auth.UserName == userName && auth.Password == password select auth).FirstOrDefault();
            return result;

        }

        public Authentifizierung GetAuth(int id)
        {

            var result = (from auth in DatabaseContext.Authentifizierungen where auth.Id == id select auth).FirstOrDefault();
            return result;

        }

        /// <summary>
        /// Adds a chapter.
        /// </summary>
        public Authentifizierung AddAuth(Authentifizierung auth)
        {
            try
            {
                DatabaseContext.Authentifizierungen.Add(auth);
                DatabaseContext.SaveChanges();
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                
            }


            return auth;
        }


    }
}
