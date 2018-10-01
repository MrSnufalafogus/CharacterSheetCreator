using CharacterSheetWebAPI.Contracts;
using CharacterSheetWebAPI.Contracts.API;
using CharacterSheetWebAPI.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
using System.Web;
using CharacterSheetWebAPI.Logic.Helpers;
using System.Security.Claims;
using System.Diagnostics;

namespace CharacterSheetWebAPI.Helpers
{
    public class AccessTokenAuthenticationHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            try
            {
                IEnumerable<string> apiTokenHeaderValues = null;
                Guid accessTokenID = Guid.Empty;
                DatabaseSettings databaseSettings = new DatabaseSettings();

                if (request.Headers.TryGetValues("AccessTokenID", out apiTokenHeaderValues))
                {
                    Guid.TryParse(apiTokenHeaderValues.First(), out accessTokenID);
                }

                if (Guid.Empty.Equals(accessTokenID) == true)
                {
                    Debug.Print("No Access Token");
                }


                if (Guid.Empty.Equals(accessTokenID) == false)
                {
                    AccessToken accessToken;

                    accessToken = await AccessTokenLogic.GetAccessTokenAsync(databaseSettings, accessTokenID);

                    if (accessToken != null)
                    {
                        ProjectIdentity identity;

                        identity = new ProjectIdentity(accessToken, "AccessToken", databaseSettings);

                        if (identity != null)
                        {
                            var principal = new ClaimsPrincipal(identity);

                            //Thread.CurrentPrincipal = principal;
                            request.GetRequestContext().Principal = principal;

                            // Update the last access date and time in the background
                            ThreadPool.QueueUserWorkItem(o =>
                            {
                                try
                                {
                                    AccessTokenLogic.UpdateLastAccessDateTime(databaseSettings, accessTokenID);
                                }
                                catch (Exception ex)
                                {
                                    Debug.Print(ex.ToString());
                                }
                            });
                        }
                    }
                }
                return await base.SendAsync(request, cancellationToken);
            }
            catch (Exception ex)
            {
                Debug.Print(ex.ToString());
                return new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError);
            }
        }
    }
}