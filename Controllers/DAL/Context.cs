using Models;
using System.Data.Entity;

namespace Controllers.DAL
{
    class Context : DbContext
    {

        public Context() : base("strConn")
        {

        }

        public DbSet<User> Users { set; get; }

        public DbSet<Vinho> Wines { set; get; }

        public DbSet<FavoriteWines> FavoriteWines { set; get; }

        public DbSet<AtributosVinho> Attributes { set; get; }

    }
}
