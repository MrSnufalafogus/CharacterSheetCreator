using CharacterSheetWebAPI.Contracts;
using CharacterSheetWebAPI.Contracts.API;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace CharacterSheetWebAPI.Logic
{
    public class AccessTokenLogic
    {
        public static AccessToken GetAccessToken(DatabaseSettings databaseSettings, Guid accessTokenID)
        {
            AccessToken returnValue = null;

            using (SqlConnection connection = new SqlConnection(databaseSettings.SqlClientConnectionString))
            {
                connection.Open();

                using (SqlCommand command = connection.CreateCommand())
                {
                    SqlParameter parameter;

                    command.CommandText = "csAccessTokenGet";
                    command.CommandType = CommandType.StoredProcedure;

                    parameter = command.Parameters.Add("@AccessTokenID", SqlDbType.UniqueIdentifier);
                    parameter.Value = accessTokenID;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read() == true)
                        {
                            returnValue = new AccessToken();

                            if (reader["AccessTokenID"] is Guid)
                            {
                                returnValue.AccessTokenID = (Guid)reader["AccessTokenID"];
                            }

                            if (reader["AuthenticationID"] is Guid)
                            {
                                returnValue.AuthenticationID = (Guid)reader["AuthenticationID"];
                            }

                            if (reader["LastAccessDateTime"] is DateTime)
                            {
                                returnValue.LastAccessDateTime = (DateTime)reader["LastAccessDateTime"];
                            }

                            if (reader["LoginID"] is string)
                            {
                                returnValue.LoginID = (string)reader["LoginID"];
                            }

                            if (reader["UserID"] is Guid)
                            {
                                returnValue.UserID = (Guid)reader["UserID"];
                            }

                            if (reader["UserName"] is string)
                            {
                                returnValue.UserName = (string)reader["UserName"];
                            }
                        }
                    }
                }
            }

            return returnValue;
        }
        public static void ChangeUser(DatabaseSettings databaseSettings, Guid accessTokenID, Guid userID, bool isLongTerm)
        {
            using (SqlConnection connection = new SqlConnection(databaseSettings.SqlClientConnectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    SqlParameter parameter;

                    command.CommandText = "csAccessTokenChangeUser";
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();

                    command.CommandType = CommandType.StoredProcedure;

                    parameter = command.Parameters.Add("@SessionID", SqlDbType.UniqueIdentifier);
                    if (Guid.Empty.Equals(accessTokenID) == true)
                    {
                        parameter.Value = DBNull.Value;
                    }
                    else
                    {
                        parameter.Value = accessTokenID;
                    }

                    parameter = command.Parameters.Add("@UserID", SqlDbType.UniqueIdentifier);
                    if (Guid.Empty.Equals(userID) == true)
                    {
                        parameter.Value = DBNull.Value;
                    }
                    else
                    {
                        parameter.Value = userID;
                    }

                    parameter = command.Parameters.Add("@IsLongTerm", SqlDbType.Bit);
                    parameter.Value = isLongTerm;

                    using (SqlTransaction transaction = connection.BeginTransaction())
                    {
                        command.Transaction = transaction;

                        command.ExecuteNonQuery();

                        transaction.Commit();
                    }
                }
            }

            return;
        }
        public static async Task<AccessToken> GetAccessTokenAsync(DatabaseSettings databaseSettings, Guid accessTokenID)
        {
            AccessToken returnValue = null;

            using (SqlConnection connection = new SqlConnection(databaseSettings.SqlClientConnectionString))
            {
                Task dbConnectionOpenTask = connection.OpenAsync();

                using (SqlCommand command = new SqlCommand())
                {
                    SqlParameter parameter;

                    command.CommandText = "csAccessTokenGet";
                    command.CommandType = CommandType.StoredProcedure;

                    parameter = command.Parameters.Add("@AccessTokenID", SqlDbType.UniqueIdentifier);
                    parameter.Value = accessTokenID;

                    await dbConnectionOpenTask;
                    command.Connection = connection;

                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        int ordinal = -1;
                        if (await reader.ReadAsync() == true)
                        {
                            returnValue = new AccessToken();

                            ordinal = reader.GetOrdinal("AccessTokenID");
                            if (reader.IsDBNull(ordinal) == false)
                            {
                                returnValue.AccessTokenID = reader.GetFieldValue<Guid>(ordinal);
                            }

                            ordinal = reader.GetOrdinal("AuthenticationID");
                            if (reader.IsDBNull(ordinal) == false)
                            {
                                returnValue.AuthenticationID = reader.GetFieldValue<Guid>(ordinal);
                            }

                            ordinal = reader.GetOrdinal("LastAccessDateTime");
                            if (reader.IsDBNull(ordinal) == false)
                            {
                                returnValue.LastAccessDateTime = reader.GetFieldValue<DateTime>(ordinal);
                            }

                            ordinal = reader.GetOrdinal("LoginID");
                            if (reader.IsDBNull(ordinal) == false)
                            {
                                returnValue.LoginID = reader.GetFieldValue<string>(ordinal);
                            }

                            ordinal = reader.GetOrdinal("UserID");
                            if (reader.IsDBNull(ordinal) == false)
                            {
                                returnValue.UserID = reader.GetFieldValue<Guid>(ordinal);
                            }

                            ordinal = reader.GetOrdinal("UserName");
                            if (reader.IsDBNull(ordinal) == false)
                            {
                                returnValue.UserName = reader.GetFieldValue<string>(ordinal);
                            }
                        }
                    }
                }
            }
            return returnValue;
        }


        public static async Task<Guid> CreateAccessTokenAsync(DatabaseSettings databaseSettings, Guid userID)
        {
            Guid returnValue = Guid.Empty;

            using (SqlConnection connection = new SqlConnection(databaseSettings.SqlClientConnectionString))
            {
                Task dbOpenTask = connection.OpenAsync();
                using (SqlCommand command = new SqlCommand())
                {
                    SqlParameter parameter;

                    command.CommandText = "csAccessTokenSave";
                    command.CommandType = CommandType.StoredProcedure;

                    parameter = command.Parameters.Add("@UserID", SqlDbType.UniqueIdentifier);
                    if (Guid.Empty.Equals(userID) == true)
                    {
                        parameter.Value = DBNull.Value;
                    }
                    else
                    {
                        parameter.Value = userID;
                    }

                    parameter = command.Parameters.Add("@SessionID", SqlDbType.UniqueIdentifier);
                    parameter.Direction = ParameterDirection.Output;
                    parameter.Value = DBNull.Value;

                    await dbOpenTask;
                    command.Connection = connection;

                    using (SqlTransaction transaction = connection.BeginTransaction())
                    {
                        command.Transaction = transaction;

                        try
                        {
                            await command.ExecuteNonQueryAsync();
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }

                        transaction.Commit();

                        parameter = command.Parameters["@SessionID"];
                        if (command.Parameters["@SessionID"].Value is Guid)
                        {
                            returnValue = (Guid)command.Parameters["@SessionID"].Value;
                        }
                    }
                }
            }
            return returnValue;
        }

        public static void UpdateLastAccessDateTime(DatabaseSettings databaseSettings, Guid accessTokenID)
        {
            using (SqlConnection connection = new SqlConnection(databaseSettings.SqlClientConnectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    SqlParameter parameter;

                    command.CommandText = "csAccessTokenUpdateLastAccessDateTime";
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();

                    command.CommandType = CommandType.StoredProcedure;

                    parameter = command.Parameters.Add("@SessionID", SqlDbType.UniqueIdentifier);
                    if (Guid.Empty.Equals(accessTokenID) == true)
                    {
                        parameter.Value = DBNull.Value;
                    }
                    else
                    {
                        parameter.Value = accessTokenID;
                    }

                    using (SqlTransaction transaction = connection.BeginTransaction())
                    {
                        command.Transaction = transaction;

                        command.ExecuteNonQuery();

                        transaction.Commit();
                    }
                }
            }

            return;
        }
    }
}
