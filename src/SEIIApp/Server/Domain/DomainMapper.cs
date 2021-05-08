using AutoMapper;
using SEIIApp.Shared.DomainTdo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEIIApp.Server.Domain {
    public class DomainMapper : Profile {

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


            // Data to dataDto for IChapterElement
            CreateMap<ChapterElementDefinition, ChapterElementDefinitionDto>();
            CreateMap<ChapterElementDefinitionDto, ChapterElementDefinition>();


            // Data to dataDto for chapterDefinition
            CreateMap<ChapterDefinition, ChapterDefinitionBaseDto>();
            CreateMap<ChapterDefinitionBaseDto, ChapterDefinition>();

            CreateMap<ChapterDefinition, ChapterDefinitionDto>()
                .ForMember(chapterDto => chapterDto.ChapterElements, opt => opt.MapFrom(obj => obj.ChapterElements.ToArray()));
            CreateMap<ChapterDefinitionDto, ChapterDefinition>()
                .ForMember(chapterObj => chapterObj.ChapterElements, opt => opt.MapFrom(dto => dto.ChapterElements.ToList()));

        }

    }
}
