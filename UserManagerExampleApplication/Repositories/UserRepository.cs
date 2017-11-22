using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using UserManagerDemoApplication.Interfaces.Factories;
using UserManagerDemoApplication.Interfaces.PropertyBags;
using UserManagerDemoApplication.Interfaces.Repositories;
using UserManagerDemoApplication.PropertyBags;
using System.Web.Configuration;

namespace UserManagerDemoApplication.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IUserFactory _userFactory;

        public UserRepository(IUserFactory userFactory)
        {
            _userFactory = userFactory;
        }

        public IEnumerable<IUser> GetUsers()
        {
            var users = new List<IUser>();
            var sql =
                "SELECT u.Id, u.[Name], RoleId, r.[Name] AS RoleDisplay, UpdatedAt, StatusId, s.[Name] AS StatusDisplay FROM Users u " +
                "INNER JOIN Statuses s ON s.Id = u.StatusId " +
                "INNER JOIN Roles r ON r.Id = u.RoleId WHERE Deleted = 0";
            using (var connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["UserManagerConnectionString"].ConnectionString))
            {
                using (var command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        users.Add(_userFactory.Create((int)reader["Id"], reader["Name"].ToString(), (int)reader["RoleId"], reader["RoleDisplay"].ToString(), (int)reader["StatusId"], reader["StatusDisplay"].ToString(), (DateTime)reader["UpdatedAt"]));
                    }
                    return users;
                }
            }
        }

        public IUser GetUser(int userId)
        {
            IUser user;
            var sql =
                "SELECT u.Id, u.[Name], RoleId, r.[Name] AS RoleDisplay, UpdatedAt, StatusId, s.[Name] AS StatusDisplay FROM Users u " +
                "INNER JOIN Statuses s ON s.Id = u.StatusId " +
                "INNER JOIN Roles r ON r.Id = u.RoleId WHERE Deleted = 0 AND u.Id = @UserId";
            using (var connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["UserManagerConnectionString"].ConnectionString))
            {
                using (var command = new SqlCommand(sql, connection))
                {

                    connection.Open();
                    command.Parameters.Add(new SqlParameter("@UserId", userId));

                    var reader = command.ExecuteReader();
                    if(reader.Read())
                    {
                        user =_userFactory.Create((int)reader["Id"], reader["Name"].ToString(), (int)reader["RoleId"], reader["RoleDisplay"].ToString(), (int)reader["StatusId"], reader["StatusDisplay"].ToString(), (DateTime)reader["UpdatedAt"]);
                    }
                    else
                    {
                        user =_userFactory.Create();
                    }
                    return user;
                }
            }
        }

        public IUser AddUser(IUser user)
        {
            using (var connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["UserManagerConnectionString"].ConnectionString))
            {
                using (var command = new SqlCommand("INSERT INTO Users ([Name],[RoleId],[UpdatedAt],[StatusId]) VALUES (@Name, @RoleId, @UpdatedAt, @StatusId); SELECT SCOPE_IDENTITY() AS [UserID];", connection))
                {
                    connection.Open();

                    command.Parameters.Add(new SqlParameter("@Name", user.Name));
                    command.Parameters.Add(new SqlParameter("@RoleId", user.RoleId));
                    command.Parameters.Add(new SqlParameter("@UpdatedAt", DateTime.Now));
                    command.Parameters.Add(new SqlParameter("@StatusId", user.StatusId));

                    return GetUser(Convert.ToInt32(command.ExecuteScalar()));
                }
            }
        }

        public IUser UpdateUser(IUser user)
        {
            using (var connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["UserManagerConnectionString"].ConnectionString))
            {
                using (var command = new SqlCommand("UPDATE Users SET [Name] = @Name, RoleId = @RoleId, UpdatedAt = @UpdatedAt, StatusId = @StatusId WHERE Id = @UserId", connection))
                {
                    connection.Open();

                    command.Parameters.Add(new SqlParameter("@UserId", user.UserId));
                    command.Parameters.Add(new SqlParameter("@Name", user.Name));
                    command.Parameters.Add(new SqlParameter("@RoleId", user.RoleId));
                    command.Parameters.Add(new SqlParameter("@UpdatedAt", DateTime.Now));
                    command.Parameters.Add(new SqlParameter("@StatusId", user.StatusId));

                    command.ExecuteNonQuery();
                }
            }
            return GetUser(user.UserId);
        }

        public void DeleteUser(int userId)
        {
            using (var connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["UserManagerConnectionString"].ConnectionString))
            {
                using (var command = new SqlCommand("UPDATE Users SET Deleted = 1 WHERE Id = @UserId", connection))
                {
                    connection.Open();

                    command.Parameters.Add(new SqlParameter("@UserId", userId));

                    command.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<IRole> GetRoles()
        {
            var roles = new List<IRole>();
            using (var connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["UserManagerConnectionString"].ConnectionString))
            {
                using (var command = new SqlCommand("SELECT Id, [Name] FROM Roles", connection))
                {
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        roles.Add(new Role() { Id = (int)reader["Id"], Name = reader["Name"].ToString() });
                    }
                    return roles;
                }
            }
        }

        public IEnumerable<IStatus> GetStatuses()
        {
            var statuses = new List<IStatus>();
            using (var connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["UserManagerConnectionString"].ConnectionString))
            {
                using (var command = new SqlCommand("SELECT Id, [Name] FROM Statuses", connection))
                {
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        statuses.Add(new Status() { Id = (int)reader["Id"], Name = reader["Name"].ToString() });
                    }
                    return statuses;
                }
            }
        }
    }
}
