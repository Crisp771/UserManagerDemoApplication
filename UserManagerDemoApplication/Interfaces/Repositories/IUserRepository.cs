using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagerDemoApplication.Interfaces.PropertyBags;

namespace UserManagerDemoApplication.Interfaces.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<IUser> GetUsers();
        IEnumerable<IRole> GetRoles();
        IEnumerable<IStatus> GetStatuses();
        IUser AddUser(IUser user);
        IUser UpdateUser(IUser user);
        void DeleteUser(int userId);
    }
}
