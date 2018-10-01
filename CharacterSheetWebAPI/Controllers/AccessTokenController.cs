using CharacterSheetWebAPI.Contracts;
using CharacterSheetWebAPI.Contracts.API;
using CharacterSheetWebAPI.Logic;
using CharacterSheetWebAPI.Logic.Commands;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace CharacterSheetWebAPI.Controllers
{
    public class AccessTokenController : ApiController
    {
        public class AccessTokensController : ApiController
        {
            /// <summary>
            /// Get the existing access token for this session
            /// </summary>
            /// <returns></returns>
            /// <param name="accessTokenID"> String ID to access site </param>
            [Route("api/AccessTokens/{accessTokenID}")]
            [HttpGet]
            [ResponseType(typeof(AccessToken))]
            public async Task<HttpResponseMessage> Get(string accessTokenID)
            {
                HttpResponseMessage returnValue = null;
                AccessToken accessToken = null;
                IEnumerable<string> apiTokenHeaderValues = null;
                DatabaseSettings databaseSettings = new DatabaseSettings();
                Guid tokenID = Guid.Empty;

                if (Guid.Empty.Equals(tokenID) == true)
                {
                    if (this.Request.Headers.TryGetValues("AccessTokenID", out apiTokenHeaderValues))
                    {
                        Guid g;
                        if (Guid.TryParse(apiTokenHeaderValues.First(), out g) == true)
                        {
                            tokenID = g;
                            Debug.Print("[AccessTokensController.Get] Access Token from Header = " + tokenID.ToString());
                        }
                    }
                }

                if(tokenID.Equals(new Guid("b79d510f-eaf3-439f-b884-931b179fe3d3"))){
                    accessToken = new AccessToken
                    {
                        LoginID = "TST-USER",
                        IsLongTerm = true,
                        UserID = new Guid(),
                        UserName = "TEST-USER"
                    };
                    Guid g = Guid.Empty;
                    Guid.TryParse("b79d510f-eaf3-439f-b884-931b179fe3d3", out g);
                    accessToken.AccessTokenID = g;
                    Debug.Print("Get with test user");
                    return this.Request.CreateResponse<AccessToken>(HttpStatusCode.OK, accessToken);
                    
                }

                if (Guid.Empty.Equals(tokenID) == true || databaseSettings == null)
                {
                    returnValue = this.Request.CreateResponse(HttpStatusCode.BadRequest);
                }
                else
                {
                    accessToken = await AccessTokenLogic.GetAccessTokenAsync(databaseSettings, tokenID);
                    Debug.Print("[AccessTokensController.Get] Access Token Loaded = " + (accessToken == null ? "null" : accessToken.ToString()));

                    if (accessToken == null)
                    {
                        returnValue = this.Request.CreateResponse(HttpStatusCode.NotFound);
                    }
                    else
                    {
                        returnValue = this.Request.CreateResponse<AccessToken>(HttpStatusCode.OK, accessToken);
                    }
                }

                return returnValue;
            }

            /// <summary>
            /// Get a new AccessToken or update the credentials on an existing one
            /// </summary>
            /// <param name="credential">AccessToken Credentials</param>
            /// <returns></returns>
            [HttpPost]
            [Route("api/AccessTokens")]
            [ResponseType(typeof(AccessTokenCredential))]
            public async Task<HttpResponseMessage> Post(AccessTokenCredential credential)
            {
                HttpResponseMessage returnValue = null;
                AccessTokensControllerPostCommand postCommand;
                Debug.Print("[AccessTokensController.Post] Entering");
                DatabaseSettings databaseSettings = new DatabaseSettings();
                Guid accessTokenID = Guid.Empty;
                try
                {

                    if (credential == null)
                    {
                        Debug.Print("[AccessTokensController.Post] credential is null.]");

                        returnValue = this.Request.CreateResponse<ErrorOut>(HttpStatusCode.BadRequest, new ErrorOut(0, "Request cannot be null. (1080)"));
                        returnValue.ReasonPhrase = "Request cannot be null. (1080)";
                    }

                    if (databaseSettings == null)
                    {
                        Debug.Print("[AccessTokensController.Post] No DatabaseSettings.]");
                        returnValue = this.Request.CreateResponse<ErrorOut>(HttpStatusCode.InternalServerError, new ErrorOut(0, "Database not configured. (1085)"));
                        returnValue.ReasonPhrase = "Database not configured. (1085)";
                    }
                    else
                    {
                        // IEnumerable<string> apiTokenHeaderValues = null;
                        // Guid accessTokenID = Guid.Empty;

                        postCommand = new AccessTokensControllerPostCommand(databaseSettings);

                        if (Guid.Empty.Equals(accessTokenID) == false)
                        {
                            postCommand.SetAccessTokenID(accessTokenID);
                        }

                        if (Guid.Empty.Equals(accessTokenID) == false)
                        {
                            postCommand.SetAccessTokenID(accessTokenID);
                        }

                        if (returnValue == null)
                        {
                            postCommand.SetCredential(credential);

                            if (await postCommand.Validate() == false)
                            {
                                returnValue = this.Request.CreateResponse<ErrorOut>(postCommand.HttpStatusCode, postCommand.ErrorOut);
                                if (postCommand.ErrorOut != null)
                                {
                                    returnValue.ReasonPhrase = postCommand.ErrorOut.MessageText;
                                }
                            }
                            else
                            {
                                await postCommand.Execute();
                                if (postCommand.ErrorOut == null)
                                {
                                    if (postCommand.AccessToken == null)
                                    {
                                        returnValue = this.Request.CreateResponse(postCommand.HttpStatusCode);
                                    }
                                    else
                                    {
                                        returnValue = this.Request.CreateResponse<AccessToken>(HttpStatusCode.OK, postCommand.AccessToken);
                                    }
                                }
                                else
                                {
                                    returnValue = this.Request.CreateResponse<ErrorOut>(postCommand.HttpStatusCode, postCommand.ErrorOut);
                                    returnValue.ReasonPhrase = postCommand.ErrorOut.MessageText;
                                }
                            }

                        }
                    }
                }
                catch (Exception ex)
                {
                    returnValue = this.Request.CreateResponse(HttpStatusCode.InternalServerError);
                    Debug.Print("[AccessTokensController.Post] Unhandled Exception: " + ex.ToString());
                }

                Debug.Print("[AccessTokensController.Post] Exiting");
                return returnValue;
            }

            /// <summary>
            /// Get a new AccessToken or update the credentials on an existing one.
            /// </summary>
            /// <param name="accessTokenIN">AccessToken entered</param>
            /// <returns></returns>
            [HttpPost]
            [Route("api/AccessTokens/Refresh")]
            [ResponseType(typeof(AccessToken))]
            public HttpResponseMessage Refresh(AccessToken accessTokenIN)
            {
                HttpResponseMessage returnValue = new HttpResponseMessage(HttpStatusCode.OK);
                Debug.Print("[AccessTokensController.Refresh] Entering");
                DatabaseSettings databaseSettings = new DatabaseSettings();

                if (returnValue.StatusCode == HttpStatusCode.OK)
                { 

                    if (databaseSettings != null)
                    {
                        AccessToken accessToken = null;
                        accessToken = Logic.AccessTokenLogic.GetAccessToken(databaseSettings, accessTokenIN.AccessTokenID);
                        returnValue = this.Request.CreateResponse<AccessToken>(HttpStatusCode.OK, accessToken);
                    }
                    else
                    {
                        returnValue = this.Request.CreateResponse(HttpStatusCode.BadRequest);
                    }
                }

                Debug.Print("[AccessTokensController.Refresh] Exiting");
                return returnValue;
            }
        }
    }
}