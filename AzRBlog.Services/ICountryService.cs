using AzRBlog.Entities.Models;

namespace AzRBlog.Services
{
    public interface ICountryService : IBaseService<Country>
    {
        Country GetById(int id);
    }
}
