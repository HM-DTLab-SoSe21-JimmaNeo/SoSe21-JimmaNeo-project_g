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

    public class ChapterDefinitionBackendAccessService {

        private HttpClient HttpClient { get; set; }
        public ChapterDefinitionBackendAccessService(HttpClient client) {
            this.HttpClient = client;
        }

        private string GetChapterDefinitionUrl(int CourseId) {

            return $"api/coursedefinition/1";
        }

        private string GetChapterDefinitionUrlWithId(int ChapterId) {
            return $"{GetChapterDefinitionUrl(1)}/{ChapterId}";
        }

        /// <summary>
        /// Returns a certain chapter by id
        /// </summary>
        public async Task<ChapterDefinitionDto> GetChapterById(int ChapterId) {
            return await HttpClient.GetFromJsonAsync<ChapterDefinitionDto>(GetChapterDefinitionUrlWithId(ChapterId));
        }

        /// <summary>
        /// Returns all chapter stored on the backend
        /// </summary>
        public async Task<ChapterDefinitionDto[]> GetChapterOverview(int courseId)
        {
            return await HttpClient.GetFromJsonAsync<ChapterDefinitionDto[]>($"api/chapterdefinition?courseId={courseId}");
            //return Course.Chapters;
        }


        /// <summary>
        /// Adds or updates a chapter on the backend. Returns the chapter if successful else null
        /// </summary>
        public async Task<ChapterDefinitionDto> AddOrUpdateChapter(ChapterDefinitionDto dto)
        {
            var response = await HttpClient.PutAsJsonAsync(GetChapterDefinitionUrlWithId(dto.ChapterId), dto);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return await response.DeserializeResponseContent<ChapterDefinitionDto>();
            }
            else return null;
        }

        /// <summary>
        /// Deletes a chapter and returns true if successful
        /// </summary>
        public async Task<bool> DeleteChapter(int ChapterId)
        {
            var response = await HttpClient.DeleteAsync(GetChapterDefinitionUrlWithId(ChapterId));
            return response.StatusCode == System.Net.HttpStatusCode.OK;
        }

    }
}
