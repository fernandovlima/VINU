using System;
using System.Collections.Generic;
using System.Linq;
using Controllers.Base;
using Controllers.DAL;
using Models;

namespace Controllers
{
	public class AtributosVinhoController : IBaseController<AtributosVinho>
    {
		private Context context = new Context();

        public AtributosVinhoController()
        {
        }

		public void AddNew(AtributosVinho entity)
		{
			context.Attributes.Add(entity);
			context.SaveChanges();
		}

		public void Delete(int id)
		{
			AtributosVinho atributos = SearchById(id);

			if(atributos != null)
			{
				context.Attributes.Remove(atributos);
				context.SaveChanges();
			}


		}

		public void Edit(AtributosVinho entity)
		{
			context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
		}

		public ICollection<AtributosVinho> ListAll()
		{
			return context.Attributes.ToList();
		}

		public ICollection<AtributosVinho> ListByName(string name)
		{
			return context.Attributes.Where(AtributosVinho => AtributosVinho.NomeAtributo == name).ToList();
		}

		public AtributosVinho SearchById(int id)
		{
			return context.Attributes.Find(id);
		}
	}
}
