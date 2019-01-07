using AzRBlog.Entities;
using AzRBlog.Repositories;

namespace AzRBlog.Services
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
