using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class TransferManager : ITransferService
    {
        ITransferDal _transferDal;

        public TransferManager(ITransferDal transferDal)
        {
            _transferDal = transferDal;
        }

        public Transfer GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Create(Transfer entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Transfer> GetAll(Expression<Func<Transfer, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Transfer entity)
        {
            throw new NotImplementedException();
        }
    }
}
