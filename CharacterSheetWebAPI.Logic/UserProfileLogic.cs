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
    public class UserProfileLogic
    {

        public static async Task<UserProfiles> UserProfileGet(DatabaseSettings databaseSettings, Guid userID)
        {
            return await UserProfileGet(
                databaseSettings: databaseSettings,
                effectiveUserID: userID,
                userID: userID
            );
        }

        public static async Task<UserProfiles> UserProfileGet(DatabaseSettings databaseSettings, Guid effectiveUserID, Guid userID)
        {
            UserProfiles returnValue = null;
            using (SqlConnection connection = new SqlConnection(databaseSettings.SqlClientConnectionString))
            {
                Task dbOpenTask = connection.OpenAsync();
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "csUserProfileGet";
                    command.CommandType = CommandType.StoredProcedure;

                    SqlParameter parameter = null;

                    parameter = command.Parameters.Add("@uUserID", SqlDbType.UniqueIdentifier);
                    parameter.Value = effectiveUserID;

                    parameter = command.Parameters.Add("@UserID", SqlDbType.UniqueIdentifier);
                    if (Guid.Empty.Equals(userID) == true)
                    {
                        parameter.Value = DBNull.Value;
                    }
                    else
                    {
                        parameter.Value = userID;
                    }

                    await dbOpenTask;
                    command.Connection = connection;
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        returnValue = new UserProfiles();
                        while (await reader.ReadAsync())
                        {
                            UserProfile up = new UserProfile();

                            if (Convert.IsDBNull(reader["UserID"]) == false)
                            {
                                up.UserID = (Guid)reader["UserID"];
                            }

                            if (Convert.IsDBNull(reader["FirstName"]) == false)
                            {
                                up.FirstName = (string)reader["FirstName"];
                            }

                            if (Convert.IsDBNull(reader["LastName"]) == false)
                            {
                                up.LastName = (string)reader["LastName"];
                            }

                            if (Convert.IsDBNull(reader["Email"]) == false)
                            {
                                up.Email = (string)reader["Email"];
                            }

                            if (Convert.IsDBNull(reader["MobilePhone"]) == false)
                            {
                                up.MobilePhone = (string)reader["MobilePhone"];
                            }

                            if (Convert.IsDBNull(reader["LoginID"]) == false)
                            {
                                up.LoginID = (string)reader["LoginID"];
                            }

                            if (Convert.IsDBNull(reader["LastSuccessfulLoginDateTime"]) == false)
                            {
                                up.LastSuccessfulLoginDateTime = (DateTime)reader["LastSuccessfulLoginDateTime"];
                            }


                            if (Convert.IsDBNull(reader["IsLoginAllowed"]) == false)
                            {
                                up.IsLoginAllowed = (bool)reader["IsLoginAllowed"];
                            }

                            if (Convert.IsDBNull(reader["IsPasswordChangeRequired"]) == false)
                            {
                                up.IsPasswordChangeRequired = (bool)reader["IsPasswordChangeRequired"];
                            }

                            if (Convert.IsDBNull(reader["HasLoggedIn"]) == false)
                            {
                                up.HasLoggedIn = (bool)reader["HasLoggedIn"];
                            }

                            returnValue.Add(up);
                        }
                    }
                }
            }
            return returnValue;
        }

        public static async Task<bool> UserProfileDelete(DatabaseSettings databaseSettings, Guid UserID)
        {
            bool returnValue = false;
            using (SqlConnection connection = new SqlConnection(databaseSettings.SqlClientConnectionString))
            {
                Task dbConnectionOpenTask = connection.OpenAsync();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "dyt.UserProfileDelete";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Connection = connection;

                    SqlParameter parameter = null;


                    parameter = command.Parameters.Add("@uMachineName", SqlDbType.NVarChar, 50);
                    parameter.Value = Environment.MachineName;

                    parameter = command.Parameters.Add("@uServerName", SqlDbType.NVarChar, 50);
                    parameter.Value = databaseSettings.Name;

                    parameter = command.Parameters.Add("@UserID", SqlDbType.UniqueIdentifier);
                    if (Guid.Empty.Equals(UserID) == true)
                    {
                        parameter.Value = DBNull.Value;
                    }
                    else
                    {
                        parameter.Value = UserID;
                    }

                    await dbConnectionOpenTask;
                    command.Connection = connection;
                    await command.ExecuteNonQueryAsync();
                }
            }
            returnValue = true;
            return returnValue;
        }

        public static async Task<UserProfile> UserProfileSave(DatabaseSettings databaseSettings, Guid userID, SqlConnection connection, SqlTransaction transaction, UserProfile userProfile)
        {
            UserProfile returnValue = null;
            using (SqlCommand command = connection.CreateCommand())
            {
                command.CommandText = "dyt.UserProfileSave";
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = connection;
                command.Transaction = transaction;

                SqlParameter parameter = null;

                parameter = command.Parameters.Add("@uMachineName", SqlDbType.NVarChar, 50);
                parameter.Value = Environment.MachineName;

                parameter = command.Parameters.Add("@uServerName", SqlDbType.NVarChar, 50);
                parameter.Value = databaseSettings.Name;

                parameter = command.Parameters.Add("@uAppName", SqlDbType.NVarChar, 50);
                parameter.Value = "Daytona";


                parameter = command.Parameters.Add("@UserID", SqlDbType.UniqueIdentifier);
                parameter.Direction = ParameterDirection.InputOutput;
                if (Guid.Empty.Equals(userProfile.UserID) == true)
                {
                    parameter.Value = DBNull.Value;
                }
                else
                {
                    parameter.Value = userProfile.UserID;
                }

                parameter = command.Parameters.Add("@FirstName", SqlDbType.NVarChar, 30);
                parameter.Value = userProfile.FirstName;
                parameter = command.Parameters.Add("@LastName", SqlDbType.NVarChar, 30);
                parameter.Value = userProfile.LastName;
                parameter = command.Parameters.Add("@Email", SqlDbType.NVarChar, 255);
                parameter.Value = userProfile.Email;
                parameter = command.Parameters.Add("@MobilePhone", SqlDbType.NVarChar, 50);
                if (string.IsNullOrEmpty(userProfile.MobilePhone))
                {
                    parameter.Value = DBNull.Value;
                }
                else
                {
                    parameter.Value = userProfile.MobilePhone;
                }

                string loginPasswordHash = string.Empty;
                string passwordValidityHash = string.Empty;
                if (string.IsNullOrEmpty(userProfile.Password) == false)
                {
                    loginPasswordHash = EncrpytHelper.SecureHash(userProfile.Password.ToLower());
                }
                parameter = command.Parameters.Add("@LoginPasswordHash", SqlDbType.VarChar, 255);
                parameter.Value = loginPasswordHash ?? string.Empty;

                parameter = command.Parameters.Add("@PasswordValidityHash", SqlDbType.VarChar, 255);
                parameter.Value = passwordValidityHash ?? string.Empty;

                parameter = command.Parameters.Add("@IsPasswordChangeRequired", SqlDbType.Bit);
                parameter.Value = userProfile.IsPasswordChangeRequired;

                parameter = command.Parameters.Add("@LoginID", SqlDbType.NVarChar, 50);
                parameter.Value = userProfile.LoginID;

                parameter = command.Parameters.Add("@IsLoginAllowed", SqlDbType.Bit);
                parameter.Value = userProfile.IsLoginAllowed;

                parameter = command.Parameters.Add("@Name", SqlDbType.NVarChar, 50);
                parameter.Value = userProfile.Name;

                await command.ExecuteNonQueryAsync();

                userProfile.UserID = (Guid)command.Parameters["@UserID"].Value;
                returnValue = userProfile;
            }
            return returnValue;
        }

    }
}
