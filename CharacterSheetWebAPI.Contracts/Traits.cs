using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CharacterSheetWebAPI.Contracts
{
    [CollectionDataContract(Namespace = "")]
    public class Traits : System.Collections.Generic.List<Trait>
    {

    }
}
