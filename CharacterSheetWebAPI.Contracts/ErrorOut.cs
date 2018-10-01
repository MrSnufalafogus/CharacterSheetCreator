using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CharacterSheetWebAPI.Contracts
{
    [DataContract(Namespace = "")]
    public class ErrorOut
    {
        public ErrorOut()
        {
        }

        public ErrorOut(int messageID, string messageText)
        {
            this.MessageID = messageID;
            this.MessageText = messageText;
        }

        /// <summary>
        /// Gets or sets a value that identifies the error message
        /// </summary>
        [DataMember]
        public int MessageID { get; set; }

        /// <summary>
        /// Gets or sets the localized error messages
        /// </summary>
        [DataMember]
        public string MessageText { get; set; }

        public override string ToString()
        {
            return "@" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name + " : { "
                + "\"MessageID\" : " + this.MessageID.ToString() + ", "
                + "\"MessageText\" : " + (this.MessageText == null ? "null" : "\"" + this.MessageText + "\"") + "}";
        }
    }
}
