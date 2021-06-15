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


        private string GetLoginDefinitionUrlWithId(int id)
        {
            return $"{GetLoginUrl()}/{id}";
        }


        public async Task<LoginDto> GetLoginById(int id)
        {

            return await HttpClient.GetFromJsonAsync<LoginDto>(GetLoginDefinitionUrlWithId(id));
        }

        public async Task<LoginDto> UpdateUserPassword(LoginDto loginDto)
        {
            var response = await HttpClient.PutAsJsonAsync(GetLoginUrl(), loginDto);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return await response.DeserializeResponseContent<LoginDto>();
            }
            else return null;
        }

    }

}
