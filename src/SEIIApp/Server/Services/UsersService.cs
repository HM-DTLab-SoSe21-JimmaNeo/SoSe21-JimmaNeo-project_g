using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SEIIApp.Server.DataAccess;
using SEIIApp.Server.Domain;
using System.Linq;
using System.Collections.Generic;
using System.Net.Mail;
using System.Net;
using SEIIApp.Shared.DomainTdo;

namespace SEIIApp.Server.Services
{

    public class UserDefinitionService
    {

        private DatabaseContext DatabaseContext { get; set; }
        private IMapper Mapper { get; set; }
        private LoginService LoginService { get; set; }

        private CourseDefinitionService CourseDefinitionService { get; set; }

        public UserDefinitionService(DatabaseContext db, IMapper mapper, LoginService loginService, CourseDefinitionService courseDefinitionService)
        {
            this.DatabaseContext = db;
            this.Mapper = mapper;
            this.LoginService = loginService;
            this.CourseDefinitionService = courseDefinitionService;
        }

        private IQueryable<UserDefinition> GetQueryableForUserDefinitions()
        {
            return DatabaseContext
                .UserDefinitions
                .Include(User => User.AuthDefinitions)
                .Include(User => User.AsignedCoursesId);
        }
        
        private IQueryable<AsignedCoursesIdClass> GetQueryableForAsignedCDefinitions()
        {
            return DatabaseContext
                .AsignedCoursesIds;
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
        public UserDefinitionCourses GetUserById(int id)
        {
            UserDefinition UserDefinition = GetQueryableForUserDefinitions().Where(User => User.UserId == id).FirstOrDefault();

            if (UserDefinition == null) { return null; };

            var userDefinitionCourses = Mapper.Map<UserDefinitionCourses>(UserDefinition);
            userDefinitionCourses.AsignedCourses = new List<CourseDefinition>();

            for (int i = 0; i < UserDefinition.AsignedCoursesId.Count; i++)
            {
                if(CourseDefinitionService.GetCourseById(UserDefinition.AsignedCoursesId[i].AsignedCoursesId) != null)
                {
                    userDefinitionCourses.AsignedCourses.Add(CourseDefinitionService.GetCourseById(UserDefinition.AsignedCoursesId[i].AsignedCoursesId));
                }

            }
            return userDefinitionCourses;
        }

        /// <summary>
        /// Adds a user.
        /// </summary>
        public UserDefinitionCourses AddUser(UserDefinitionCourses User)
        {
            if (User.AuthDefinitions.Count == 0)
            {
                User.AuthDefinitions = new List<AuthDefinition>();
                var tempAuth = new AuthDefinition();
                tempAuth.Password = RandomPassword();  //TODO: Send Password via mail
                tempAuth.Password = "password";        // Then delete this line  
                tempAuth.UserName = User.Email;
                LoginService.AddAuth(tempAuth);
                User.AuthDefinitions.Add(tempAuth);
            }

            if(User.AsignedCoursesId == null)
            {
                User.AsignedCoursesId = new List<AsignedCoursesIdClass>();
            }

            User.CreationDate = DateTime.Now;
            User.ChangeDate = DateTime.Now;

            // The following for loops are necessary du to database stuff
            var asignedCoursesIdClasses = User.AsignedCoursesId;

            for (int i = 0; i < User.AsignedCourses.Count; i++)
            {
                bool alreadyHere = false;
                for(int j = 0; j < asignedCoursesIdClasses.Count; j++)
                {
                    if(asignedCoursesIdClasses[j].AsignedCoursesId == User.AsignedCourses[i].CourseId)
                    {
                        alreadyHere = true;
                    }
                }
                if(alreadyHere != true)
                {
                    var why = new AsignedCoursesIdClass();
                    why.AsignedCoursesId = User.AsignedCourses[i].CourseId;
                    User.AsignedCoursesId.Add(why);
                }
            }

            var UserToSave = Mapper.Map<UserDefinition>(User);

            DatabaseContext.UserDefinitions.Add(UserToSave);
            DatabaseContext.SaveChanges();
            return GetUserById(UserToSave.UserId); // Needed to get the id
        }

        /// <summary>
        /// Updates a user.
        /// </summary>
        public UserDefinitionCourses UpdateUser(UserDefinitionCourses User)
        {

            var originalUser = GetUserById(User.UserId);

            User.ChangeDate = DateTime.Now;

            // Needed for the change of the username
            foreach (AuthDefinition authDefinition in User.AuthDefinitions)
            {
                if(authDefinition.Id == null || authDefinition.Id == 0)
                {
                    var auth = new AuthDefinition();
                    auth.Password = RandomPassword();  // TODO: Send Password via mail
                    auth.UserName = User.Email;
                    LoginService.AddAuth(auth);
                }
                authDefinition.Password = LoginService.GetAuth(authDefinition.Id).Password;
            }


            // Check if old user has chapters that are not included in the updated one and deletes those
            for(int i = 0; i < originalUser.AsignedCoursesId.Count; i++)
            {
                var hasToBeDeleted = true;
                for (int j = 0; j < User.AsignedCourses.Count; j++)
                {
                    if(originalUser.AsignedCoursesId[i].AsignedCoursesId == User.AsignedCourses[j].CourseId)
                    {
                        hasToBeDeleted = false;
                    }
                }
                if (hasToBeDeleted)
                {
                    DatabaseContext.AsignedCoursesIds.Remove(originalUser.AsignedCoursesId[i]);
                    DatabaseContext.SaveChanges();
                }
            }

            // Adds new Asigned Courses
            User.AsignedCoursesId = originalUser.AsignedCoursesId;

            if (User.AsignedCoursesId == null)
            {
                User.AsignedCoursesId = new List<AsignedCoursesIdClass>();
            }
            // The following for loops are necessary du to database stuff
            var asignedCoursesIdClasses = User.AsignedCoursesId;

            for (int i = 0; i < User.AsignedCourses.Count; i++)
            {
                bool alreadyHere = false;
                for (int j = 0; j < asignedCoursesIdClasses.Count; j++)
                {
                    if (asignedCoursesIdClasses[j].AsignedCoursesId == User.AsignedCourses[i].CourseId)
                    {
                        alreadyHere = true;
                    }

                }
                if (alreadyHere != true)
                {
                    var why = new AsignedCoursesIdClass();
                    why.AsignedCoursesId = User.AsignedCourses[i].CourseId;
                    User.AsignedCoursesId.Add(why);
                }
            }

            DatabaseContext.UserDefinitions.Update(User);
            DatabaseContext.SaveChanges();
            sendMail(User.Email, User.UserId, User.AuthDefinitions[0].Role); // When a user gets created, an email will be send to set password
            return User;
        }

        /// <summary>
        /// Removes a user and all dependencies.
        /// </summary>
        public void RemoveUser(UserDefinitionCourses User)
        {
            DatabaseContext.UserDefinitions.Remove(User);
            DatabaseContext.SaveChanges();
        }

        /// <summary>
        /// Returns the user for a given authentification.
        /// </summary>
        public UserDefinitionCourses GetUserByLogin(AuthDefinition authDefinition)
        {
            UserDefinition UserDefinition = GetQueryableForUserDefinitions().Where(User => User.AuthDefinitions.Contains(authDefinition)).FirstOrDefault();
            var userDefinitionCourses = Mapper.Map<UserDefinitionCourses>(UserDefinition);
            userDefinitionCourses.AsignedCourses = new List<CourseDefinition>();

            for (int i = 0; i < UserDefinition.AsignedCoursesId.Count; i++)
            {
                if (CourseDefinitionService.GetCourseById(UserDefinition.AsignedCoursesId[i].AsignedCoursesId) != null)
                {
                    userDefinitionCourses.AsignedCourses.Add(CourseDefinitionService.GetCourseById(UserDefinition.AsignedCoursesId[i].AsignedCoursesId));
                }

            }
            return userDefinitionCourses;
        }

        /// <summary>
        /// Gets alls Users for a course.
        /// </summary>
        /// <param name="courseId"></param>
        /// <returns></returns>
        public UserDefinition[] GetUsersForCourse(int courseId)
        {

            var users = GetQueryableForUserDefinitions().ToArray();

            var usersReturn = new List<UserDefinition>();

            for(int i = 0; i < users.Length; i++)
            {
                for(int j = 0; j < users[i].AsignedCoursesId.Count; j++)
                {
                    if(courseId == users[i].AsignedCoursesId[j].AsignedCoursesId)
                    {
                        usersReturn.Add(users[i]);
                        break;
                    }
                }
            }
            return usersReturn.ToArray();

        }

        public UserDefinition[] AddUserToCourse(int courseId, int userId)
        {
            var user = GetUserById(userId);
            if (user != null)
            {

                var courseAlreadyThere = false;
                for (int i = 0; i < user.AsignedCoursesId.Count; i++)
                {
                    if (courseId == user.AsignedCoursesId[i].AsignedCoursesId)
                    {
                        courseAlreadyThere = true;
                    }
                }
                if (!courseAlreadyThere)
                {
                    var assignedCourseIdClass = new AsignedCoursesIdClass();
                    assignedCourseIdClass.AsignedCoursesId = courseId;
                    user.AsignedCoursesId.Add(assignedCourseIdClass);
                    DatabaseContext.UserDefinitions.Update(user);
                    DatabaseContext.SaveChanges();
                }

                return GetUsersForCourse(courseId);
            }
            return null; //TODO Fehlerausgabe
        }
        
        
        public UserDefinition[] RemoveUserFromCourse(int courseId, int userId)
        {
            var user = GetUserById(userId);

            var thisIsTheOne = false;
            for(int i = 0; i < user.AsignedCoursesId.Count; i++)
            {
                if(courseId == user.AsignedCoursesId[i].AsignedCoursesId)
                {
                    thisIsTheOne = true;
                }
                if (thisIsTheOne)
                {

                    DatabaseContext.AsignedCoursesIds.Remove(user.AsignedCoursesId[i]);
                    DatabaseContext.SaveChanges();
                    return GetUsersForCourse(courseId);

                }
            }


            return GetUsersForCourse(courseId);
        }




        // Credit to : https://stackoverflow.com/questions/1344221/how-can-i-generate-random-alphanumeric-strings
        private static Random random = new Random();
        private string RandomPassword(int length = 5)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        /// <summary>
        /// This sends the mail to set the password and username.
        /// </summary>
        /// <param name="userEmail"></param>
        /// <param name="userId"></param>
        /// <param name="roleType"></param>
        private void sendMail(string userEmail, int userId, RoleType roleType)
        {
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("alexandriahelp0@gmail.com", "secretPassword123"),
                EnableSsl = true,
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress("alexandriahelp0@gmail.com"),
                Subject = "Welcome to Alexandria!",
                // The bodyimplementation is still pretty ugls, TODO: change!
                Body = "<h2 > Hello User! </h2 ><br /><br /><p > With this email you have been invited to join ALEXANDRIA, please use the link below to set up your account:</p ><a href = \"https://localhost:5001/passwordsetter/" + userId + "\" > Set up account</a><br /><br /><br /><p>This email has been send by ALEXANDRIA, if this email has been falsly send to you, please ignore or answer to this</p>",
                IsBodyHtml = true,
            };
            mailMessage.To.Add(userEmail);


            smtpClient.Send(mailMessage);
        }

    }

}