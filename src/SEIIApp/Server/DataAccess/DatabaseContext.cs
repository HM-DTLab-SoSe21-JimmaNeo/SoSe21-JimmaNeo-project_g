using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEIIApp.Server.DataAccess
{
    public class DatabaseContext : DbContext
    {

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Hier werden Einstellungen/Optionen zur Datenbank und zu den Tabellen erfasst
            //die sich nicht durch Annotationen abbilden lassen (z.B. multiple primäre Schlüssel).
        }

        //Eine Tabelle kann der Datenbank hinzugefügt werden, indem 
        //eine Eigenschaft (Property) erstellt wird, die als generisches Argument die
        //abzubildende Domänen-Klasse hat, z.B.
        //public DbSet<Customer> Customers { get; set; }
        //Diese Zeile genügt bereits, um eine Tabelle "Customers", die Objekte der Domänen-Klasse
        //Customer aufnehmen kann, zu erstellen.

        // Database entries for courses, contains a list to the chapters.
        public DbSet<Domain.CourseDefinition> CourseDefinitions { get; set; }

        // Database entries for chapters, contains a list to the chapter elements.
        public DbSet<Domain.ChapterDefinition> ChapterDefinitions { get; set; }

        // Database entries for chapter elements.
        // This entry is used to get the elements.
        public DbSet<Domain.ChapterElementDefinition> ChapterElementDefinitions { get; set; }

        // Database entries for the specific chapter elements.
        // These entries are used to add the elements.
        public DbSet<Domain.ExplanatoryTextDefinition> ExplanatoryTextDefinitions { get; set; }
        public DbSet<Domain.PictureDefinition> PictureDefinitions { get; set; }
        public DbSet<Domain.VideoDefinition> VideoDefinitions { get; set; }
        public DbSet<Domain.QuizDefinition> QuizDefinitions { get; set; }

        // Database entries for authentification definitions.
        public DbSet<Domain.AuthDefinition> AuthDefinitions { get; set; }

        // Database entries for user definitions.
        public DbSet<Domain.UserDefinition> UserDefinitions { get; set; }

    }

}
