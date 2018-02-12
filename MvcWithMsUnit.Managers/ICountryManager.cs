using MvcWithMsUnit.Entities;

namespace MvcWithMsUnit.Managers
{
    public interface ICountryManager : IEntityManager<Country>
    {
        Country GetById(int id);
    }
}
