using AzRBlog.Entities;
using AzRBlog.Repositories;

namespace AzRBlog.Services
{
    public class UserProfileService : BaseService<UserProfile>, IUserProfileService
    {
        IUserProfileRepository _person;

        public UserProfileService(IUserProfileRepository person)
            : base(person)
        {
            _person = person;
        }


        public UserProfile GetById(long Id)
        {
            return _person.GetById(Id);
        }
    }
}
