using MvcWithMsUnit.Entities;
using System.Data.Entity;
using System.Linq;

namespace MvcWithMsUnit.Repositories
{

    public class AccountTypeRepository : Repository<AccountType>, IAccountTypeRepository
    {
        public AccountTypeRepository(DbContext context)
            : base(context)
        {

        }
        public AccountType GetById(int id)
        {
            return FindBy(x => x.Id == id).FirstOrDefault();
        }
    }
}
