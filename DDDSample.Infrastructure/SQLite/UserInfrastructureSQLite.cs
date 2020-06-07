using System;
using System.Data.SQLite;
using System.Linq;
using Dapper;
using DDDSample.DomainModel;
using Microsoft.Extensions.Configuration;

namespace DDDSample.Infrastructure
{
    public class UserInfrastructureSQLite : IUserRepository
    {
        private readonly SQLiteConnectionStringBuilder _ConnectionSb;

        public UserInfrastructureSQLite (IConfiguration configuration)
        {
            _ConnectionSb = new SQLiteConnectionStringBuilder { DataSource = configuration?.GetSection ("ConnectionStrings") ? ["Default"] };
        }

        public Users FindAll ()
        {
            using (var connection = new SQLiteConnection (_ConnectionSb.ToString ()))
            {
                var sql = "select * from USERS";

                try
                {
                    connection.Open ();

                    var userData = connection.Query<UserDTO> (sql);

                    var users = new Users ();
                    foreach (var user in userData)
                    {
                        users.Add (new User (new Id (user.ID), new Name (user.NAME)));
                    }

                    return users;
                }
                catch (Exception ex)
                {
                    throw new Exception ($"DB接続で例外が発生しました.DataSource={_ConnectionSb.ToString()}", ex);
                }

            }
        }

        public User FindById (Id id)
        {
            using (var connection = new SQLiteConnection (_ConnectionSb.ToString ()))
            {
                try
                {
                    connection.Open ();
                    var sql = "select * from USERS WHERE ID = @id";

                    var userData = connection.QuerySingleOrDefault<UserDTO> (sql, new { id = id.Value });

                    return new User (id, new Name (userData.NAME));
                }
                catch (Exception ex)
                {
                    throw new Exception ($"DB接続で例外が発生しました.DataSource={_ConnectionSb.ToString()}", ex);
                }
            }
        }

        public User FindByName (string Name)
        {
            throw new NotImplementedException ();
        }

        class UserDTO
        {
            public string ID { get; set; }
            public string NAME { get; set; }
        }
    }
}