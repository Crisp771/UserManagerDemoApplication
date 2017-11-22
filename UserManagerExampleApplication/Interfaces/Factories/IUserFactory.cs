using UserManagerDemoApplication.Interfaces.PropertyBags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagerDemoApplication.Interfaces.Factories
{
    public interface IUserFactory
    {
        IUser Create(int id, string name, int roleId, string roleDisplay, int statusId, string statusDisplay, DateTime updatedAt);
        IUser Create();
    }
}
