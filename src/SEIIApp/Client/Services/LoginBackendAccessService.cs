using SEIIApp.Shared.DomainTdo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SEIIApp.Client.Services {

    public class LoginBackendAccessService
    {

        private HttpClient HttpClient { get; set; }
        public LoginBackendAccessService(HttpClient client)
        {
            this.HttpClient = client;
        }

        private string GetLoginUrl()
        {
            return "api/login";
        }


        private string GetLoginDefinitionUrlWithUserPassword(String userName, String password)
        {
            return $"{GetLoginUrl()}/{userName + "$" + password}";
        }


        public async Task<LoginDto> GetLoginByUserPassword(String userName, String password)
        {

            return await HttpClient.GetFromJsonAsync<LoginDto>(GetLoginDefinitionUrlWithUserPassword(userName, password));
        }





    }

}
