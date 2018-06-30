using Controllers.Base;
using Controllers.DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    public class UserController : IBaseController<User>
    {

        private Context context = new Context();

        public void AddNew(User entity)
        {
            context.Users.Add(entity);
            context.SaveChanges();
        }

        public void Delete(int id) 
        {
            User user = SearchById(id); //busca usuário pela ID

            if (user != null)
            {
                context.Users.Remove(user); //Remove usuário vinculado a id informada
                context.SaveChanges(); //salva as alterações
            }

        }

        public void Edit(User entity)
        {
            context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }

        public ICollection<User> ListAll()
        {
            return context.Users.ToList();
        }

        public ICollection<User> ListByName(string name)
        {
            return context.Users.Where(user => user.Nome.Contains(name)).ToList();
        }

        public User SearchById(int id)
        {
            return context.Users.Find(id);
        }

        public void AddWineToList(int userId, Wine vinho)
        {           

            if (context.FavoriteWines.Find(userId, vinho.VinhoID) == null)
            {
                FavoriteWines favorite = new FavoriteWines(userId, vinho.VinhoID);
                context.FavoriteWines.Add(favorite);
                context.SaveChanges();
            }
        }

        public void DeleteWineFromList(int userId, int vinhoId)
        {

            FavoriteWines favorite = new FavoriteWines(userId, vinhoId);
            context.FavoriteWines.Remove(favorite);
            context.SaveChanges();

        }

        public void DeleteAllWinesFromList(int userId)
        {
            var favorites = context.FavoriteWines.Where(f => f.UserID.UserID == userId).ToList();
            foreach (var vinho in favorites)
            {
                context.FavoriteWines.Remove(vinho);
            }

            context.SaveChanges();
        }

        public ICollection<FavoriteWines> ListAllFavoriteWinesByUser(int userId)
        {
            User user = SearchById(userId);
            user.VinhosFavoritos = context.FavoriteWines.Where(f => f.UserID.UserID == userId).ToList();
            if(user.VinhosFavoritos != null)
            {
                return user.VinhosFavoritos;
            }
            else
            {
                return null;
            }
        }


    }
}
