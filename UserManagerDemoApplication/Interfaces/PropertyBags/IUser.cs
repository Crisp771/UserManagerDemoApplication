using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagerDemoApplication.Interfaces.PropertyBags
{
    public interface IUser
    {
        int UserId { get; set; }
        string Name { get; }
        int RoleId { get; }
        string RoleDisplay { get; }
        int StatusId { get; }
        string StatusDisplay { get; }
        DateTime UpdatedAt { get; }
    }
}
