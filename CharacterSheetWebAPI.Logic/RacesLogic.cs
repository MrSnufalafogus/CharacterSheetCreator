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
    public class RacesLogic
    {
        public static Race GetRace(DatabaseSettings databaseSettings, int raceID)
        {
            Race returnValue = null;

            using (SqlConnection connection = new SqlConnection(databaseSettings.SqlClientConnectionString))
            {
                connection.Open();

                using (SqlCommand command = connection.CreateCommand())
                {
                    SqlParameter parameter;

                    command.CommandText = "csRaceGet";
                    command.CommandType = CommandType.StoredProcedure;

                    parameter = command.Parameters.Add("@RaceID", SqlDbType.Int);
                    parameter.Value = raceID;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read() == true)
                        {
                            returnValue = new Race();

                            if (reader["RaceID"] is int)
                            {
                                returnValue.RaceID = (int)reader["RaceID"];
                            }

                            if (reader["Name"] is string)
                            {
                                returnValue.Name = (string)reader["Name"];
                            }

                            if (reader["RaceImage"] is string)
                            {
                                returnValue.RaceImage = (string)reader["RaceImage"];
                            }

                            if (reader["AgeRange"] is string)
                            {
                                returnValue.AgeRange = (string)reader["AgeRange"];
                            }

                            if (reader["Size"] is string)
                            {
                                returnValue.Size = (string)reader["Size"];
                            }

                            if (reader["Speed"] is string)
                            {
                                returnValue.Speed = (string)reader["Speed"];
                            }

                            if (reader["Languages"] is string)
                            {
                                returnValue.Languages = (string)reader["Languages"];
                            }

                            if (reader["Subtypes"] is string)
                            {
                                returnValue.Subtypes = (string)reader["Subtypes"];
                            }
                        }
                    }
                }
            }

            return returnValue;
        }

        public static Races GetRaces(DatabaseSettings databaseSettings)
        {
            Races returnValue = new Races();

            using (SqlConnection connection = new SqlConnection(databaseSettings.SqlClientConnectionString))
            {
                connection.Open();

                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "csRacesGet";
                    command.CommandType = CommandType.StoredProcedure;


                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read() == true)
                        {
                            Race r = new Race();

                            if (reader["RaceID"] is int)
                            {
                                r.RaceID = (int)reader["RaceID"];
                            }

                            if (reader["Name"] is string)
                            {
                                r.Name = (string)reader["Name"];
                            }

                            if (reader["RaceImage"] is string)
                            {
                                r.RaceImage = (string)reader["RaceImage"];
                            }

                            if (reader["AgeRange"] is string)
                            {
                                r.AgeRange = (string)reader["AgeRange"];
                            }

                            if (reader["Size"] is string)
                            {
                                r.Size = (string)reader["Size"];
                            }

                            if (reader["Speed"] is string)
                            {
                                r.Speed = (string)reader["Speed"];
                            }

                            if (reader["Languages"] is string)
                            {
                                r.Languages = (string)reader["Languages"];
                            }

                            if (reader["Subtypes"] is string)
                            {
                                r.Subtypes = (string)reader["Subtypes"];
                            }

                            returnValue.Add(r);
                        }
                    }
                }
            }

            return returnValue;
        }
    }
}
