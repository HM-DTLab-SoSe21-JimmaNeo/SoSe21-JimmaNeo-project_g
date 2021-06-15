using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SEIIApp.Server.Domain;
using SEIIApp.Server.Services;
using SEIIApp.Shared.DomainTdo;

namespace SEIIApp.Server.Controllers
{

    [ApiController]
    [Route("api/login")]
    public class LoginController : ControllerBase
    {

        private LoginService LoginService { get; set; }
        private IMapper Mapper { get; set; }

        public LoginController(LoginService loginService, IMapper mapper)
        {
            this.LoginService = loginService;
            this.Mapper = mapper;
        }

        /// <summary>
        /// Return the login with the given id.
        /// </summary>
        /// <param userName="username"></param>
        /// <returns></returns>
        [HttpGet("{username}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Shared.DomainTdo.LoginDto> GetRole([FromRoute] string username)
        {

            var auth = DataAccess.TestDataGenerator.CreateAuthentifizierung("dummy", "dummy", RoleType.Student);

            if (username.Contains("$"))
            {
                string user = username.Split("$")[0];
                string password = username.Split("$")[1];
                auth = LoginService.GetAuth(user, password);
            }

            else
            {
                int id = int.Parse(username);
                auth = LoginService.GetAuth(id);
            }

            var successLogin = Mapper.Map<LoginDto>(auth);
            return Ok(successLogin);
        }


        /// <summary>
        /// Adds or updates a login definition.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<LoginDto> AddAuth([FromBody] LoginDto model)
        {
            if (ModelState.IsValid)
            {

                var mappedModel = Mapper.Map<AuthDefinition>(model);

                if (model.Id == 0)
                { //add
                    mappedModel = LoginService.AddAuth(mappedModel);
                }
                else
                {
                    mappedModel = LoginService.UpdateAuth(mappedModel);
                }

                model = Mapper.Map<LoginDto>(mappedModel);
                return Ok(model);
            }
            return BadRequest(ModelState);
        }



        //[HttpGet("{id}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public ActionResult<Shared.DomainTdo.LoginDto> GetUser([FromRoute] int id)
        //{
        //    var auth = LoginService.GetAuth(id);

        //    if (auth == null)
        //    {
        //        auth = DataAccess.TestDataGenerator.CreateAuthentifizierung("dummy", "dummy", "dummy");
        //    }

        //    var successLogin = Mapper.Map<LoginDto>(auth);
        //    return Ok(successLogin);
        //}






    }

}
