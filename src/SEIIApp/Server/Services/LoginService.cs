using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SEIIApp.Server.DataAccess;
using SEIIApp.Server.Domain;
using System.Linq;
using SEIIApp.Shared.DomainTdo;

namespace SEIIApp.Server.Services
{

    public class LoginService
    {

        private DatabaseContext DatabaseContext { get; set; }
        private IMapper Mapper { get; set; }

        public LoginService(DatabaseContext db, IMapper mapper)
        {
            this.DatabaseContext = db;
            this.Mapper = mapper;
        }

        /// <summary>
        /// Returns the role type for a given user and password.
        /// </summary>
        public RoleType GetRole(String userName, String password)
        {
            var result = (from auth in DatabaseContext.AuthDefinitions where auth.UserName == userName && auth.Password == password select auth.Role).FirstOrDefault();
            return result;
        }

        /// <summary>
        /// Returns the authentification for a given user and password.
        /// </summary>
        public AuthDefinition GetAuth(String userName, String password)
        {
            var result = (from auth in DatabaseContext.AuthDefinitions where auth.UserName == userName && auth.Password == password select auth).FirstOrDefault();
            return result;
        }

        /// <summary>
        /// Returns the authentification with a given id.
        /// </summary>
        public AuthDefinition GetAuth(int id)
        {
            var result = (from auth in DatabaseContext.AuthDefinitions where auth.Id == id select auth).FirstOrDefault();
            return result;
        }

        /// <summary>
        /// Adds an authentification.
        /// </summary>
        public AuthDefinition AddAuth(AuthDefinition auth)
        {
            try
            {
                DatabaseContext.AuthDefinitions.Add(auth);
                DatabaseContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }

            return auth;
        }

        public AuthDefinition UpdateAuth(AuthDefinition auth)
        {
            DatabaseContext.AuthDefinitions.Update(auth);
            DatabaseContext.SaveChanges();
            return auth;
        }

    }

}
