using System;
using System.Collections.Generic;
using System.Linq;
using Controllers.Base;
using Controllers.DAL;
using Models;

namespace Controllers
{
	public class VinhoController : IBaseController<Vinho>
    {
		private Context context = new Context();

        public VinhoController()
        {
        }

		public void AddNew(Vinho entity)
		{
			context.Wines.Add(entity);
			context.SaveChanges();
		}

		public void Delete(int id)
		{
			Vinho vinho = SearchById(id);

			if( vinho != null)
			{
				context.Wines.Remove(vinho);
				context.SaveChanges();

			}
		}

		public void Edit(Vinho entity)
		{
			context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
			context.SaveChanges();

		}

		public ICollection<Vinho> ListAll()
		{
			return context.Wines.ToList();
		}

		public ICollection<Vinho> ListByName(string name)
		{
			return context.Wines.Where(vinho => vinho.NomeVinho == name).ToList();
		}

		public Vinho SearchById(int id)
		{
			return context.Wines.Find(id);
		}

		public ICollection<Vinho> ListWinesByAtribute(string atributo)
		{
			return null;
		}
	}
}
