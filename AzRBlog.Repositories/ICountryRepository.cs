using AzRBlog.Entities;

namespace AzRBlog.Repositories
{

    public interface ICountryRepository : IRepository<Country>
    {
        Country GetById(int id);
    }
}
