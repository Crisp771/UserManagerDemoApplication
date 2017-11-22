using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagerDemoApplication.Interfaces.PropertyBags;

namespace UserManagerDemoApplication.PropertyBags
{
    public class Role : IRole
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
