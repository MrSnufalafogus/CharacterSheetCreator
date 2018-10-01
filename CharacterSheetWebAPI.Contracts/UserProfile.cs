using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CharacterSheetWebAPI.Contracts
{
    [DataContract(Namespace = "")]
    public class UserProfile
    {

        [DataMember]
        public Guid UserID { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string MobilePhone { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string LoginID { get; set; }

        [DataMember]
        public bool HasLoggedIn { get; set; }
        [DataMember]
        public bool IsLoginAllowed { get; set; }
        [DataMember]
        public bool IsPasswordChangeRequired { get; set; }
        [IgnoreDataMember]
        public string LoginPasswordHash1 { get; set; }
        [DataMember]
        public DateTime LastSuccessfulLoginDateTime { get; set; }

        [DataMember]
        public string Name
        {
            get
            {
                return (this.LastName ?? string.Empty) + ", " + (this.FirstName ?? string.Empty);
            }
        }

    }
}
