using CharacterSheetWebAPI.Contracts;
using CharacterSheetWebAPI.Contracts.API;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterSheetWebAPI.Logic
{
    public class ClassesLogic
    {
        public static Class GetClass(DatabaseSettings databaseSettings, int classID)
        {
            Class returnValue = null;

            using (SqlConnection connection = new SqlConnection(databaseSettings.SqlClientConnectionString))
            {
                connection.Open();

                using (SqlCommand command = connection.CreateCommand())
                {
                    SqlParameter parameter;

                    command.CommandText = "csClassGet";
                    command.CommandType = CommandType.StoredProcedure;

                    parameter = command.Parameters.Add("@ClassID", SqlDbType.Int);
                    parameter.Value = classID;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read() == true)
                        {
                            returnValue = new Class();

                            if (reader["ClassID"] is int)
                            {
                                returnValue.ClassID = (int)reader["ClassID"];
                            }

                            if (reader["Name"] is string)
                            {
                                returnValue.Name = (string)reader["Name"];
                            }

                            if (reader["ClassImage"] is string)
                            {
                                returnValue.ClassImage = (string)reader["ClassImage"];
                            }

                            if (reader["Description"] is string)
                            {
                                returnValue.Description = (string)reader["Description"];
                            }

                            if (reader["HitDie"] is string)
                            {
                                returnValue.HitDie = (string)reader["HitDie"];
                            }

                            if (reader["PrimaryAbility"] is string)
                            {
                                returnValue.PrimaryAbility = (string)reader["PrimaryAbility"];
                            }

                            if (reader["SavingThrows"] is string)
                            {
                                returnValue.SavingThrows = (string)reader["SavingThrows"];
                            }

                            if (reader["ArmorProf"] is string)
                            {
                                returnValue.ArmorProf = (string)reader["ArmorProf"];
                            }

                            if (reader["WeaponProf"] is string)
                            {
                                returnValue.WeaponProf = (string)reader["WeaponProf"];
                            }
                        }
                    }
                }
            }

            return returnValue;
        }

        public static Classes GetClasses(DatabaseSettings databaseSettings)
        {
            Classes returnValue = null;

            using (SqlConnection connection = new SqlConnection(databaseSettings.SqlClientConnectionString))
            {
                connection.Open();

                using (SqlCommand command = connection.CreateCommand())
                { 

                    command.CommandText = "csClassGet";
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read() == true)
                        {
                            Class c = new Class();

                            if (reader["ClassID"] is int)
                            {
                                c.ClassID = (int)reader["ClassID"];
                            }

                            if (reader["Name"] is string)
                            {
                                c.Name = (string)reader["Name"];
                            }

                            if (reader["ClassImage"] is string)
                            {
                                c.ClassImage = (string)reader["ClassImage"];
                            }

                            if (reader["Description"] is string)
                            {
                                c.Description = (string)reader["Description"];
                            }

                            if (reader["HitDie"] is string)
                            {
                                c.HitDie = (string)reader["HitDie"];
                            }

                            if (reader["PrimaryAbility"] is string)
                            {
                                c.PrimaryAbility = (string)reader["PrimaryAbility"];
                            }

                            if (reader["SavingThrows"] is string)
                            {
                                c.SavingThrows = (string)reader["SavingThrows"];
                            }

                            if (reader["ArmorProf"] is string)
                            {
                                c.ArmorProf = (string)reader["ArmorProf"];
                            }

                            if (reader["WeaponProf"] is string)
                            {
                                c.WeaponProf = (string)reader["WeaponProf"];
                            }

                            returnValue.Add(c);
                        }
                    }
                }
            }

            return returnValue;
        }
    }
}
