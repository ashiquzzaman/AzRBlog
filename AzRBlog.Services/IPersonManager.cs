using AzRBlog.Entities;

namespace AzRBlog.Services
{

    public interface IPersonManager : IEntityManager<Person>
    {
        Person GetById(long id);
    }
}
