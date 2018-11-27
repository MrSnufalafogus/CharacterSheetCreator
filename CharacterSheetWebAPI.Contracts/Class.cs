using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CharacterSheetWebAPI.Contracts
{
    [DataContract(Namespace = "")]
    public class Class
    {
        [DataMember(EmitDefaultValue = false)]
        public int ClassID { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string Name { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string ClassImage { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string Description { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string HitDie { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string PrimaryAbility { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string SavingThrows { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string ArmorProf { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string WeaponProf { get; set; }
    }
}
