using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CharacterSheetWebAPI.Contracts
{
    [DataContract(Namespace = "")]
    public class Race
    {
        [DataMember(EmitDefaultValue = false)]
        public int RaceID { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string Name { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string RaceImage { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string Description { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public ASIncreases ASIncrease { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string AgeRange { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string Size { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string Speed { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string Languages { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string Subtypes { get; set; }
    }
}
