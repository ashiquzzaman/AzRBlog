using AzRBlog.Entities;

namespace AzRBlog.Repositories
{

    public interface IPersonRepository : IRepository<Person>
    {
        Person GetById(long id);
    }
}
