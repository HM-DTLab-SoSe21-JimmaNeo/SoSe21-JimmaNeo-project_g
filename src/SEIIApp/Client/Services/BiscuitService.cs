using Microsoft.AspNetCore.Http;
using SEIIApp.Shared.DomainTdo;
using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SEIIApp.Client.Services
{

    /// <summary>
    /// Makes it simpler to work with the biscuit and removes redundancy.
    /// Only use this class instead of the biscuit
    /// </summary>
    public class BiscuitService
    {
        UserDefinitionBackendService UserDefinitionBackendService { get; set; }
        HttpContextAccessor HttpContextAccessor { get; set; }

        public BiscuitService(UserDefinitionBackendService userDefinitionBackendService, HttpContextAccessor HttpContextAccessor)
        {
            this.UserDefinitionBackendService = userDefinitionBackendService;
            this.HttpContextAccessor = HttpContextAccessor;

        }

        public async Task<UserDefinitionDto> UpdateUser(int userId)
        {
           return Biscuit.User = await UserDefinitionBackendService.GetUserById(userId);
        }

        /// <summary>
        /// User when 
        /// </summary>
        /// <param name="loginDto"></param>
        /// <returns></returns>
        public async Task<UserDefinitionDto> UpdateUser(LoginDto loginDto)
        {
            return Biscuit.User = await UserDefinitionBackendService.GetUserByAuth(loginDto);
        }


        public async Task<UserDefinitionDto> GetUser()
        {
            //  if(Biscuit.User == null)
            //  {

            if(HttpContextAccessor.HttpContext == null)
            {
                Console.WriteLine("Fuck");
            }

            var test1 = HttpContextAccessor;

                var userId = HttpContextAccessor.HttpContext.Request.Query["UserId"];
                return Biscuit.User = await UserDefinitionBackendService.GetUserById(userId);
           // }
           // return Biscuit.User;
        }

        /// <summary>
        /// Always use in app when static content is needed.
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string UriBuilderStuffStatic(string url)
        {
            HttpContextAccessor HttpContextAccessor = new HttpContextAccessor();        // Duplication necessary due to static context
            var UriBuilder = new UriBuilder(url);
            var query = HttpUtility.ParseQueryString(UriBuilder.Query);
            var userId = HttpContextAccessor.HttpContext.Request.Query["UserId"][0];
            query["userId"] = userId;
            UriBuilder.Query = query.ToString();
            return url = UriBuilder.ToString();
        }
        
        /// <summary>
        /// Always use in app.
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public string UriBuilderStuff(string url)
        {
            HttpContextAccessor HttpContextAccessor = new HttpContextAccessor();        // Duplication necessary due to static context
            var UriBuilder = new UriBuilder(url);
            var query = HttpUtility.ParseQueryString(UriBuilder.Query);
            var userId = HttpContextAccessor.HttpContext.Request.Query["UserId"][0];
            query["UserId"] = userId;
            UriBuilder.Query = query.ToString();
            return url = UriBuilder.ToString();
        }
        

        /// <summary>
        /// Needed for login, aviable when userId IS DEFINETLY SHURE.
        /// ONLY usage in Index.razor
        /// </summary>
        /// <param name="url"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public string UriBuilderStuff(string url, int userId)
        {
            return url + "?UserId=" + userId;
        }


    }
}
