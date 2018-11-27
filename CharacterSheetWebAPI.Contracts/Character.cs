using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CharacterSheetWebAPI.Contracts
{
    [DataContract(Namespace = "")]
    public class Character
    {
        [DataMember(EmitDefaultValue = false)]
        public Guid CharacterID { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public Guid UserID { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string Name { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string ShareCode { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public int STR { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public int DEX { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public int CON { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public int WIS { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public int INT { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public int CHA { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string Alignment { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string ImageURL { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string EyeColor { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string HairColor { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string Height { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string Weight { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string Biography { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public int TraitID { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public Trait Trait { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public int ClassID { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public Class Class { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public int RaceID { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public Race Race { get; set; }
    }
}
