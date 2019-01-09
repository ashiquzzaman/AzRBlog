using AzRBlog.Entities.Models;
using System.Data.Entity;
using System.Linq;

namespace AzRBlog.Repositories
{

    public class CountryRepository : Repository<Country>, ICountryRepository
    {
        public CountryRepository(DbContext context)
            : base(context)
        {

        }
        public Country GetById(int id)
        {
            return FindBy(x => x.Id == id).FirstOrDefault();
        }
    }
}
