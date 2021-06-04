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

    public class QuizElementDefinitionBackendAccessService {

        private HttpClient HttpClient { get; set; }
        public QuizElementDefinitionBackendAccessService(HttpClient client) {
            this.HttpClient = client;
        }

        private string GetQuizElementDefinitionUrl(int courseId, int TextId) {

            return $"api/coursedefinition/{courseId}/{TextId}";
        }

        private string GetQuizElementDefinitionUrlWithId(int courseId, int TextId,int id) {
            return $"{GetQuizElementDefinitionUrl(courseId, TextId)}/{id}";
        }

        /// <summary>
        /// Returns a certain Quiz element by id
        /// </summary>
        public async Task<QuizDefinitionDto> GetQuizElementById(int courseId, int TextId, int id) {
            return await HttpClient.GetFromJsonAsync<QuizDefinitionDto>(GetQuizElementDefinitionUrlWithId(courseId, TextId, id));
        }

        /// <summary>
        /// Returns all Quiz elements stored on the backend
        /// </summary>
        public async Task<QuizDefinitionDto> GetTextElementOverview(int courseId, int TextId)
        {
            return await HttpClient.GetFromJsonAsync<QuizDefinitionDto>(GetQuizElementDefinitionUrl(courseId, TextId));
        }

        /// <summary>
        /// Adds or updates a Quiz Element on the backend. Returns the course if successful else null
        /// </summary>
        public async Task<QuizDefinitionDto> AddOrUpdateQuizElement(int courseId, int TextId, QuizDefinitionDto dto)
        {
            var response = await HttpClient.PutAsJsonAsync(GetQuizElementDefinitionUrl(courseId, TextId), dto);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return await response.DeserializeResponseContent<QuizDefinitionDto>();
            }
            else return null;
        }
    }
}
