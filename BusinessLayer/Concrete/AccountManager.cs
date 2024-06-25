using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BusinessLayer.Concrete
{
    public class AccountManager : IAccountService
    {
        private readonly IAccountDal _accountDal;

        public AccountManager(IAccountDal accountDal)
        {
            _accountDal = accountDal;
        }

        public void Create(Account entity)
        {
            _accountDal.Add(entity);
        }

        public void Delete(int id)
        {
            var account = _accountDal.Get(a => a.Id == id);
            if (account != null)
            {
                _accountDal.Delete(account);
            }
        }

        public Account GetById(int id)
        {
            return _accountDal.Get(a => a.Id == id);
        }

        public IEnumerable<Account> GetAll(Expression<Func<Account, bool>> filter = null)
        {
            return _accountDal.GetAll(filter);
        }

        public void Update(Account entity)
        {
            _accountDal.Update(entity);
        }
    }
}
