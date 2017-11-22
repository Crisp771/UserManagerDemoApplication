using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UserManagerDemoApplication.Factories;
using UserManagerDemoApplication.Interfaces.PropertyBags;
using UserManagerDemoApplication.Repositories;
using UserManagerDemoApplication.PropertyBags;

namespace UserManagerExampleWebApplication.Controllers
{
    public class UserController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<IUser> Get()
        {
            return new UserRepository(new UserFactory()).GetUsers();
        }

        // GET api/<controller>/5
        public IUser Get(int id)
        {
            return new UserRepository(new UserFactory()).GetUser(id);
        }

        // POST api/<controller>
        public IUser Post([FromBody]User user)
        {
            return new UserRepository(new UserFactory()).AddUser(user);
        }

        // PUT api/<controller>/5
        public IUser Put([FromBody]User user)
        {
            return new UserRepository(new UserFactory()).UpdateUser(user);
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            new UserRepository(new UserFactory()).DeleteUser(id);
        }
    }
}