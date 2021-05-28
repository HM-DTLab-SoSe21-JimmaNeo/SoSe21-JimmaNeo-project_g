using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SEIIApp.Server.DataAccess;
using SEIIApp.Server.Domain;
using System.Linq;

namespace SEIIApp.Server.Services {
    public class ChapterDefinitionService {

        private DatabaseContext DatabaseContext { get; set; }
        private IMapper Mapper { get; set; }
        public ChapterDefinitionService(DatabaseContext db, IMapper mapper) {
            this.DatabaseContext = db;
            this.Mapper = mapper;
        }

        private IQueryable<ChapterDefinition> GetQueryableForChapterDefinitions() {
            return DatabaseContext
                .ChapterDefinitions
                .Include(chapter => chapter.ChapterElements);
        }

        /// <summary>
        /// Returns all chapters. Includes also the chapters.
        /// </summary>
        public ChapterDefinition[] GetAllChapters() {
            return GetQueryableForChapterDefinitions().ToArray();
        }

        /// <summary>
        /// Returns the chapter with the given id. Includes also chapters.
        /// </summary>
        public ChapterDefinition GetChapterById(int id) {
            return GetQueryableForChapterDefinitions().Where(chapter => chapter.ChapterId == id).FirstOrDefault();
        }

        /// <summary>
        /// Adds a chapter.
        /// </summary>
        public ChapterDefinition Addchapter(ChapterDefinition chapter) {
            chapter.CreationDate = DateTime.Now;
            chapter.ChangeDate = DateTime.Now;
            DatabaseContext.ChapterDefinitions.Add(chapter);
            DatabaseContext.SaveChanges();
            return chapter;
        }

        /// <summary>
        /// Updates a chapter.
        /// </summary>
        public ChapterDefinition UpdateChapter(ChapterDefinition chapter) {

            var existingChapter = GetChapterById(chapter.ChapterId);

            chapter.ChangeDate = DateTime.Now;

            Mapper.Map(chapter, existingChapter); //we can map into the same object type

            DatabaseContext.ChapterDefinitions.Update(existingChapter);
            DatabaseContext.SaveChanges();
            return existingChapter;
        }

        /// <summary>
        /// Removes a chapter and all dependencies.
        /// </summary>
        public void RemoveChapter(ChapterDefinition chapter) {
            DatabaseContext.ChapterDefinitions.Remove(chapter);
            DatabaseContext.SaveChanges();
        }

    }
}
