using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CharacterSheetWebAPI.Contracts
{
    [DataContract(Namespace = "")]
    public class AccessTokenCredential
    {
        public const string CredentialTypeCodeUser = "User";

        [DataMember(EmitDefaultValue = false)]
        public string CredentialTypeCode { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public Guid AccessKeyID { get; set; }

        public bool CredentialTypeIsUser
        {
            get
            {
                return CredentialTypeCodeUser.Equals(this.CredentialTypeCode, StringComparison.OrdinalIgnoreCase);
            }
        }

        [DataMember(EmitDefaultValue = false)]
        public string LoginID { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string LoginPassword { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string NewLoginPassword { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string ReferrerUrl { get; set; }

        [DataMember]
        public bool IsLongTerm { get; set; }
    }
}
