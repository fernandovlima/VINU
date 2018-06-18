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
    class UserController : IBaseController<User>
    {

        private Context context = new Context();

        public void AddNew(User entity)
        {
            throw new NotImplementedException();
        }

        public void Delet(int id) 
        {
            throw new NotImplementedException();
        }

        public void Edit(User entity)
        {
            throw new NotImplementedException();
        }

        public ICollection<User> ListAll()
        {
            throw new NotImplementedException();
        }

        public ICollection<User> ListByName(string name)
        {
            throw new NotImplementedException();
        }

        public User SearchById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
