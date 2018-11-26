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
    public class TraitsLogic
    {
        public static Trait GetTrait(DatabaseSettings databaseSettings, int traitID)
        {
            Trait returnValue = null;

            using (SqlConnection connection = new SqlConnection(databaseSettings.SqlClientConnectionString))
            {
                connection.Open();

                using (SqlCommand command = connection.CreateCommand())
                {
                    SqlParameter parameter;

                    command.CommandText = "csTraitGet";
                    command.CommandType = CommandType.StoredProcedure;

                    parameter = command.Parameters.Add("@TraitID", SqlDbType.Int);
                    parameter.Value = traitID;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read() == true)
                        {
                            returnValue = new Trait();

                            if (reader["TraitID"] is int)
                            {
                                returnValue.TraitID = (int)reader["TraitID"];
                            }

                            if (reader["Name"] is string)
                            {
                                returnValue.Name = (string)reader["Name"];
                            }

                            if (reader["SpecialtyName"] is string)
                            {
                                returnValue.SpecialtyName = (string)reader["SpecialtyName"];
                            }

                            if (reader["Specialty"] is string)
                            {
                                returnValue.Specialty = (string)reader["Specialty"];
                            }

                            if (reader["Traits"] is string)
                            {
                                returnValue.Traits = (string)reader["Traits"];
                            }

                            if (reader["Ideal"] is string)
                            {
                                returnValue.Ideal = (string)reader["Ideal"];
                            }

                            if (reader["Bond"] is string)
                            {
                                returnValue.Bond = (string)reader["Bond"];
                            }

                            if (reader["Flaw"] is string)
                            {
                                returnValue.Flaw = (string)reader["Flaw"];
                            }
                        }
                    }
                }
            }

            return returnValue;
        }

        public static Traits GetTraits(DatabaseSettings databaseSettings)
        {
            Traits returnValue = null;

            using (SqlConnection connection = new SqlConnection(databaseSettings.SqlClientConnectionString))
            {
                connection.Open();

                using (SqlCommand command = connection.CreateCommand())
                {

                    command.CommandText = "csTraitGet";
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read() == true)
                        {
                            Trait t = new Trait();

                            if (reader["TraitID"] is int)
                            {
                                t.TraitID = (int)reader["TraitID"];
                            }

                            if (reader["Name"] is string)
                            {
                                t.Name = (string)reader["Name"];
                            }

                            if (reader["SpecialtyName"] is string)
                            {
                                t.SpecialtyName = (string)reader["SpecialtyName"];
                            }

                            if (reader["Specialty"] is string)
                            {
                                t.Specialty = (string)reader["Specialty"];
                            }

                            if (reader["Traits"] is string)
                            {
                                t.Traits = (string)reader["Traits"];
                            }

                            if (reader["Ideal"] is string)
                            {
                                t.Ideal = (string)reader["Ideal"];
                            }

                            if (reader["Bond"] is string)
                            {
                                t.Bond = (string)reader["Bond"];
                            }

                            if (reader["Flaw"] is string)
                            {
                                t.Flaw = (string)reader["Flaw"];
                            }

                            returnValue.Add(t);
                        }
                    }
                }
            }

            return returnValue;
        }
    }
}
