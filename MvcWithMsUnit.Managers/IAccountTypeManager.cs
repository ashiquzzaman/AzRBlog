using MvcWithMsUnit.Entities;

namespace MvcWithMsUnit.Managers
{
    public interface IAccountTypeManager : IEntityManager<AccountType>
    {
        AccountType GetById(int id);
    }
}
