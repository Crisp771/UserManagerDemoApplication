using System;
using System.Collections.Generic;

using System.Web.Http;
using UserManagerDemoApplication.Factories;
using UserManagerDemoApplication.Interfaces.PropertyBags;
using UserManagerDemoApplication.Repositories;


namespace UserManagerExampleWebApplication.Controllers
{
    public class RoleController : ApiController
    {
        public IEnumerable<IRole> Get()
        {
            return new UserRepository(new UserFactory()).GetRoles();
        }
    }
}
