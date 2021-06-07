using AutoMapper;
using SEIIApp.Shared.DomainTdo;
using System.Linq;

namespace SEIIApp.Server.Domain
{
    public class DomainMapper : Profile
    {

        /**
         * Hello my friend, you came here because you found a mapper that maps stuff and this given mapper
         * is blocking you in your api development?
         * Fear not!
         * 
         * Pls follow the instruktions given below:
        */
        public DomainMapper()
        {

            // Mapping for COURSE_DEFINITION (plus instructions)
            // First, map data to dataDto!
            CreateMap<CourseDefinition, CourseDefinitionBaseDto>();
            CreateMap<CourseDefinitionBaseDto, CourseDefinition>();
            CreateMap<CourseDefinition, CourseDefinition>();

            //Then map the other stuff, that you want to have contained in your dto!
            CreateMap<CourseDefinition, CourseDefinitionDto>()
                .ForMember(courseDto => courseDto.Chapters, opts => opts.MapFrom(obj => obj.Chapters.ToArray()));
            CreateMap<CourseDefinitionDto, CourseDefinition>()
                .ForMember(courseObj => courseObj.Chapters, opts => opts.MapFrom(obj => obj.Chapters.ToList()));


            // Mapping for CHAPTER_DEFINITION
            CreateMap<ChapterDefinition, ChapterDefinitionBaseDto>();
            CreateMap<ChapterDefinitionBaseDto, ChapterDefinition>();
            CreateMap<ChapterDefinition, ChapterDefinition>();

            CreateMap<ChapterDefinition, ChapterDefinitionDto>()
                .ForMember(chapterDto => chapterDto.ChapterElements, opt => opt.MapFrom(obj => obj.ChapterElements.ToArray()));
            CreateMap<ChapterDefinitionDto, ChapterDefinition>()
                .ForMember(chapterObj => chapterObj.ChapterElements, opt => opt.MapFrom(dto => dto.ChapterElements.ToList()));


            // Mapping for CHAPTER_ELEMENT_DEFINITION
            CreateMap<ChapterElementDefinition, ChapterElementDefinitionDto>();
            CreateMap<ChapterElementDefinitionDto, ChapterElementDefinition>();
            CreateMap<ChapterElementDefinition, ChapterElementDefinition>();


            // Mapping for QUIZ_DEFINITION
            CreateMap<QuizDefinition, QuizDefinitionBaseDto>();
            CreateMap<QuizDefinitionBaseDto, QuizDefinition>();
            CreateMap<QuizDefinition, QuizDefinition>();

            CreateMap<QuizDefinition, QuizDefinitionDto>()
                .ForMember(quizDto => quizDto.Questions, opts => opts.MapFrom(obj => obj.Questions.ToArray()));
            CreateMap<QuizDefinitionDto, QuizDefinition>()
                .ForMember(quizObj => quizObj.Questions, opts => opts.MapFrom(dto => dto.Questions.ToList()));


            // Mapping for QUESTION_DEFINITION
            CreateMap<QuestionDefinition, QuestionDefinitionDto>()
                .ForMember(questionDto => questionDto.Answers, opt => opt.MapFrom(obj => obj.Answers.ToArray()));
            CreateMap<QuestionDefinitionDto, QuestionDefinition>()
                .ForMember(questionObj => questionObj.Answers, opt => opt.MapFrom(obj => obj.Answers.ToList()));
            CreateMap<QuestionDefinition, QuestionDefinition>();


            // Mapping for ANSWER_DEFINITION
            CreateMap<AnswerDefinition, AnswerDefinitionDto>();
            CreateMap<AnswerDefinitionDto, AnswerDefinition>();
            CreateMap<AnswerDefinition, AnswerDefinition>();


            // Mapping for EXPLANATORY_TEXT.
            CreateMap<ExplanatoryTextDefinition, ExplanatoryTextDefinitionDto>();
            CreateMap<ExplanatoryTextDefinitionDto, ExplanatoryTextDefinition>();
            CreateMap<ExplanatoryTextDefinition, ExplanatoryTextDefinition>();


            // Mapping for VIDEO_DEFINITION
            CreateMap<VideoDefinition, VideoDefinitionDto>();
            CreateMap<VideoDefinitionDto, VideoDefinition>();
            CreateMap<VideoDefinition, VideoDefinition>();


            // Mapping for PICTURE_DEFINITION
            CreateMap<PictureDefinition, PictureDefinitionDto>();
            CreateMap<PictureDefinitionDto, PictureDefinition>();
            CreateMap<PictureDefinition, PictureDefinition>();

            CreateMap<AuthDefinition, LoginDto>();
            CreateMap<LoginDto, AuthDefinition>();

            CreateMap<AuthDefinition, AuthDefinitionDto>();
            CreateMap<AuthDefinitionDto, AuthDefinition>();


            // Mapping that shouldnt exist...
            // Mapping for UltimateChapterElementDefinition
            CreateMap<UltimateChapterElementDefinition, UltimateChapterElementDefinitionDto>();
            CreateMap<UltimateChapterElementDefinitionDto, UltimateChapterElementDefinition>();

            CreateMap<UltimateChapterElementDefinition, UltimateChapterElementDefinitionDto>()
                 .ForMember(quizDto => quizDto.Questions, opts => opts.MapFrom(obj => obj.Questions.ToArray()));
            CreateMap<UltimateChapterElementDefinitionDto, UltimateChapterElementDefinition>()
                .ForMember(quizObj => quizObj.Questions, opts => opts.MapFrom(dto => dto.Questions.ToList()));
            CreateMap<UltimateChapterElementDefinition, UltimateChapterElementDefinition>();

            // Mapping for User
            CreateMap<UserDefinition, UserDefinition>();
            CreateMap<UserDefinitionDto, UserDefinition>();
            CreateMap<UserDefinitionBaseDto, UserDefinition>();
            CreateMap<UserDefinition, UserDefinitionBaseDto>();
            CreateMap<UserDefinition, UserDefinitionDto>();

            CreateMap<UserDefinition, UserDefinitionBaseDto>()
                .ForMember(user => user.AuthDefinitions, opts => opts.MapFrom(obj => obj.AuthDefinitions.ToArray()));
            CreateMap<UserDefinitionBaseDto, UserDefinition>()
                .ForMember(user => user.AuthDefinitions, opts => opts.MapFrom(obj => obj.AuthDefinitions.ToList()));

            CreateMap<UserDefinition, UserDefinitionDto>()
                .ForMember(user => user.AuthDefinitions, opts => opts.MapFrom(obj => obj.AuthDefinitions.ToArray()))
                .ForMember(user => user.AsignedCourses, opts => opts.MapFrom(obj => obj.AsignedCourses.ToArray()));

            CreateMap<UserDefinitionDto, UserDefinition>()
                .ForMember(user => user.AuthDefinitions, opts => opts.MapFrom(obj => obj.AuthDefinitions.ToList()))
                .ForMember(user => user.AsignedCourses, opts => opts.MapFrom(obj => obj.AsignedCourses.ToList()));

        }

    }
}
