using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CharacterSheetWebAPI.Contracts
{
    [DataContract(Namespace = "")]
    public class ASIncrease
    {
        [DataMember(EmitDefaultValue = false)]
        public string Type { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string Code { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public int Amount { get; set; }
    }
}
