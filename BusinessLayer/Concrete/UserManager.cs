using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BusinessLayer.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public User Authenticate(string email, string password)
        {
            return _userDal.Get(u => u.Email == email && u.Password == password);
        }

        public User GetById(int id)
        {
            return _userDal.Get(u => u.Id == id);
        }

        public void Register(User user)
        {
            _userDal.Add(user);
        }

        public void Create(User entity)
        {
            _userDal.Add(entity);
        }

        public void Delete(int id)
        {
            var user = _userDal.Get(u => u.Id == id);
            if (user != null)
            {
                _userDal.Delete(user);
            }
        }

        public IEnumerable<User> GetAll(Expression<Func<User, bool>> filter = null)
        {
            return _userDal.GetAll(filter);
        }

        public void Update(User entity)
        {
            _userDal.Update(entity);
        }
    }
}
