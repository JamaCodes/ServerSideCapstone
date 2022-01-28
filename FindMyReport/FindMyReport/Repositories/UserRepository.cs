using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FindMyReport.Utils;
using FindMyReport.Models;

namespace FindMyReport.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(IConfiguration configuration) : base(configuration) { }

        public User GetByFirebaseUserId(string firebaseUserId)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT Id, FirebaseUserId, FirstName, LastName, Phone, DateOfBirth, State, IsProvider 
                         FROM User
                         WHERE FirebaseUserId = @FirebaseuserId";

                    DbUtils.AddParameter(cmd, "@FirebaseUserId", firebaseUserId);

                    User user = null;

                    var reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        user = new User()
                        {
                            Id = DbUtils.GetInt(reader, "Id"),
                            FirebaseUserId = DbUtils.GetString(reader, "FirebaseUserId"),
                            FirstName = DbUtils.GetString(reader, "FirstName"),
                            LastName = DbUtils.GetString(reader, "LastName"),
                            Phone = DbUtils.GetString(reader, "Phone"),
                            DateOfBirth = DbUtils.GetDateTime(reader, "DateOfBirth"),
                            State = DbUtils.GetString(reader, "State"),
                            IsProvider = DbUtils.GetBool(reader, "IsProvider"),

                        };

                    }
                    reader.Close();

                    return user;
                }
            }
        }

        public void Add(User user)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO UserProfile (FirebaseUserId, FirstName, LastName, Phone, DateOfBirth, State, IsProvider )
                                        OUTPUT INSERTED.ID
                                        VALUES (@FirebaseUserId, @FirstName, @LastName, @Phone, @DateOfBirth, @State, @IsProvider)";
                    DbUtils.AddParameter(cmd, "@FirebaseUserId", user.FirebaseUserId);
                    DbUtils.AddParameter(cmd, "@FirstName", user.FirstName);
                    DbUtils.AddParameter(cmd, "@LastName", user.LastName);
                    DbUtils.AddParameter(cmd, "@Phone", user.Phone);
                    DbUtils.AddParameter(cmd, "@DateOfBirth", user.DateOfBirth);
                    DbUtils.AddParameter(cmd, "@State", user.State);
                    DbUtils.AddParameter(cmd, "@IsProvider", user.IsProvider);
                    user.Id = (int)cmd.ExecuteScalar();
                }
            }
        }
    }
}
