using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SEIIApp.Server.Domain;
using SEIIApp.Server.Services;
using SEIIApp.Shared.DomainTdo;

namespace SEIIApp.Server.Controllers
{

    [ApiController]
    [Route("api/coursedefinition")]
    public class CourseDefinitionController : ControllerBase
    {

        private CourseDefinitionService CourseDefinitionService { get; set; }

        private UserDefinitionService UserDefinitionService { get; set; }
        private IMapper Mapper { get; set; }

        public CourseDefinitionController(CourseDefinitionService courseDefinitionService, IMapper mapper, UserDefinitionService userDefinitionService)
        {
            this.UserDefinitionService = userDefinitionService;
            this.CourseDefinitionService = courseDefinitionService;
            this.Mapper = mapper;
        }

        /// <summary>
        /// Return the course with the given id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Shared.DomainTdo.CourseDefinitionDto> GetCourse([FromRoute] int id)
        {
            var course = CourseDefinitionService.GetCourseById(id);
            if (course == null) return StatusCode(StatusCodes.Status404NotFound);

            var mappedCourse = Mapper.Map<CourseDefinitionDto>(course);
            return Ok(mappedCourse);
        }

        /// <summary>
        /// Returns all courses names and ids.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<CourseDefinitionBaseDto[]> GetAllCourses()
        {
            var courses = CourseDefinitionService.GetAllCourses();
            var mappedCourses = Mapper.Map<CourseDefinitionDto[]>(courses);
            return Ok(mappedCourses);
        }

        /// <summary>
        /// Adds or updates a course definition.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public ActionResult<CourseDefinitionDto> AddOrUpdateCourse([FromBody] CourseDefinitionDto model)
        {
            if (ModelState.IsValid)
            {

                var mappedModel = Mapper.Map<CourseDefinition>(model);

                if (model.CourseId == 0)
                { //add
                    mappedModel = CourseDefinitionService.AddCourse(mappedModel);
                }
                else
                { //update

                    // Checks if the course already exists, else it cant update anything.
                    if (CourseDefinitionService.GetCourseById(mappedModel.CourseId) == null) return UnprocessableEntity(ModelState);

                    mappedModel = CourseDefinitionService.UpdateCourse(mappedModel);
                }

                model = Mapper.Map<CourseDefinitionDto>(mappedModel);
                return Ok(model);
            }
            return BadRequest(ModelState);
        }

        /// <summary>
        /// Removes a course.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteCourse([FromRoute] int id)
        {
            var course = CourseDefinitionService.GetCourseById(id);

            if (course == null) return StatusCode(StatusCodes.Status404NotFound);

            CourseDefinitionService.RemoveCourse(course);
            return Ok();
        }

        /// <summary>
        /// Gets all users to a course.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}/users")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult GetUsersInCourse([FromRoute] int id)
        {
            var users = UserDefinitionService.GetUsersForCourse(id);
            var mappedUsers = Mapper.Map<UserDefinitionBaseDto[]>(users);

            UserInCourseDto courseUserDto = new();
            courseUserDto.Users = mappedUsers;
            courseUserDto.CourseId = id;

            return Ok(courseUserDto);
        }


        /// <summary>
        /// Adds a user to a course.
        /// </summary>
        /// <param name="courseId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpPut("{courseId}/users/edit/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult AddUserToCourse([FromRoute] int courseId, [FromRoute] int userId)
        {
            var users = UserDefinitionService.AddUserToCourse(courseId, userId);
            var mappedUsers = Mapper.Map<UserDefinitionBaseDto[]>(users);

            UserInCourseDto courseUserDto = new();
            courseUserDto.Users= mappedUsers;
            courseUserDto.CourseId = courseId;

            return Ok(courseUserDto);

        }


        /// <summary>
        /// Removes a user from a course.
        /// </summary>
        /// <param name="courseId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpDelete("{courseId}/users/edit/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult RemoveUserFromCourse([FromRoute] int courseId, [FromRoute] int userId)
        {
            var users = UserDefinitionService.RemoveUserFromCourse(courseId, userId);
            var mappedUsers = Mapper.Map<UserDefinitionBaseDto[]>(users);

            UserInCourseDto courseUserDto = new();
            courseUserDto.Users = mappedUsers;
            courseUserDto.CourseId = courseId;

            return Ok(courseUserDto);

        }
    }

}
