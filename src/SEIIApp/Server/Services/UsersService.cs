using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SEIIApp.Server.DataAccess;
using SEIIApp.Server.Domain;
using System.Linq;
using System.Collections.Generic;

namespace SEIIApp.Server.Services
{

    public class UserDefinitionService
    {

        private DatabaseContext DatabaseContext { get; set; }
        private IMapper Mapper { get; set; }
        private LoginService LoginService { get; set; }

        public UserDefinitionService(DatabaseContext db, IMapper mapper, LoginService loginService)
        {
            this.DatabaseContext = db;
            this.Mapper = mapper;
            this.LoginService = loginService;
        }

        private IQueryable<UserDefinition> GetQueryableForUserDefinitions()
        {
            return DatabaseContext
                .UserDefinitions
                .Include(User => User.AsignedCourses)
                .Include(User => User.AuthDefinitions);
        }

        /// <summary>
        /// Returns all users. Includes also the courses.
        /// </summary>
        public UserDefinition[] GetAllUsers()
        {
            return GetQueryableForUserDefinitions().ToArray();
        }

        /// <summary>
        /// Returns the user with the given id. Includes also the courses.
        /// </summary>
        public UserDefinition GetUserById(int id)
        {
            UserDefinition UserDefinition = GetQueryableForUserDefinitions().Where(User => User.UserId == id).FirstOrDefault();
            return UserDefinition;
        }

        /// <summary>
        /// Adds a user.
        /// </summary>
        public UserDefinition AddUser(UserDefinition User)
        {
            if (User.AuthDefinitions == null)
            {
                User.AuthDefinitions = new List<AuthDefinition>();
                User.AuthDefinitions.Add(new AuthDefinition());
            }

            User.AuthDefinitions[0].UserName = User.Email;
            User.AuthDefinitions[0].Password = RandomPassword();  //TODO: Send Password via mail
            User.AuthDefinitions[0].Password = "password";        // Then delete this line  
            User.CreationDate = DateTime.Now;
            User.ChangeDate = DateTime.Now;
            DatabaseContext.UserDefinitions.Add(User);
            DatabaseContext.SaveChanges();
            return User;
        }

        /// <summary>
        /// Updates a user.
        /// </summary>
        public UserDefinition UpdateUser(UserDefinition User)
        {
            User.ChangeDate = DateTime.Now;

            // Needed for the change of the username
            foreach (AuthDefinition authDefinition in User.AuthDefinitions)
            {
                authDefinition.Password = LoginService.GetAuth(authDefinition.Id).Password;
            }

            DatabaseContext.UserDefinitions.Update(User);
            DatabaseContext.SaveChanges();
            return User;
        }

        /// <summary>
        /// Removes a user and all dependencies.
        /// </summary>
        public void RemoveUser(UserDefinition User)
        {
            DatabaseContext.UserDefinitions.Remove(User);
            DatabaseContext.SaveChanges();
        }

        /// <summary>
        /// Returns the user for a given authentification.
        /// </summary>
        public UserDefinition GetUserByLogin(AuthDefinition authDefinition)
        {
            UserDefinition UserDefinition = GetQueryableForUserDefinitions().Where(User => User.AuthDefinitions.Contains(authDefinition)).FirstOrDefault();
            return UserDefinition;
        }


        // Credit to : https://stackoverflow.com/questions/1344221/how-can-i-generate-random-alphanumeric-strings
        private static Random random = new Random();
        private string RandomPassword(int length = 5)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

    }

}
