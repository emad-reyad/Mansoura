using System.Text.Json.Serialization; 

namespace Mansoura.Model
{
    public class Owner
    {
        [JsonPropertyName("reputation")]
        public int Reputation { get; set; }
        [JsonPropertyName("user_id")]
        public int UserId { get; set; }
        [JsonPropertyName("user_type")]
        public string UserType { get; set; }
        [JsonPropertyName("profile_image")]
        public string ProfileImage { get; set; }
        [JsonPropertyName("display_name")]
        public string DisplayName { get; set; }
        [JsonPropertyName("link")]
        public string Link { get; set; }
    }
}
