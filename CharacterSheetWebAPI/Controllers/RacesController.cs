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
    public class RacesController : ApiController
    {
        [Route("api/Races")]
        [HttpGet]
        [ResponseType(typeof(Races))]
        public HttpResponseMessage GetRaces()
        {
            HttpResponseMessage returnValue = null;
            Races races = null;
            DatabaseSettings databaseSettings = new DatabaseSettings();

            if (databaseSettings == null)
            {
                returnValue = this.Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            else
            {
                races = RacesLogic.GetRaces(databaseSettings);
                Debug.Print("[CharactersController.Get] Character Loaded = " + (races == null ? "null" : races.ToString()));

                if (races == null)
                {
                    returnValue = this.Request.CreateResponse(HttpStatusCode.NotFound);
                }
                else
                {
                    returnValue = this.Request.CreateResponse<Races>(HttpStatusCode.OK, races);
                }
            }

            return returnValue;
        }
    }
}