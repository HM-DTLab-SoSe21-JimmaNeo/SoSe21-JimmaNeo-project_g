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

    public class UserDefinitionBackendService {

        private HttpClient HttpClient { get; set; }
        public UserDefinitionBackendService(HttpClient client) {
            this.HttpClient = client;
        }

        private string GetUserDefinitionUrl() {
            return "api/users";
        }
        private string GetUserDefinitionUrl(int id)
        {
            return $"{GetUserDefinitionUrl()}/{id}";
        }
        
        private string GetUserDefinitionUrl(string id)
        {
            return $"{GetUserDefinitionUrl()}/{id}";
        }

        private string GetUserByAuthUrl()
        {
            return "api/getuserbyauth";
        }

        /// <summary>
        /// Returns a certain user by id
        /// </summary>
        public async Task<UserDefinitionDto> GetUserById(int id)
        {
            return await HttpClient.GetFromJsonAsync<UserDefinitionDto>(GetUserDefinitionUrl(id));
        }
        
        /// <summary>
        /// Returns a certain user by id
        /// </summary>
        public async Task<UserDefinitionDto> GetUserById(string id)
        {
            return await HttpClient.GetFromJsonAsync<UserDefinitionDto>(GetUserDefinitionUrl(id));
        }

        /// <summary>
        /// Returns a certain user by auth
        /// </summary>
        public async Task<UserDefinitionDto> GetUserByAuth(AuthDefinitionDto dto)
        {
            var response = await HttpClient.PutAsJsonAsync(GetUserByAuthUrl(), dto);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return await response.DeserializeResponseContent<UserDefinitionDto>();
            }
            else return null;
        }

        /// <summary>
        /// Returns all user stored on the backend
        /// </summary>
        public async Task<UserDefinitionBaseDto[]> GetUserOverview() {
            return await HttpClient.GetFromJsonAsync<UserDefinitionBaseDto[]>(GetUserDefinitionUrl());
        }

        /// <summary>
        /// Adds or updates a user on the backend. Returns the user if successful else null
        /// </summary>
        public async Task<UserDefinitionDto> AddOrUpdateUser(UserDefinitionDto dto) {
            var response = await HttpClient.PutAsJsonAsync(GetUserDefinitionUrl(), dto);
            if (response.StatusCode == System.Net.HttpStatusCode.OK) {
                return await response.DeserializeResponseContent<UserDefinitionDto>();
            }
            else return null;
        }

        /// <summary>
        /// Deletes a User and returns true if successful
        /// </summary>
        public async Task<bool> DeleteUser(int UserId) {
            var response = await HttpClient.DeleteAsync(GetUserDefinitionUrl(UserId));
            return response.StatusCode == System.Net.HttpStatusCode.OK;
        }

    }
}
