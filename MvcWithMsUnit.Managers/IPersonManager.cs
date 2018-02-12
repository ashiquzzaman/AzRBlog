using MvcWithMsUnit.Entities;

namespace MvcWithMsUnit.Managers
{

    public interface IPersonManager : IEntityManager<Person>
    {
        Person GetById(long id);
    }
}
