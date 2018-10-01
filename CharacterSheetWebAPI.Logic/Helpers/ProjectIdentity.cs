using CharacterSheetWebAPI.Contracts;
using CharacterSheetWebAPI.Contracts.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CharacterSheetWebAPI.Logic.Helpers
{
    public class ProjectIdentity : ClaimsIdentity
    {
        public ProjectIdentity(AccessToken accessToken, string type, DatabaseSettings databaseSettings)
           : base("Application")
        {
            this.AccessToken = accessToken;
            this.DatabaseSettings = databaseSettings;

            if (string.IsNullOrEmpty(this.AccessToken.LoginID) == false)
            {
                AddClaim(new Claim(ClaimTypes.Name, accessToken.LoginID));
            }
        }

        public AccessToken AccessToken { get; private set; }

        public DatabaseSettings DatabaseSettings { get; private set; }

    }
}
