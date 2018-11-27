using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CharacterSheetWebAPI.Contracts
{
    [DataContract(Namespace = "")]
    public class Trait
    {
        [DataMember(EmitDefaultValue = false)]
        public int TraitID { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string Name { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string SpecialtyName { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string Specialty { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string Traits { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string Ideal { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string Bond { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string Flaw { get; set; }
    }
}
