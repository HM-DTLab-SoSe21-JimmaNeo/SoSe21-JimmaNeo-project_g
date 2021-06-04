﻿using SEIIApp.Shared.DomainTdo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SEIIApp.Client.Services {

    public class ChapterElementDefinitionBackendAccessService {

        private HttpClient HttpClient { get; set; }
        public ChapterElementDefinitionBackendAccessService(HttpClient client) {
            this.HttpClient = client;
        }

        private string GetChapterElementDefinitionUrl(int courseId, int chapterId) {

            return $"api/coursedefinition/{courseId}/{chapterId}";
        }

        private string GetChapterElementDefinitionUrlWithId(int courseId, int chapterId,int id) {
            return $"{GetChapterElementDefinitionUrl(courseId, chapterId)}/{id}";
        }

        /// <summary>
        /// Returns a certain chapter element by id
        /// </summary>
        public async Task<ChapterElementDefinitionDto> GetChapterElementById(int courseId, int chapterId, int id) {
            return await HttpClient.GetFromJsonAsync<ChapterElementDefinitionDto>(GetChapterElementDefinitionUrlWithId(courseId, chapterId, id));
        }

        /// <summary>
        /// Returns all chapter elements stored on the backend
        /// </summary>
        public async Task<ChapterDefinitionDto> GetChapterElementOverview(int courseId, int chapterId)
        {
            return await HttpClient.GetFromJsonAsync<ChapterDefinitionDto>(GetChapterElementDefinitionUrl(courseId, chapterId));
        }

        /// <summary>
        /// Adds or updates a chapter Element on the backend. Returns the course if successful else null
        /// </summary>
        public async Task<ChapterElementDefinitionDto> AddOrUpdateChapterElement(int courseId, int chapterId, ChapterElementDefinitionDto dto)
        {
            var response = await HttpClient.PutAsJsonAsync(GetChapterElementDefinitionUrl(courseId, chapterId), dto);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return await response.DeserializeResponseContent<ChapterElementDefinitionDto>();
            }
            else return null;
        }
    }
}