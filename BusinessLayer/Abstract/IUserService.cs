using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IUserService : IGenericService<User>
    {
        User Authenticate(string email,string password);
        void Register(User user);   
    }
}
