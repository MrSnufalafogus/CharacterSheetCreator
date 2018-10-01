﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CharacterSheetWebAPI.Contracts
{
    [DataContract(Namespace = "")]
    public class User
    {
        [DataMember(EmitDefaultValue = false)]
        public Guid UserID { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string LoginID { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string Name { get; set; }
    }
}
