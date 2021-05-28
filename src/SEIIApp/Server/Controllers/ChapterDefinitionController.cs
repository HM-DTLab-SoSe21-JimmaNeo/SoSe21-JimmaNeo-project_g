using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SEIIApp.Server.Domain;
using SEIIApp.Server.Services;
using SEIIApp.Shared.DomainTdo;

namespace SEIIApp.Server.Controllers {

    [ApiController]
    [Route("api/chapterdefinition")]
    public class ChapterDefinitionController : ControllerBase {
       
        private ChapterDefinitionService ChapterDefinitionService { get; set; }

        private CourseDefinitionService courseDefinitionService { get; set; }

        private IMapper Mapper { get; set; }

        public ChapterDefinitionController(ChapterDefinitionService ChapterDefinitionService, CourseDefinitionService courseDefinitionService, IMapper mapper) {
            this.ChapterDefinitionService = ChapterDefinitionService;
            this.courseDefinitionService = courseDefinitionService;
            this.Mapper = mapper;
        }

        /// <summary>
        /// Return the chapter with the given id.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="courseId"></param>
        /// <returns></returns>
        [Route("~/api/coursedefinition/{courseId}/{id}")]
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Shared.DomainTdo.ChapterDefinitionDto> GetChapter([FromRoute] int id, [FromRoute] int courseId) {
            var chapter = ChapterDefinitionService.GetChapterById(id);
            if (chapter == null) return StatusCode(StatusCodes.Status404NotFound);

            var mappedChapter = Mapper.Map<ChapterDefinitionDto>(chapter);
            return Ok(mappedChapter);
        }

        /// <summary>
        /// Returns all chapters names and ids.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<ChapterDefinitionBaseDto[]> GetAllChapters() {
            var chapters = ChapterDefinitionService.GetAllChapters();
            var mappedChapters = Mapper.Map<ChapterDefinitionDto[]>(chapters);
            return Ok(mappedChapters);
        }

        /// <summary>
        /// Adds or updates a chapter definition.
        /// For some reason this returns a 404 when called over the /api/chapterdefinition...
        /// this might not be the expected result, but a wanted one.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="courseId"></param>
        /// <returns></returns>
        [Route("~/api/coursedefinition/{courseId}")]
        [HttpPut()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public ActionResult<ChapterDefinitionDto> AddOrUpdateChapter([FromBody] ChapterDefinitionDto model, [FromRoute] int courseId) {

            if (courseId == 0) return Forbid();

            if (ModelState.IsValid) {

                var mappedModel = Mapper.Map<ChapterDefinition>(model);

                if(model.ChapterId == 0) { //add
                    mappedModel = ChapterDefinitionService.Addchapter(mappedModel);
                    CourseDefinition course = courseDefinitionService.GetCourseById(courseId);
                    course.Chapters.Add(mappedModel);
                    courseDefinitionService.UpdateCourse(course);
                }
                else { //update

                    // Checks if the chapter already exists, else it cant update anything
                    if (ChapterDefinitionService.GetChapterById(mappedModel.ChapterId) == null) return UnprocessableEntity(ModelState);

                    mappedModel = ChapterDefinitionService.UpdateChapter(mappedModel);
                }

                model = Mapper.Map<ChapterDefinitionDto>(mappedModel);
                return Ok(model);
            }
            return BadRequest(ModelState);
        }

        /// <summary>
        /// Removes a chapter.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteChapter([FromRoute] int id) {
            var chapter = ChapterDefinitionService.GetChapterById(id);
            if (chapter == null) return StatusCode(StatusCodes.Status404NotFound);

            ChapterDefinitionService.RemoveChapter(chapter);
            return Ok();
        }





    }
}
