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
    public class ClassesController : ApiController
    {
        [Route("api/Classes")]
        [HttpGet]
        [ResponseType(typeof(Classes))]
        public HttpResponseMessage GetClasses()
        {
            HttpResponseMessage returnValue = null;
            Classes classes = null;
            DatabaseSettings databaseSettings = new DatabaseSettings();

            if (databaseSettings == null)
            {
                returnValue = this.Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            else
            {
                classes = ClassesLogic.GetClasses(databaseSettings);
                Debug.Print("[CharactersController.Get] Character Loaded = " + (classes == null ? "null" : classes.ToString()));

                if (classes == null)
                {
                    returnValue = this.Request.CreateResponse(HttpStatusCode.NotFound);
                }
                else
                {
                    returnValue = this.Request.CreateResponse<Classes>(HttpStatusCode.OK, classes);
                }
            }

            return returnValue;
        }
    }
}