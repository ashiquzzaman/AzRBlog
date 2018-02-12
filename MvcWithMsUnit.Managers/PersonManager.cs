using MvcWithMsUnit.Entities;
using MvcWithMsUnit.Repositories;

namespace MvcWithMsUnit.Managers
{
    public class PersonManager : EntityManager<Person>, IPersonManager
    {
        IPersonRepository _person;

        public PersonManager(IPersonRepository person)
            : base(person)
        {
            _person = person;
        }


        public Person GetById(long Id)
        {
            return _person.GetById(Id);
        }
    }
}
