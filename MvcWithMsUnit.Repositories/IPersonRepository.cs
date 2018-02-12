using MvcWithMsUnit.Entities;

namespace MvcWithMsUnit.Repositories
{

    public interface IPersonRepository : IRepository<Person>
    {
        Person GetById(long id);
    }
}
