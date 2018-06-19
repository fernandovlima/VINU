using System.Collections.Generic;

namespace Controllers.Base
{
    interface IBaseController<T> where T : class
    {
        void AddNew(T entity);
        ICollection<T> ListAll();
        ICollection<T> ListByName(string name);
        T SearchById(int id);
        void Edit(T entity);
        void Delete(int id); 

    }
}
