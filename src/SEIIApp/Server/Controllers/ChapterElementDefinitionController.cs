using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SEIIApp.Server.Domain;
using SEIIApp.Server.Services;
using SEIIApp.Shared.DomainTdo;
using System.Reflection.Metadata;

namespace SEIIApp.Server.Controllers
{

    [ApiController]
    [Route("api/chapterelementdefinition")]
    public class ChapterElementDefinitionController : ControllerBase
    {

        private ChapterElementDefinitionService ChapterElementDefinitionService { get; set; }

        private ChapterDefinitionService ChapterDefinitionService { get; set; }

        private IMapper Mapper { get; set; }

        public ChapterElementDefinitionController(ChapterElementDefinitionService chapterElementDefinitionService,
            ChapterDefinitionService chapterDefinitionService, IMapper mapper)
        {
            this.ChapterElementDefinitionService = chapterElementDefinitionService;
            this.ChapterDefinitionService = chapterDefinitionService;
            this.Mapper = mapper;
        }

        /// <summary>
        /// Return the chapter element with the given id.
        /// </summary>
        /// <param name="courseId"></param>
        /// <param name="chapterId"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("~/api/coursedefinition/{courseId}/{chapterId}/{id}")]
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Shared.DomainTdo.ChapterDefinitionDto> GetChapter([FromRoute] int courseId,
            [FromRoute] int chapterId, [FromRoute] int id)
        {
            var element = ChapterElementDefinitionService.GetChapterElementById(id);

            if (element == null) return StatusCode(StatusCodes.Status404NotFound);

            switch (element.ChapterElementType)
            {
                case ChapterElementType.Quiz:
                    return Ok(Mapper.Map<QuizDefinitionDto>(element));

                case ChapterElementType.Text:
                    return Ok(Mapper.Map<ExplanatoryTextDefinitionDto>(element));

                case ChapterElementType.Picture:
                    return Ok(Mapper.Map<PictureDefinitionDto>(element));

                case ChapterElementType.Video:
                    return Ok(Mapper.Map<VideoDefinitionDto>(element));

                default:
                    return StatusCode(StatusCodes.Status400BadRequest); // Should not happen.
            }

        }

        /// <summary>
        /// Returns all chapter elements.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<ChapterElementDefinitionDto[]> GetAllChapterElements()
        {
            var elements = ChapterElementDefinitionService.GetAllChapterElements();

            var mappedElements = new ChapterElementDefinitionDto[elements.Length];

            for (int i = 0; i < elements.Length; i++)
                {
                    switch (elements[i].ChapterElementType)
                    {
                        case ChapterElementType.Quiz:
                            mappedElements[i] = Mapper.Map<QuizDefinitionBaseDto>(elements[i]);
                            break;

                        case ChapterElementType.Text:
                            mappedElements[i] = Mapper.Map<ExplanatoryTextDefinitionDto>(elements[i]);
                            break;

                        case ChapterElementType.Picture:
                            mappedElements[i] = Mapper.Map<PictureDefinitionDto>(elements[i]);
                            break;

                        case ChapterElementType.Video:
                            mappedElements[i] = Mapper.Map<VideoDefinitionDto>(elements[i]);
                            break;
                    }
                }

            return Ok(mappedElements);
        }

        /// <summary>
        /// Adds or updates a chapter element.
        /// </summary>
        /// <param name="courseId"></param>
        /// <param name="chapterId"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("~/api/coursedefinition/{courseId}/{chapterId}/{id}")]
        [HttpPut()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public ActionResult<ChapterDefinitionDto> AddOrUpdateChapterElement([FromRoute] int courseId,
            [FromRoute] int chapterId, [FromBody] UltimateChapterElementDefinitionDto model)
        {

            if (courseId == 0 || chapterId == 0) return Forbid();

            if (ModelState.IsValid)
            {

                var temporaryModel = Mapper.Map<UltimateChapterElementDefinition>(model);

                ChapterElementDefinition mappedModel; 

                switch (temporaryModel.ChapterElementType)
                {
                    case ChapterElementType.Quiz:
                        QuizDefinition quizDefinition = new QuizDefinition();
                        quizDefinition.Id = temporaryModel.Id;
                        quizDefinition.ChapterElementType = ChapterElementType.Quiz;
                        quizDefinition.Questions = temporaryModel.Questions;
                        quizDefinition.QuizName = temporaryModel.QuizName;
                        mappedModel = quizDefinition;
                        break;
                    case ChapterElementType.Text:
                        ExplanatoryTextDefinition explanatoryTextDefinition = new ExplanatoryTextDefinition();
                        explanatoryTextDefinition.Id = temporaryModel.Id;
                        explanatoryTextDefinition.ChapterElementType = ChapterElementType.Text;
                        explanatoryTextDefinition.ContentText = temporaryModel.ContentText;
                        explanatoryTextDefinition.Title = temporaryModel.Title;
                        mappedModel = explanatoryTextDefinition;
                        break;
                    case ChapterElementType.Picture:
                        PictureDefinition pictureDefinition = new PictureDefinition();
                        pictureDefinition.Id = temporaryModel.Id;
                        pictureDefinition.ChapterElementType = ChapterElementType.Picture;
                        pictureDefinition.Description = temporaryModel.Description;
                        pictureDefinition.Picture = temporaryModel.Picture;
                        mappedModel = pictureDefinition;
                        break;
                    case ChapterElementType.Video:
                        VideoDefinition videoDefinition = new VideoDefinition();
                        videoDefinition.Id = temporaryModel.Id;
                        videoDefinition.Description = temporaryModel.Description;
                        videoDefinition.VideoUri = temporaryModel.VideoUri;
                        mappedModel = videoDefinition;
                        break;
                    default:
                        mappedModel = null;
                        break;

                }

                if (model.Id == 0)
                { //add
                    mappedModel = ChapterElementDefinitionService.AddChapterElement(mappedModel);
                    ChapterDefinition chapter = ChapterDefinitionService.GetChapterById(chapterId);
                    chapter.ChapterElements.Add(mappedModel);
                    ChapterDefinitionService.UpdateChapter(chapter);
                }
                else
                { //update

                    // Checks if the element already exists, else it cant update anything
                    if (ChapterElementDefinitionService.GetChapterElementById(mappedModel.Id) == null) return UnprocessableEntity(ModelState);

                    mappedModel = ChapterElementDefinitionService.UpdateChapterElement(mappedModel);
                }

                return Ok(mappedModel);
            }
            return BadRequest(ModelState);
        }

        /// <summary>
        /// Removes a chapter element.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteChapter([FromRoute] int id)
        {
            var element = ChapterElementDefinitionService.GetChapterElementById(id);

            if (element == null) return StatusCode(StatusCodes.Status404NotFound);

            ChapterElementDefinitionService.RemoveChapterElement(element);
            return Ok();
        }

    }
}
