using System;
using System.Collections.Generic;
using System.Linq;
using Controllers.Base;
using Controllers.DAL;
using Models;

namespace Controllers
{
	public class WineController : IBaseController<Wine>
    {
		private Context context = new Context();

        public WineController()
        {
        }

		public void AddNew(Wine entity)
		{
			context.Wines.Add(entity);
			context.SaveChanges();
		}

		public void Delete(int id)
		{
			Wine vinho = SearchById(id);

			if( vinho != null)
			{
				context.Wines.Remove(vinho);
				context.SaveChanges();

			}
		}

		public void Edit(Wine entity)
		{
			context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
			context.SaveChanges();

		}

		public ICollection<Wine> ListAll()
		{
			return context.Wines.ToList();
		}

		public ICollection<Wine> ListByName(string name)
		{
			return context.Wines.Where(vinho => vinho.NomeVinho.Contains(name)).ToList();
		}

		public Wine SearchById(int id)
		{
			return context.Wines.Find(id);
		}
	}
}
