using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CharacterSheetWebAPI.Contracts
{
    [DataContract(Namespace = "")]
    public class AuthenticationProfile
    {
        [DataMember(EmitDefaultValue = false)]
        public bool AutoLoginIsActive { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public Guid AutoLoginUserID { get; set; }
    }
}
