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

    public class PictureElementDefinitionBackendAccessService {

        private HttpClient HttpClient { get; set; }
        public PictureElementDefinitionBackendAccessService(HttpClient client) {
            this.HttpClient = client;
        }

        private string GetPictureElementDefinitionUrl(int courseId, int TextId) {

            return $"api/coursedefinition/{courseId}/{TextId}";
        }

        private string GetPictureElementDefinitionUrlWithId(int courseId, int TextId,int id) {
            return $"{GetPictureElementDefinitionUrl(courseId, TextId)}/{id}";
        }

        /// <summary>
        /// Returns a certain Picture element by id
        /// </summary>
        public async Task<PictureDefinitionDto> GetPictureElementById(int courseId, int TextId, int id) {
            return await HttpClient.GetFromJsonAsync<PictureDefinitionDto>(GetPictureElementDefinitionUrlWithId(courseId, TextId, id));
        }

        /// <summary>
        /// Returns all Picture elements stored on the backend
        /// </summary>
        public async Task<PictureDefinitionDto> GetTextElementOverview(int courseId, int TextId)
        {
            return await HttpClient.GetFromJsonAsync<PictureDefinitionDto>(GetPictureElementDefinitionUrl(courseId, TextId));
        }

        /// <summary>
        /// Adds or updates a Picture Element on the backend. Returns the course if successful else null
        /// </summary>
        public async Task<PictureDefinitionDto> AddOrUpdatePictureElement(int courseId, int TextId, PictureDefinitionDto dto)
        {
            var response = await HttpClient.PutAsJsonAsync(GetPictureElementDefinitionUrlWithId(courseId, TextId, dto.Id), dto);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return await response.DeserializeResponseContent<PictureDefinitionDto>();
            }
            else return null;
        }
    }
}
