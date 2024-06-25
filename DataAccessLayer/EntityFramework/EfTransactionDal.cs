using EntityLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfTransactionDal : GenericRepository<Transaction>,ITransactionDal 
    {
        public EfTransactionDal(FinanceDbContext context) : base(context)
        {
        }
    }
}
