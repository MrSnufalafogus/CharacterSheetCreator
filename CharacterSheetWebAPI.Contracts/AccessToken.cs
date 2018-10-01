using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CharacterSheetWebAPI.Contracts
{
    [DataContract(Namespace = "")]
    public class AccessToken
    {

        [DataMember(EmitDefaultValue = false)]
        public Guid AccessKeyID
        {
            get; set;
        }

        [DataMember(EmitDefaultValue = false)]
        public Guid AccessTokenID
        {
            get; set;
        }

        [DataMember(EmitDefaultValue = false)]
        public Guid AuthenticationID
        {
            get; set;
        }

        [DataMember(EmitDefaultValue = false)]
        public Guid UserID
        {
            get; set;
        }

        [DataMember(EmitDefaultValue = false)]
        public DateTime? LastAccessDateTime
        {
            get; set;
        }

        [DataMember(EmitDefaultValue = false)]
        public string LoginID
        {
            get; set;
        }

        [DataMember(EmitDefaultValue = false)]
        public string UserName
        {
            get; set;
        }

        [DataMember]
        public bool IsLongTerm
        {
            get; set;
        }


        public AccessToken Clone()
        {
            return (AccessToken)this.MemberwiseClone();
        }

        public void Update(AccessToken other)
        {
            this.AccessKeyID = other.AccessKeyID;
            this.AccessTokenID = other.AccessTokenID;
            this.AuthenticationID = other.AuthenticationID;
            this.LastAccessDateTime = other.LastAccessDateTime;
            this.LoginID = other.LoginID;
            this.UserName = other.UserName;
        }

        public override string ToString()
        {
            System.Text.StringBuilder returnValue = new System.Text.StringBuilder();

            returnValue.Append("@");
            returnValue.Append(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);
            returnValue.Append(" : {");

            returnValue.Append("\"AccessKeyID\" : ");
            returnValue.Append(this.AccessKeyID == null ? "null" : "\"" + this.AccessKeyID + "\"");
            returnValue.Append(", ");

            returnValue.Append("\"AccessTokenID\" : ");
            returnValue.Append(this.AccessTokenID == null ? "null" : "\"" + this.AccessTokenID + "\"");
            returnValue.Append(", ");

            returnValue.Append("\"AuthenticationID\" : ");
            returnValue.Append(this.AuthenticationID == null ? "null" : "\"" + this.AuthenticationID + "\"");
            returnValue.Append(", ");

            returnValue.Append("\"LastAccessDateTime\" : ");
            returnValue.Append(this.LastAccessDateTime.HasValue == true ? "\"" + this.LastAccessDateTime.Value.ToString("O") + "\"" : "null");
            returnValue.Append(", ");

            returnValue.Append("\"LoginID\" : ");
            returnValue.Append(this.LoginID == null ? "null" : "\"" + this.LoginID + "\"");
            returnValue.Append(", ");

            returnValue.Append("\"UserID\" : ");
            returnValue.Append("\"" + this.UserID.ToString() + "\"");
            returnValue.Append(", ");

            returnValue.Append("\"UserName\" : ");
            returnValue.Append(this.UserName == null ? "null" : "\"" + this.UserName + "\"");
            returnValue.Append(", ");

            return returnValue.ToString();
        }
    }
}
