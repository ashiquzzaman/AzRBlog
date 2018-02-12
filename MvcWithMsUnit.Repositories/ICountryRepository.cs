using MvcWithMsUnit.Entities;

namespace MvcWithMsUnit.Repositories
{

    public interface ICountryRepository : IRepository<Country>
    {
        Country GetById(int id);
    }
}
