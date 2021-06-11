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

    public class TextElementDefinitionBackendAccessService {

        private HttpClient HttpClient { get; set; }
        public TextElementDefinitionBackendAccessService(HttpClient client) {
            this.HttpClient = client;
        }

        private string GetTextElementDefinitionUrl(int courseId, int TextId) {

            return $"api/coursedefinition/{courseId}/{TextId}";
        }

        private string GetTextElementDefinitionUrlWithId(int courseId, int TextId,int id) {
            return $"{GetTextElementDefinitionUrl(courseId, TextId)}/{id}";
        }

        /// <summary>
        /// Returns a certain Text element by id
        /// </summary>
        public async Task<ExplanatoryTextDefinitionDto> GetTextElementById(int courseId, int TextId, int id) {
            return await HttpClient.GetFromJsonAsync<ExplanatoryTextDefinitionDto>(GetTextElementDefinitionUrlWithId(courseId, TextId, id));
        }

        /// <summary>
        /// Returns all Text elements stored on the backend
        /// </summary>
        public async Task<ExplanatoryTextDefinitionDto> GetTextElementOverview(int courseId, int TextId)
        {
            return await HttpClient.GetFromJsonAsync<ExplanatoryTextDefinitionDto>(GetTextElementDefinitionUrl(courseId, TextId));
        }

        /// <summary>
        /// Adds or updates a Text Element on the backend. Returns the course if successful else null
        /// </summary>
        public async Task<ExplanatoryTextDefinitionDto> AddOrUpdateTextElement(int courseId, int TextId, ExplanatoryTextDefinitionDto dto)
        {
            var response = await HttpClient.PutAsJsonAsync(GetTextElementDefinitionUrlWithId(courseId, TextId, dto.Id), dto);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return await response.DeserializeResponseContent<ExplanatoryTextDefinitionDto>();
            }
            else return null;
        }
    }
}
