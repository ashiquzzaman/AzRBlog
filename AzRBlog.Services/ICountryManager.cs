using AzRBlog.Entities;

namespace AzRBlog.Services
{
    public interface ICountryManager : IEntityManager<Country>
    {
        Country GetById(int id);
    }
}
