using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using DataAccessLayer.Abstract;

namespace BusinessLayer.Concrete
{
    public class TransactionManager : ITransactionService
    {
        private readonly ITransactionDal _transactionDal;

        public TransactionManager(ITransactionDal transactionDal)
        {
            _transactionDal = transactionDal;
        }

        public Transaction GetById(int id)
        {
            return _transactionDal.Get(t => t.Id == id);
        }

        public void Create(Transaction entity)
        {
            _transactionDal.Add(entity);
        }

        public void Delete(int id)
        {
            var transaction = _transactionDal.Get(t => t.Id == id);
            if (transaction != null)
            {
                _transactionDal.Delete(transaction);
            }
        }

        public IEnumerable<Transaction> GetAll(Expression<Func<Transaction, bool>> filter = null)
        {
            return _transactionDal.GetAll(filter);
        }

        public void Update(Transaction entity)
        {
            _transactionDal.Update(entity);
        }
    }
}
