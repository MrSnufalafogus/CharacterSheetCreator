using CharacterSheetWebAPI.Contracts;
using CharacterSheetWebAPI.Contracts.API;
using CharacterSheetWebAPI.Logic.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterSheetWebAPI.Logic
{
    public class AuthenticateUserLogic
    {
        public static User AuthenticateUser(DatabaseSettings databaseSettings, string loginID, string loginPassword)
        {
            User user = new User();

            using (SqlConnection connection = new SqlConnection(databaseSettings.SqlClientConnectionString))
            {
                connection.Open();

                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "csAuthenticateUser";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@LoginID", SqlDbType.NVarChar, 50).Value = loginID;
                    command.Parameters.Add("@LoginPassword", SqlDbType.NVarChar, 50).Value = EncrpytHelper.Encrypt(loginPassword, ProjectConstants.FullEncryptionKey);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            if (Convert.IsDBNull(reader["UserID"]) == false)
                            {
                                user.UserID = (Guid)reader["UserID"];
                            }

                            if (Convert.IsDBNull(reader["LoginID"]) == false)
                            {
                                user.LoginID = (string)reader["LoginID"];
                            }

                            if (Convert.IsDBNull(reader["Name"]) == false)
                            {
                                user.Name = (string)reader["Name"];
                            }
                        }

                        reader.Close();
                    }

                    connection.Close();
                }
            }
            return user;
        }
    }
}
