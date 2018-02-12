using MvcWithMsUnit.Entities;

namespace MvcWithMsUnit.Repositories
{

    public interface IAccountTypeRepository : IRepository<AccountType>
    {
        AccountType GetById(int id);
    }
}
