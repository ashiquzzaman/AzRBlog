using AzRBlog.Entities;
using AzRBlog.Repositories;

namespace AzRBlog.Services
{
    public class CountryManager : EntityManager<Country>, ICountryManager
    {
        ICountryRepository _country;

        public CountryManager(ICountryRepository country)
            : base(country)
        {
            _country = country;
        }

        public Country GetById(int id)
        {
            return _country.GetById(id);
        }
    }
}
