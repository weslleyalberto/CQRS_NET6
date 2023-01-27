using CQRS_read_Infrastructure.Persistance.People;

namespace CQRS_read_Infrastructure.Persistance
{
	public interface IContexto
	{
		IPersonRepository People { get; set; }

	}
}
