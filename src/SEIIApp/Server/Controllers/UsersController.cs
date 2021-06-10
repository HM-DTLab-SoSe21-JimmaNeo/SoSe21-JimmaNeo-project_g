using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SEIIApp.Server.Domain;
using SEIIApp.Server.Services;
using SEIIApp.Shared.DomainTdo;
using System.Collections.Generic;

namespace SEIIApp.Server.Controllers
{

    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {

        private UserDefinitionService UserDefinitionService { get; set; }
        private IMapper Mapper { get; set; }
        private LoginService LoginService { get; set; }

        public UsersController(UserDefinitionService userDefinitionService, LoginService loginService, IMapper mapper)
        {
            this.UserDefinitionService = userDefinitionService;
            this.Mapper = mapper;
            this.LoginService = loginService;
        }

        /// <summary>
        /// Return the User with the given id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<UserDefinitionDto> GetUser([FromRoute] int id)
        {
            var User = UserDefinitionService.GetUserById(id);
            if (User == null) return StatusCode(StatusCodes.Status404NotFound);

            var mappedUser = Mapper.Map<UserDefinitionDto>(User);
            return Ok(mappedUser);
        }


        /// <summary>
        /// Return the User with the given id.
        /// </summary>
        /// <param name="loginDto"></param>
        /// <returns></returns>
        [Route("~/api/getuserbyauth")]
        [HttpPut()]         // IMPORTANT: we use this as a HttpGet, because we need to send a body, even though its stupid
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<UserDefinitionDto> GetUserByAuth([FromBody] LoginDto loginDto)
        {

            var authDefinition = Mapper.Map<AuthDefinition>(loginDto);

            var User = UserDefinitionService.GetUserByLogin(authDefinition);
            if (User == null) return StatusCode(StatusCodes.Status404NotFound);

            var mappedUser = Mapper.Map<UserDefinitionDto>(User);
            return Ok(mappedUser);
        }

        /// <summary>
        /// Returns all users.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<UserDefinitionBaseDto[]> GetAllUsers()
        {
            var users = UserDefinitionService.GetAllUsers();
            var mappedUsers = Mapper.Map<UserDefinitionBaseDto[]>(users);
            return Ok(mappedUsers);
        }

        /// <summary>
        /// Adds or updates a user definition.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpPut()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public ActionResult<UserDefinitionDto> AddOrUpdateUser([FromBody] UserDefinitionDto model, [FromRoute] int userId)
        {

            if (ModelState.IsValid)
            {

                var mappedModel = Mapper.Map<UserDefinition>(model);

                if (model.UserId == 0)
                { //add

                    mappedModel = UserDefinitionService.AddUser(mappedModel);

                }
                else
                { //update

                    // Checks if the User already exists, else it cant update anything
                    if (UserDefinitionService.GetUserById(mappedModel.UserId) == null) return UnprocessableEntity(ModelState);

                    mappedModel = UserDefinitionService.UpdateUser(mappedModel);
                }

                model = Mapper.Map<UserDefinitionDto>(mappedModel);
                return Ok(model);
            }
            return BadRequest(ModelState);
        }

        /// <summary>
        /// Removes a User.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteUser([FromRoute] int id)
        {
            var User = UserDefinitionService.GetUserById(id);
            if (User == null) return StatusCode(StatusCodes.Status404NotFound);

            UserDefinitionService.RemoveUser(User);
            return Ok();
        }

    }

}
