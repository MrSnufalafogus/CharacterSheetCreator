using CharacterSheetWebAPI.Contracts;
using CharacterSheetWebAPI.Contracts.API;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CharacterSheetWebAPI.Logic.Commands
{
    public class UserProfileChangePasswordCommand
    {
        private ErrorOut errorOut = null;
        private HttpStatusCode httpStatusCode = HttpStatusCode.OK;
        //private WebSession currentSession;
        private DatabaseSettings datastoreProfile = null;
        private UserProfile userProfile = null;
        private Guid sessionID;
        private Guid effectiveUserID;
        private string effectiveUserName;
        private int merchantID;
        private int siteID;
        private int workstationID;
        private UserProfile userProfileAfterSave = null;
        private bool isNewUser = false;
        private string newUserPassword = null;
        private StringBuilder traceDataBefore = new StringBuilder();
        private StringBuilder traceDataAfter = new StringBuilder();

        public UserProfile UserProfile
        {
            get
            {
                return this.userProfile;
            }
        }

        public ErrorOut ErrorOut
        {
            get
            {
                return this.errorOut;
            }
        }

        public HttpStatusCode HttpStatusCode
        {
            get
            {
                return this.httpStatusCode;
            }
        }

        public UserProfileChangePasswordCommand(DatabaseSettings datastoreProfile, Guid effectiveUserID, UserProfile userProfile)
        {
            this.datastoreProfile = datastoreProfile;
            this.userProfile = userProfile;
            this.effectiveUserID = effectiveUserID;
        }

        public async Task<bool> Execute()
        {
            bool returnValue = false;
            using (SqlConnection connection = new SqlConnection(this.datastoreProfile.SqlClientConnectionString))
            {
                // don't have the opportunity to wait for this, need it right away
                await connection.OpenAsync();
                using (SqlTransaction transaction = connection.BeginTransaction("UserSaveTransaction"))
                {
                    returnValue = await Validate(connection, transaction);
                    if (returnValue == true)
                    {
                        try
                        {
                            this.userProfileAfterSave = await UserProfileLogic.UserProfileSave(
                                databaseSettings: datastoreProfile,
                                userID: effectiveUserID,
                                connection: connection,
                                transaction: transaction,
                                userProfile: userProfile
                            );
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            returnValue = false;
                            this.errorOut = new ErrorOut(0, "Unhandled Exception during execution");
                            this.httpStatusCode = HttpStatusCode.InternalServerError;
                            Debug.Print("[UserSaveCommand] Unhandled Exception during execution: " + ex.ToString());
                        }
                    }
                }
            }
            return returnValue;
        }

        private async Task<bool> Validate(SqlConnection connection, SqlTransaction transaction)
        {
            bool returnValue = true;


            return returnValue;
        }

    }
}
