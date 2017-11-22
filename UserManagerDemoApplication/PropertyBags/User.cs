using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagerDemoApplication.Interfaces.PropertyBags;

namespace UserManagerDemoApplication.PropertyBags
{
    public class User : IUser
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public int RoleId { get; set; }
        public string RoleDisplay { get; set; }
        public int StatusId { get; set; }
        public string StatusDisplay { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
