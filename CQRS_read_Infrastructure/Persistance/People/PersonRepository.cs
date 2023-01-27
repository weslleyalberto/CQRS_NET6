using System.Linq.Expressions;

namespace CQRS_read_Infrastructure.Persistance.People
{
	public class PersonRepository : IPersonRepository
	{
		private static List<Person> _listaPersonMemory = new List<Person>();
		public void Delete(Person entity)
		{
			_listaPersonMemory.Remove(entity);
		}

		public void Delete(object id)
		{
			_listaPersonMemory.Remove(Find(id));
		}

		public Person Find(object id)
		{
			return _listaPersonMemory.AsQueryable().FirstOrDefault(c => c.Id.Equals(id));
		}

		public IQueryable<Person> Get(Expression<Func<Person, bool>> predicate = null)
		{
			return predicate is not null ? _listaPersonMemory.AsQueryable().Where(predicate) :
				_listaPersonMemory.AsQueryable();
		}

		public void Insert(Person entity)
		{
			if (entity.Id == -1)
			{
				entity = new Person(_listaPersonMemory.Count + 1, entity.Class, entity.Nome, entity.Idade);
				_listaPersonMemory.Add(entity);
			}
		}

		public void Update(Person entity)
		{
			var person = Find(entity.Id);
			person.Class= entity.Class;
			person.Nome= entity.Nome;
			person.Idade= entity.Idade;
			
		}
	}
}
