﻿using AutoMapper;
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

            // Data to dataDto for ChapterElementDefinition
            CreateMap<ChapterElementDefinition, ChapterElementDefinitionDto>();
            CreateMap<ChapterElementDefinitionDto, ChapterElementDefinition>();

            // Data to dataDto for chapterDefinition
            CreateMap<ChapterDefinition, ChapterDefinitionBaseDto>();
            CreateMap<ChapterDefinitionBaseDto, ChapterDefinition>();

            CreateMap<ChapterDefinition, ChapterDefinitionDto>()
                .ForMember(chapterDto => chapterDto.ChapterElements, opt => opt.MapFrom(obj => obj.ChapterElements.ToArray()));
            CreateMap<ChapterDefinitionDto, ChapterDefinition>()
                .ForMember(chapterObj => chapterObj.ChapterElements, opt => opt.MapFrom(dto => dto.ChapterElements.ToList()));

            CreateMap<QuizDefinition, QuizDefinitionDto>()
                .ForMember(quizDto => quizDto.Questions, opts => opts.MapFrom(obj => obj.Questions.ToArray()));
            CreateMap<QuizDefinitionDto, QuizDefinition>()
                .ForMember(quizObj => quizObj.Questions, opts => opts.MapFrom(dto => dto.Questions.ToList()));

            // Mapping for EXPLANATORY_TEXT.
            CreateMap<ExplanatoryTextDefinition, ExplanatoryTextDefinitionDto>();
            CreateMap<ExplanatoryTextDefinitionDto, ExplanatoryTextDefinition>();

            CreateMap<QuizDefinition, QuizDefinitionBaseDto>();
            CreateMap<QuizDefinitionBaseDto, QuizDefinition>();

            CreateMap<QuestionDefinition, QuestionDefinitionDto>()
                .ForMember(questionDto => questionDto.Answers, opt => opt.MapFrom(obj => obj.Answers.ToArray()));
            CreateMap<QuestionDefinitionDto, QuestionDefinition>()
                .ForMember(questionObj => questionObj.Answers, opt => opt.MapFrom(obj => obj.Answers.ToList()));

            CreateMap<AnswerDefinition, AnswerDefinitionDto>();
            CreateMap<AnswerDefinitionDto, AnswerDefinition>();

            // First, map data to dataDto!
            CreateMap<CourseDefinition, CourseDefinitionBaseDto>();
            CreateMap<CourseDefinitionBaseDto, CourseDefinition>();

            //TODO: remove Questions!

            //Then map the other stuff, that you want to have contained in your dto!
            CreateMap<CourseDefinition, CourseDefinitionDto>()
                .ForMember(courseDefinition => courseDefinition.Questions, opts => opts.MapFrom(obj => obj.Chapter.ToArray()));
            CreateMap<CourseDefinitionDto, CourseDefinition>()
                .ForMember(courseDefinition => courseDefinition.Chapter, opts => opts.MapFrom(obj => obj.Questions.ToArray()));
        }

    }
}
