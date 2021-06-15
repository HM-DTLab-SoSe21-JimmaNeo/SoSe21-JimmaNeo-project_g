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
        
        private string GetCourseUsersUrlWithId(int id) {
            return $"{GetCourseDefinitionUrl()}/{id}/users";
        }
        
        private string GetCourseUsersEditUrlWithId(int courseId, int userId) {
            return $"{GetCourseDefinitionUrl()}/{courseId}/users/edit/{userId}";
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
        
        
        /// <summary>
        /// Leaves a course and returns true if successfull
        /// </summary>
        public async Task<bool> LeaveCourse(int courseId, int userId) {
            var response = await HttpClient.DeleteAsync(GetCourseUsersEditUrlWithId(courseId, userId));
            return response.StatusCode == System.Net.HttpStatusCode.OK;
        }

        public async Task<bool> AddUserToCourse(int courseId, int userId)
        {
            var response = await HttpClient.PutAsJsonAsync(GetCourseUsersEditUrlWithId(courseId, userId), new UserInCourseDto()); // We dont read the body
            return response.StatusCode == System.Net.HttpStatusCode.OK;
        }

        /// <summary>
        /// Gets user form a specific course.
        /// </summary>
        /// <param name="courseId"></param>
        /// <returns></returns>
        public async Task<UserInCourseDto> GetUsersForCourse(int courseId)
        {
            var response = await HttpClient.GetAsync(GetCourseUsersUrlWithId(courseId));

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return await response.DeserializeResponseContent<UserInCourseDto>();
            }
            return null;
        }
    }
}
