using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BusinessLayer.Concrete
{
    public class TransferManager : ITransferService
    {
        private readonly ITransferDal _transferDal;

        public TransferManager(ITransferDal transferDal)
        {
            _transferDal = transferDal;
        }

        public Transfer GetById(int id)
        {
            return _transferDal.Get(t => t.Id == id);
        }

        public void Create(Transfer entity)
        {
            _transferDal.Add(entity);
        }

        public void Delete(int id)
        {
            var transfer = _transferDal.Get(t => t.Id == id);
            if (transfer != null)
            {
                _transferDal.Delete(transfer);
            }
        }

        public IEnumerable<Transfer> GetAll(Expression<Func<Transfer, bool>> filter = null)
        {
            return _transferDal.GetAll(filter);
        }

        public void Update(Transfer entity)
        {
            _transferDal.Update(entity);
        }
    }
}
