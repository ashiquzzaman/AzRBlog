using AzRBlog.Entities.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AzRBlog.Repositories
{
    public class UserProfileRepository : Repository<UserProfile>, IUserProfileRepository
    {
        public UserProfileRepository(DbContext context)
            : base(context)
        {

        }

        public override IEnumerable<UserProfile> GetAll()
        {
            return _dbContext.Set<UserProfile>().Include(x => x.Country).AsEnumerable();
        }

        public UserProfile GetById(long id)
        {
            return _dbset.Include(x => x.Country).Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
