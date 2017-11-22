using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagerDemoApplication.Interfaces.Factories;
using UserManagerDemoApplication.Interfaces.PropertyBags;
using UserManagerDemoApplication.PropertyBags;

namespace UserManagerDemoApplication.Factories
{
    public class UserFactory : IUserFactory
    {
        public IUser Create(int id, string name, int roleId, string roleDisplay, int statusId, string statusDisplay,
            DateTime updatedAt)
        {
            return new User() { UserId = id, Name = name, StatusId = statusId, StatusDisplay = statusDisplay, RoleId = roleId, RoleDisplay = roleDisplay, UpdatedAt = updatedAt };
        }

        public IUser Create()
        {
            return new User();
        }
    }
}
