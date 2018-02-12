using MvcWithMsUnit.Entities;
using MvcWithMsUnit.Repositories;

namespace MvcWithMsUnit.Managers
{
    public class AccountTypeManager : EntityManager<AccountType>, IAccountTypeManager
    {
        IAccountTypeRepository _country;

        public AccountTypeManager(IAccountTypeRepository country)
            : base(country)
        {
            _country = country;
        }

        public AccountType GetById(int id)
        {
            return _country.GetById(id);
        }
    }
}
