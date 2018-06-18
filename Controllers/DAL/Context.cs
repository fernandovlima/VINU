using Models;
using System.Data.Entity;

namespace Controllers.DAL
{
    class Context : DbContext
    {

        public Context() : base("strConn")
        {
            // Padrão (se não existir a base de dados, a cria)
            //Database.SetInitializer(new CreateDatabaseIfNotExists<Context>());

            // Apaga e recria a base toda vez que o projeto é inicializado
            //Database.SetInitializer(new DropCreateDatabaseAlways<Context>());

            // Apaga e recria a base de dados se houver alterações nas modelos
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<Context>());

        }

        public DbSet<User> Users { set; get; }

        public DbSet<Vinho> Wines { set; get; }

        public DbSet<FavoriteWines> FavoriteWines { set; get; }

        public DbSet<AtributosVinho> Attributes { set; get; }

    }
}
