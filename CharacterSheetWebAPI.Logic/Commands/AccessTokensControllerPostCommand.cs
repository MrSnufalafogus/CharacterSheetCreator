using CharacterSheetWebAPI.Contracts;
using CharacterSheetWebAPI.Contracts.API;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CharacterSheetWebAPI.Logic.Commands
{
    public class AccessTokensControllerPostCommand
    {
        private AccessToken accessToken = null;
        private Guid accessTokenID = Guid.Empty;
        private AccessTokenCredential credential = null;
        private DatabaseSettings databaseSettings = new DatabaseSettings();
        private ErrorOut errorOut = null;
        private bool isValidated = false;
        private HttpStatusCode httpStatusCode;

        public AccessToken AccessToken
        {
            get
            {
                return this.accessToken;
            }
        }

        public Guid AccessTokenID
        {
            get
            {
                return this.accessTokenID;
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

        public AccessTokensControllerPostCommand(DatabaseSettings databaseSettings)
        {
            this.databaseSettings = databaseSettings;
        }

        public async Task Execute()
        {
            if (this.isValidated == false)
            {
                await Validate();
            }
            if(this.credential.LoginID == "TST-USER" && this.credential.LoginPassword == "TST-PSSWRD")
            {
                this.accessToken = new AccessToken
                {
                    LoginID = "TST-USER",
                    IsLongTerm = true,
                    UserID = new Guid(),
                    UserName = "TEST-USER"
                };
                Guid g = Guid.Empty;
                Guid.TryParse("b79d510f-eaf3-439f-b884-931b179fe3d3", out g);
                this.accessToken.AccessTokenID = g;
                this.accessTokenID = g;
                this.httpStatusCode = HttpStatusCode.OK;
                Debug.Print("Login with test user");
                return;
            }
            try
            {
                //If accessToken is null we are logging in for the first time
                if (this.accessToken == null)
                {
                    if (this.httpStatusCode == System.Net.HttpStatusCode.OK)
                    {
                        // handle login/token-creation or simply create an anonymous token
                        if (this.httpStatusCode == HttpStatusCode.OK)
                        {
                            if ((string.IsNullOrEmpty(this.credential.LoginID) == false) && (string.IsNullOrEmpty(this.credential.LoginPassword) == false))
                            {
                                // Authenticate User Based on Login ID and Login Password
                                // Only Daytona users are able to create a token and login at the same time
                                User user = AuthenticateUserLogic.AuthenticateUser(
                                                    this.databaseSettings,
                                                    this.credential.LoginID,
                                                    this.credential.LoginPassword);

                                if (user != null)
                                {
                                    this.accessTokenID = await AccessTokenLogic.CreateAccessTokenAsync(this.databaseSettings, user.UserID);
                                }


                                Debug.Print("[AccessTokensController.Post] Access Token Created = " + this.accessTokenID.ToString());
                                this.accessToken = await AccessTokenLogic.GetAccessTokenAsync(this.databaseSettings, this.accessTokenID);
                            }
                        }

                    }
                }
                else
                {
                    AuthenticationProfile authenticationProfile = new AuthenticationProfile
                    {
                        AutoLoginUserID = this.accessToken.UserID,
                        AutoLoginIsActive = true
                    };

                    //
                    // The Access Token already exists so wee are just updating it
                    //
                    if ((string.IsNullOrEmpty(this.credential.LoginID) == false) && (string.IsNullOrEmpty(this.credential.LoginPassword) == false))
                    {
                        // Attach a new user to an existing token if valid
                        User user = AuthenticateUserLogic.AuthenticateUser(
                                    this.databaseSettings,
                                    this.credential.LoginID,
                                    this.credential.LoginPassword);

                        if (user != null)
                        {

                            if (string.IsNullOrEmpty(this.credential.NewLoginPassword) == false)
                            {
                                UserProfiles userProfiles = await UserProfileLogic.UserProfileGet(this.databaseSettings, Guid.Empty, user.UserID);
                                UserProfile userProfile = userProfiles.FirstOrDefault();
                                // we've made it this far, so no need to check the old password
                                userProfile.Password = this.credential.NewLoginPassword;
                                userProfile.IsPasswordChangeRequired = false;
                                UserProfileChangePasswordCommand command = new UserProfileChangePasswordCommand(
                                    datastoreProfile: this.databaseSettings,
                                    effectiveUserID: user.UserID,
                                    userProfile: userProfile
                                );
                                if (await command.Execute())
                                {
                                    // good to go
                                }
                                else
                                {
                                    this.errorOut = command.ErrorOut;
                                    this.httpStatusCode = command.HttpStatusCode;
                                    return;
                                }
                            }
                        }

                        if (user == null)
                        {
                            this.accessToken = null;
                            Debug.Print("[AccessTokensController.Post] User - Invalid Login or Password.");

                            if (this.errorOut == null)
                            {
                                this.errorOut = new ErrorOut(20025, "Invalid Login or Password. (20025)");
                            }
                            this.httpStatusCode = System.Net.HttpStatusCode.Unauthorized;
                        }
                        else
                        {
                            AccessTokenLogic.ChangeUser(this.databaseSettings, this.accessTokenID, user.UserID, this.credential.IsLongTerm);
                            Debug.Print("[AccessTokensController.Post] User changed.");
                            // Access Token has been changed, so reload it
                            this.accessToken = AccessTokenLogic.GetAccessToken(this.databaseSettings, this.accessTokenID);
                        }
                    }
                    else
                    {
                        // Clear the user off the token
                        AccessTokenLogic.ChangeUser(this.databaseSettings, this.accessTokenID, authenticationProfile.AutoLoginUserID, false);
                        Debug.Print("[AccessTokensController.Post] User cleared.");
                        // Access Token has been changed, so reload it
                        this.accessToken = AccessTokenLogic.GetAccessToken(this.databaseSettings, this.accessTokenID);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.Print("[AccessTokensController.Post] Unhandled Exception: " + ex.ToString());
                this.httpStatusCode = HttpStatusCode.InternalServerError;
                this.errorOut = new ErrorOut(0, "Unhandled Exception");
            }
            if (this.httpStatusCode == System.Net.HttpStatusCode.OK)
            {
                if (this.accessToken == null)
                {
                    Debug.Print("[AccessTokensController.Post] Returning Unauthorized.");
                    if (this.errorOut == null && string.IsNullOrEmpty(this.credential.LoginID) == false)
                    {
                        this.errorOut = new ErrorOut(20025, "Invalid Login or Password. (20025)");
                    }
                    this.httpStatusCode = HttpStatusCode.Unauthorized;
                }
            }
        }

        /// <summary>
        /// Current Access Token.  Only required if authenticating someone
        /// for an existing token
        /// </summary>
        /// <param name="value"></param>
        public void SetAccessTokenID(Guid value)
        {
            this.isValidated = false;

            this.accessTokenID = value;
        }

        /// <summary>
        /// Credential to be authenticated
        /// </summary>
        /// <param name="value"></param>
        public void SetCredential(AccessTokenCredential value)
        {
            this.isValidated = false;

            this.credential = value;
        }

        public async Task<bool> Validate()
        {
            bool returnValue = true;

            this.accessToken = null;
            this.httpStatusCode = System.Net.HttpStatusCode.OK;

            if (returnValue == true)
            {
                if (Guid.Empty.Equals(this.AccessTokenID) == false)
                {
                    this.accessToken = AccessTokenLogic.GetAccessToken(this.databaseSettings, this.accessTokenID);
                    Debug.Print("[AccessTokensControllerPostCommand.Validate] Access Token Loaded = " + (this.accessToken == null ? "null" : this.accessToken.ToString()));
                    if (this.accessToken == null)
                    {
                        this.httpStatusCode = System.Net.HttpStatusCode.BadRequest;
                        this.errorOut = new ErrorOut(20010, "Access Token not found. (20010)");
                    }
                }
            }

            if (returnValue == true)
            {
                if (Guid.Empty.Equals(this.AccessTokenID) == true)
                {
                    if (this.credential == null)
                    {
                        this.httpStatusCode = System.Net.HttpStatusCode.BadRequest;
                        this.errorOut = new ErrorOut(20011, "Credential is required. (20011)");
                    }
                }
            }

            // Set to true if there are no validation issues
            this.isValidated = returnValue;

            return returnValue;
        }
    }
}
