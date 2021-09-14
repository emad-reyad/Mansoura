using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization; 

namespace Mansoura.Model
{
    public class Members
    {
        [JsonPropertyName("items")]
        public Member[] MemberList { get; set; }
    }
    public class Member
    {
        [JsonPropertyName("owner")]
        public Owner Owner { get; set; }
        [JsonPropertyName("is_accepted")]
        public bool IsAccepted { get; set; }
        [JsonPropertyName("score")]
        public Int16 Score { get; set; }
        [JsonPropertyName("last_activity_date")]
        public long LastActivityDate { get; set; }
        private DateTime _LastActivityDateFormated;

        public DateTime LastActivityDateFormated
        {
            get { return new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds(LastActivityDate); }
            private set { _LastActivityDateFormated = value; }
        }

        [JsonPropertyName("last_edit_date")]
        public long LastEditDate { get; set; }
        [JsonPropertyName("creation_date")]
        public long CreationDate { get; set; }
        [JsonPropertyName("answer_id")]
        public int AnswerID { get; set; }
        [JsonPropertyName("question_id")]
        public int QuestionID { get; set; }
        [JsonPropertyName("content_license")]
        public string ContentLicense { get; set; }
        public int[] Rating { get; set; }
        //public override string ToString() => JsonSerializer.Serialize<Item>(this);
    }
}
