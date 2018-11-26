using CharacterSheetWebAPI.Contracts;
using CharacterSheetWebAPI.Contracts.API;
using CharacterSheetWebAPI.Logic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace CharacterSheetWebAPI.Controllers
{
    public class TraitsController : ApiController
    {
        [Route("api/Traits")]
        [HttpGet]
        [ResponseType(typeof(Traits))]
        public HttpResponseMessage GetTraits()
        {
            HttpResponseMessage returnValue = null;
            Traits traits = null;
            DatabaseSettings databaseSettings = new DatabaseSettings();

            if (databaseSettings == null)
            {
                returnValue = this.Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            else
            {
                traits = TraitsLogic.GetTraits(databaseSettings);
                Debug.Print("[CharactersController.Get] Character Loaded = " + (traits == null ? "null" : traits.ToString()));

                if (traits == null)
                {
                    returnValue = this.Request.CreateResponse(HttpStatusCode.NotFound);
                }
                else
                {
                    returnValue = this.Request.CreateResponse<Traits>(HttpStatusCode.OK, traits);
                }
            }

            return returnValue;
        }
    }
}