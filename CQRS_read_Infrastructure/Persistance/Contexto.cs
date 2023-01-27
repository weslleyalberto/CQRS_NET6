using CQRS_read_Infrastructure.Persistance.People;

namespace CQRS_read_Infrastructure.Persistance
{
	public class Contexto : IContexto
	{

		public Contexto(IPersonRepository personRepository)
		{
			People= personRepository;
		}

		public IPersonRepository People { get ; set ; }
		
	}
}
