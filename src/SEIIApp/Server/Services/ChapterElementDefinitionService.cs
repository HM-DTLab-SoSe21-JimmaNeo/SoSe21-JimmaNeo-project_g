using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SEIIApp.Server.DataAccess;
using SEIIApp.Server.Domain;
using System.Linq;
using SEIIApp.Shared.DomainTdo;

namespace SEIIApp.Server.Services
{
    public class ChapterElementDefinitionService
    {

        private DatabaseContext DatabaseContext { get; set; }
        private IMapper Mapper { get; set; }
        public ChapterElementDefinitionService(DatabaseContext db, IMapper mapper)
        {
            this.DatabaseContext = db;
            this.Mapper = mapper;
        }

        private IQueryable<ChapterElementDefinition> GetQueryableForChapterElementDefinitions()
        {
            return DatabaseContext.ChapterElementDefinitions;
        }

        /// <summary>
        /// Returns all chapter elements as an array.
        /// </summary>
        public ChapterElementDefinition[] GetAllChapterElements()
        {
            return GetQueryableForChapterElementDefinitions().ToArray();
        }

        /// <summary>
        /// Returns the chapter element with the given id.
        /// </summary>
        public ChapterElementDefinition GetChapterElementById(int id)
        {
            return GetQueryableForChapterElementDefinitions()
                .Where(element => element.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// Adds a chapter element and returns it.
        /// </summary>
        public ChapterElementDefinition AddChapterElement(ChapterElementDefinition element)
        {
            switch(element.GetChapterElementType())
            {
                case ChapterElementType.Quiz:
                    // TODO Quiz needs to be adapted to our domain structure. (JIRA ticket)
                    break;
                case ChapterElementType.Text:
                    DatabaseContext.ExplanatoryTextDefinitions.Add((ExplanatoryTextDefinition)element);
                    break;
                case ChapterElementType.Picture:
                    DatabaseContext.PictureDefinitions.Add((PictureDefinition)element);
                    break;
                case ChapterElementType.Video:
                    DatabaseContext.VideoDefinitions.Add((VideoDefinition)element);
                    break;
            }
            
            DatabaseContext.SaveChanges();
            return element;
        }

        /// <summary>
        /// Updates a chapter element and returns it.
        /// </summary>
        public ChapterElementDefinition UpdateChapterElement(ChapterElementDefinition element)
        {

            var existingChapterElement = GetChapterElementById(element.Id);

            Mapper.Map(element, existingChapterElement); //we can map into the same object type

            DatabaseContext.ChapterElementDefinitions.Update(existingChapterElement);
            DatabaseContext.SaveChanges();
            return existingChapterElement;
        }

        /// <summary>
        /// Removes a chapter element and all dependencies.
        /// </summary>
        public void RemoveChapterElement(ChapterElementDefinition element)
        {
            DatabaseContext.ChapterElementDefinitions.Remove(element);
            DatabaseContext.SaveChanges();
        }

    }
}
