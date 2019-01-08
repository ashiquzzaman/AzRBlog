using AzRBlog.Entities;

namespace AzRBlog.Repositories
{

    public interface IUserProfileRepository : IRepository<UserProfile>
    {
        UserProfile GetById(long id);
    }
}
