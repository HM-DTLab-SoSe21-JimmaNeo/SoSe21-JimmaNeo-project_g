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

    public class VideoElementDefinitionBackendAccessService {

        private HttpClient HttpClient { get; set; }
        public VideoElementDefinitionBackendAccessService(HttpClient client) {
            this.HttpClient = client;
        }

        private string GetVideoElementDefinitionUrl(int courseId, int TextId) {

            return $"api/coursedefinition/{courseId}/{TextId}";
        }

        private string GetVideoElementDefinitionUrlWithId(int courseId, int TextId,int id) {
            return $"{GetVideoElementDefinitionUrl(courseId, TextId)}/{id}";
        }

        /// <summary>
        /// Returns a certain Video element by id
        /// </summary>
        public async Task<VideoDefinitionDto> GetVideoElementById(int courseId, int TextId, int id) {
            return await HttpClient.GetFromJsonAsync<VideoDefinitionDto>(GetVideoElementDefinitionUrlWithId(courseId, TextId, id));
        }

        /// <summary>
        /// Returns all Video elements stored on the backend
        /// </summary>
        public async Task<VideoDefinitionDto> GetTextElementOverview(int courseId, int TextId)
        {
            return await HttpClient.GetFromJsonAsync<VideoDefinitionDto>(GetVideoElementDefinitionUrl(courseId, TextId));
        }

        /// <summary>
        /// Adds or updates a Video Element on the backend. Returns the course if successful else null
        /// </summary>
        public async Task<VideoDefinitionDto> AddOrUpdateVideoElement(int courseId, int TextId, VideoDefinitionDto dto)
        {
            var response = await HttpClient.PutAsJsonAsync(GetVideoElementDefinitionUrlWithId(courseId, TextId, dto.Id), dto);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return await response.DeserializeResponseContent<VideoDefinitionDto>();
            }
            else return null;
        }
    }
}
