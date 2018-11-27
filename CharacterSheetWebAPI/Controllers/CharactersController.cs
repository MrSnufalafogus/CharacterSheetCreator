using CharacterSheetWebAPI.Contracts;
using CharacterSheetWebAPI.Contracts.API;
using CharacterSheetWebAPI.Logic;
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

    public class CharactersController : ApiController
    {

        [Route("api/Characters/{characterID}")]
        [HttpGet]
        [ResponseType(typeof(Character))]
        public HttpResponseMessage Get(Guid characterID)
        {
            HttpResponseMessage returnValue = null;
            Character character = null;
            DatabaseSettings databaseSettings = new DatabaseSettings();


            if (Guid.Empty.Equals(characterID) == true || databaseSettings == null)
            {
                returnValue = this.Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            else
            {
                character = CharactersLogic.GetCharacter(databaseSettings, characterID);
                Debug.Print("[CharactersController.Get] Character Loaded = " + (character == null ? "null" : character.ToString()));

                if (character == null)
                {
                    returnValue = this.Request.CreateResponse(HttpStatusCode.NotFound);
                }
                else
                {
                    returnValue = this.Request.CreateResponse<Character>(HttpStatusCode.OK, character);
                }
            }

            return returnValue;
        }

        [Route("api/Characters/User")]
        [HttpGet]
        [ResponseType(typeof(Characters))]
        public HttpResponseMessage GetCharacters(Guid userID)
        {
            HttpResponseMessage returnValue = null;
            Characters character = null;
            DatabaseSettings databaseSettings = new DatabaseSettings();


            if (Guid.Empty.Equals(userID) == true || databaseSettings == null)
            {
                returnValue = this.Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            else
            {
                character = CharactersLogic.GetCharacters(databaseSettings, userID);
                Debug.Print("[CharactersController.Get] Character Loaded = " + (character == null ? "null" : character.ToString()));

                if (character == null)
                {
                    returnValue = this.Request.CreateResponse(HttpStatusCode.NotFound);
                }
                else
                {
                    returnValue = this.Request.CreateResponse<Characters>(HttpStatusCode.OK, character);
                }
            }

            return returnValue;
        }

        [Route("api/Characters/ShareCode")]
        [HttpGet]
        [ResponseType(typeof(Character))]
        public HttpResponseMessage GetCharacterByShareCode(string shareCode)
        {
            HttpResponseMessage returnValue = null;
            Character character = null;
            DatabaseSettings databaseSettings = new DatabaseSettings();

            if (string.Empty.Equals(shareCode) == true || databaseSettings == null)
            {
                returnValue = this.Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            else
            {
                character = CharactersLogic.GetCharacterByShare(databaseSettings, shareCode);
                Debug.Print("[CharactersController.Get] Character Loaded = " + (character == null ? "null" : character.ToString()));

                if (character == null)
                {
                    returnValue = this.Request.CreateResponse(HttpStatusCode.NotFound);
                }
                else
                {
                    returnValue = this.Request.CreateResponse<Character>(HttpStatusCode.OK, character);
                }
            }

            return returnValue;
        }
    }
}