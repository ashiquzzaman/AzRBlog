using AzRBlog.Entities.Models;
using AzRBlog.Repositories;

namespace AzRBlog.Services
{
    public class CountryServece : BaseService<Country>, ICountryService
    {
        ICountryRepository _country;

        public CountryServece(ICountryRepository country)
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
