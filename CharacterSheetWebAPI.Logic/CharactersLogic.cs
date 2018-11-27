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
    public class CharactersLogic
    {
        public static Character GetCharacter(DatabaseSettings databaseSettings, Guid characterID)
        {
            Character returnValue = null;

            using (SqlConnection connection = new SqlConnection(databaseSettings.SqlClientConnectionString))
            {
                connection.Open();

                using (SqlCommand command = connection.CreateCommand())
                {
                    SqlParameter parameter;

                    command.CommandText = "csCharacterGet";
                    command.CommandType = CommandType.StoredProcedure;

                    parameter = command.Parameters.Add("@CharacterID", SqlDbType.UniqueIdentifier);
                    parameter.Value = characterID;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read() == true)
                        {
                            returnValue = new Character();

                            if (reader["CharacterID"] is Guid)
                            {
                                returnValue.CharacterID = (Guid)reader["CharacterID"];
                            }

                            if (reader["UserID"] is Guid)
                            {
                                returnValue.UserID = (Guid)reader["UserID"];
                            }

                            if (reader["Name"] is string)
                            {
                                returnValue.Name = (string)reader["Name"];
                            }

                            if (reader["ShareCode"] is string)
                            {
                                returnValue.ShareCode = (string)reader["ShareCode"];
                            }

                            if (reader["STR"] is int)
                            {
                                returnValue.STR = (int)reader["STR"];
                            }

                            if (reader["DEX"] is int)
                            {
                                returnValue.DEX = (int)reader["DEX"];
                            }

                            if (reader["CON"] is int)
                            {
                                returnValue.CON = (int)reader["CON"];
                            }

                            if (reader["WIS"] is int)
                            {
                                returnValue.WIS = (int)reader["WIS"];
                            }

                            if (reader["INT"] is int)
                            {
                                returnValue.INT = (int)reader["INT"];
                            }

                            if (reader["CHA"] is int)
                            {
                                returnValue.CHA = (int)reader["CHA"];
                            }

                            if (reader["Alignment"] is string)
                            {
                                returnValue.Alignment = (string)reader["Alignment"];
                            }

                            if (reader["ImageURL"] is string)
                            {
                                returnValue.ImageURL = (string)reader["ImageURL"];
                            }

                            if (reader["EyeColor"] is string)
                            {
                                returnValue.EyeColor = (string)reader["EyeColor"];
                            }

                            if (reader["HairColor"] is string)
                            {
                                returnValue.HairColor = (string)reader["HairColor"];
                            }

                            if (reader["Height"] is string)
                            {
                                returnValue.Height = (string)reader["Height"];
                            }

                            if (reader["Weight"] is string)
                            {
                                returnValue.Weight = (string)reader["Weight"];
                            }

                            if (reader["Biography"] is string)
                            {
                                returnValue.Biography = (string)reader["Biography"];
                            }

                            if (reader["TraitID"] is int)
                            {
                                returnValue.TraitID = (int)reader["TraitID"];
                            }

                            if (reader["ClassID"] is int)
                            {
                                returnValue.ClassID = (int)reader["ClassID"];
                            }

                            if (reader["RaceID"] is int)
                            {
                                returnValue.RaceID = (int)reader["RaceID"];
                            }

                            returnValue.Trait = TraitsLogic.GetTrait(databaseSettings, returnValue.TraitID);
                            returnValue.Class = ClassesLogic.GetClass(databaseSettings, returnValue.ClassID);
                            returnValue.Race = RacesLogic.GetRace(databaseSettings, returnValue.RaceID);
                        }
                    }
                }
            }

            return returnValue;
        }

        public static Character GetCharacterByShare(DatabaseSettings databaseSettings, string ShareCode)
        {
            Character returnValue = null;

            using (SqlConnection connection = new SqlConnection(databaseSettings.SqlClientConnectionString))
            {
                connection.Open();

                using (SqlCommand command = connection.CreateCommand())
                {
                    SqlParameter parameter;

                    command.CommandText = "csCharacterByShareCodeGet";
                    command.CommandType = CommandType.StoredProcedure;

                    parameter = command.Parameters.Add("@ShareCode", SqlDbType.NVarChar, 50);
                    parameter.Value = ShareCode;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read() == true)
                        {
                            returnValue = new Character();

                            if (reader["CharacterID"] is Guid)
                            {
                                returnValue.CharacterID = (Guid)reader["CharacterID"];
                            }

                            if (reader["UserID"] is Guid)
                            {
                                returnValue.UserID = (Guid)reader["UserID"];
                            }

                            if (reader["Name"] is string)
                            {
                                returnValue.Name = (string)reader["Name"];
                            }

                            if (reader["ShareCode"] is string)
                            {
                                returnValue.ShareCode = (string)reader["ShareCode"];
                            }

                            if (reader["STR"] is int)
                            {
                                returnValue.STR = (int)reader["STR"];
                            }

                            if (reader["DEX"] is int)
                            {
                                returnValue.DEX = (int)reader["DEX"];
                            }

                            if (reader["CON"] is int)
                            {
                                returnValue.CON = (int)reader["CON"];
                            }

                            if (reader["WIS"] is int)
                            {
                                returnValue.WIS = (int)reader["WIS"];
                            }

                            if (reader["INT"] is int)
                            {
                                returnValue.INT = (int)reader["INT"];
                            }

                            if (reader["CHA"] is int)
                            {
                                returnValue.CHA = (int)reader["CHA"];
                            }

                            if (reader["Alignment"] is string)
                            {
                                returnValue.Alignment = (string)reader["Alignment"];
                            }

                            if (reader["ImageURL"] is string)
                            {
                                returnValue.ImageURL = (string)reader["ImageURL"];
                            }

                            if (reader["EyeColor"] is string)
                            {
                                returnValue.EyeColor = (string)reader["EyeColor"];
                            }

                            if (reader["HairColor"] is string)
                            {
                                returnValue.HairColor = (string)reader["HairColor"];
                            }

                            if (reader["Height"] is string)
                            {
                                returnValue.Height = (string)reader["Height"];
                            }

                            if (reader["Weight"] is string)
                            {
                                returnValue.Weight = (string)reader["Weight"];
                            }

                            if (reader["Biography"] is string)
                            {
                                returnValue.Biography = (string)reader["Biography"];
                            }

                            if (reader["TraitID"] is int)
                            {
                                returnValue.TraitID = (int)reader["TraitID"];
                            }

                            if (reader["ClassID"] is int)
                            {
                                returnValue.ClassID = (int)reader["ClassID"];
                            }

                            if (reader["RaceID"] is int)
                            {
                                returnValue.RaceID = (int)reader["RaceID"];
                            }

                            returnValue.Trait = TraitsLogic.GetTrait(databaseSettings, returnValue.TraitID);
                            returnValue.Class = ClassesLogic.GetClass(databaseSettings, returnValue.ClassID);
                            returnValue.Race = RacesLogic.GetRace(databaseSettings, returnValue.RaceID);
                        }
                    }
                }
            }

            return returnValue;
        }

        public static Characters GetCharacters(DatabaseSettings databaseSettings, Guid userID)
        {
            Characters returnValue = new Characters();

            using (SqlConnection connection = new SqlConnection(databaseSettings.SqlClientConnectionString))
            {
                connection.Open();

                using (SqlCommand command = connection.CreateCommand())
                {
                    SqlParameter parameter;

                    command.CommandText = "csUserCharactersGet";
                    command.CommandType = CommandType.StoredProcedure;

                    parameter = command.Parameters.Add("@UserID", SqlDbType.UniqueIdentifier);
                    parameter.Value = userID;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            Character c = new Character();

                            if (reader["CharacterID"] is Guid)
                            {
                                c.CharacterID = (Guid)reader["CharacterID"];
                            }

                            if (reader["UserID"] is Guid)
                            {
                                c.UserID = (Guid)reader["UserID"];
                            }

                            if (reader["Name"] is string)
                            {
                                c.Name = (string)reader["Name"];
                            }

                            if (reader["ShareCode"] is string)
                            {
                                returnValue.ShareCode = (string)reader["ShareCode"];
                            }

                            if (reader["STR"] is int)
                            {
                                c.STR = (int)reader["STR"];
                            }

                            if (reader["DEX"] is int)
                            {
                                c.DEX = (int)reader["DEX"];
                            }

                            if (reader["CON"] is int)
                            {
                                c.CON = (int)reader["CON"];
                            }

                            if (reader["WIS"] is int)
                            {
                                c.WIS = (int)reader["WIS"];
                            }

                            if (reader["INT"] is int)
                            {
                                c.INT = (int)reader["INT"];
                            }

                            if (reader["CHA"] is int)
                            {
                                c.CHA = (int)reader["CHA"];
                            }

                            if (reader["Alignment"] is string)
                            {
                                c.Alignment = (string)reader["Alignment"];
                            }

                            if (reader["ImageURL"] is string)
                            {
                                c.ImageURL = (string)reader["ImageURL"];
                            }

                            if (reader["EyeColor"] is string)
                            {
                                c.EyeColor = (string)reader["EyeColor"];
                            }

                            if (reader["HairColor"] is string)
                            {
                                c.HairColor = (string)reader["HairColor"];
                            }

                            if (reader["Height"] is string)
                            {
                                c.Height = (string)reader["Height"];
                            }

                            if (reader["Weight"] is string)
                            {
                                c.Weight = (string)reader["Weight"];
                            }

                            if (reader["Biography"] is string)
                            {
                                c.Biography = (string)reader["Biography"];
                            }

                            if (reader["TraitID"] is int)
                            {
                                c.TraitID = (int)reader["TraitID"];
                            }

                            if (reader["ClassID"] is int)
                            {
                                c.ClassID = (int)reader["ClassID"];
                            }

                            if (reader["RaceID"] is int)
                            {
                                c.RaceID = (int)reader["RaceID"];
                            }

                            c.Trait = TraitsLogic.GetTrait(databaseSettings, c.TraitID);
                            c.Class = ClassesLogic.GetClass(databaseSettings, c.ClassID);
                            c.Race = RacesLogic.GetRace(databaseSettings, c.RaceID);

                            returnValue.Add(c);
                        }
                    }
                }
            }

            return returnValue;
        }
    }
}
