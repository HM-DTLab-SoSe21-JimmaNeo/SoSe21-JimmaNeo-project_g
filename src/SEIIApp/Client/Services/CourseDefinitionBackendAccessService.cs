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

    public class CourseDefinitionBackendAccessService {

        private HttpClient HttpClient { get; set; }
        public CourseDefinitionBackendAccessService(HttpClient client) {
            this.HttpClient = client;
        }

        private string GetCourseDefinitionUrl() {
            return "api/coursedefinition";
        }

        private string GetCourseDefinitionUrlWithId(int id) {
            return $"{GetCourseDefinitionUrl()}/{id}";
        }

        /// <summary>
        /// Returns a certain course by id
        /// </summary>
        public async Task<CourseDefinitionDto> GetCourseById(int id) {
            return await HttpClient.GetFromJsonAsync<CourseDefinitionDto>(GetCourseDefinitionUrlWithId(id));
        }

        /// <summary>
        /// Returns all courses stored on the backend
        /// </summary>
        public async Task<CourseDefinitionBaseDto[]> GetCourseOverview() {
            return await HttpClient.GetFromJsonAsync<CourseDefinitionBaseDto[]>(GetCourseDefinitionUrl());
        }

        /// <summary>
        /// Adds or updates a course on the backend. Returns the course if successful else null
        /// </summary>
        public async Task<CourseDefinitionDto> AddOrUpdateCourse(CourseDefinitionDto dto) {
            var response = await HttpClient.PutAsJsonAsync(GetCourseDefinitionUrl(), dto);
            if (response.StatusCode == System.Net.HttpStatusCode.OK) {
                return await response.DeserializeResponseContent<CourseDefinitionDto>();
            }
            else return null;
        }

        /// <summary>
        /// Deletes a course and returns true if successful
        /// </summary>
        public async Task<bool> DeleteCourse(int courseId) {
            var response = await HttpClient.DeleteAsync(GetCourseDefinitionUrlWithId(courseId));
            return response.StatusCode == System.Net.HttpStatusCode.OK;
        }

    }
}
