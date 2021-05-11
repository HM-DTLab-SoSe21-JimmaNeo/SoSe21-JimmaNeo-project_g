using AutoMapper;
using SEIIApp.Shared.DomainTdo;
using System.Linq;

namespace SEIIApp.Server.Domain {
    public class DomainMapper : Profile {

        /**
         * Hello my friend, you came here because you found a mapper that maps stuff and this given mapper
         * is blocking you in your api development?
         * Fear not!
         * 
         * Pls follow the instruktions given below:
        */
        public DomainMapper() {
                                             
            CreateMap<QuizDefinition, QuizDefinitionDto>()
                .ForMember(quizDto => quizDto.Questions, opts => opts.MapFrom(obj => obj.Questions.ToArray()));
            CreateMap<QuizDefinitionDto, QuizDefinition>()
                .ForMember(quizObj => quizObj.Questions, opts => opts.MapFrom(dto => dto.Questions.ToList()));

            CreateMap<QuizDefinition, QuizDefinitionBaseDto>();
            CreateMap<QuizDefinitionBaseDto, QuizDefinition>();

            CreateMap<QuestionDefinition, QuestionDefinitionDto>()
                .ForMember(questionDto => questionDto.Answers, opt => opt.MapFrom(obj => obj.Answers.ToArray()));
            CreateMap<QuestionDefinitionDto, QuestionDefinition>()
                .ForMember(questionObj => questionObj.Answers, opt => opt.MapFrom(obj => obj.Answers.ToList()));

            CreateMap<AnswerDefinition, AnswerDefinitionDto>();
            CreateMap<AnswerDefinitionDto, AnswerDefinition>();


            // Mapping for CHAPTERS.
            CreateMap<ChapterDefinition, ChapterDefinitionBaseDto>();
            CreateMap<ChapterDefinitionBaseDto, ChapterDefinition>();

            CreateMap<ChapterDefinition, ChapterDefinitionDto>()
                .ForMember(chapterDto => chapterDto.ChapterElements, opt => opt.MapFrom(obj => obj.ChapterElements.ToArray()));
            CreateMap<ChapterDefinitionDto, ChapterDefinition>()
                .ForMember(chapterObj => chapterObj.ChapterElements, opt => opt.MapFrom(dto => dto.ChapterElements.ToList()));


            // Mapping for CHAPTER_ELEMENTS (base class for all the different chapter elements).
            CreateMap<ChapterElementDefinition, ChapterElementDefinitionDto>();
            CreateMap<ChapterElementDefinitionDto, ChapterElementDefinition>();


            // Mapping for COURSES (and example / instructions).
            // First, map data to dataDto!
            CreateMap<CourseDefinition, CourseDefinitionBaseDto>();
            CreateMap<CourseDefinitionBaseDto, CourseDefinition>();

            //Then map the other stuff, that you want to have contained in your dto!
            CreateMap<CourseDefinition, CourseDefinitionDto>()
                .ForMember(courseDto => courseDto.Chapters, opts => opts.MapFrom(obj => obj.Chapters.ToArray()));
            CreateMap<CourseDefinitionDto, CourseDefinition>()
                .ForMember(courseObj => courseObj.Chapters, opts => opts.MapFrom(obj => obj.Chapters.ToList()));
        }

    }
}
