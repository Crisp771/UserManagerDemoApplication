using System.Collections.Generic;
using System.Web.Http;
using UserManagerDemoApplication.Factories;
using UserManagerDemoApplication.Interfaces.PropertyBags;
using UserManagerDemoApplication.Repositories;

namespace UserManagerExampleWebApplication.Controllers
{
    public class StatusController : ApiController
    {
        public IEnumerable<IStatus> Get()
        {
            return new UserRepository(new UserFactory()).GetStatuses();
        }
    }
}
