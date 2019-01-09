using AzRBlog.Entities.Models;

namespace AzRBlog.Repositories
{

    public interface IUserProfileRepository : IRepository<UserProfile>
    {
        UserProfile GetById(long id);
    }
}
