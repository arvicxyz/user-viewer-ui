using System.Text.Json.Serialization;

namespace XamApp.Models.Dtos
{
    public class UserModel
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("imageUrl")]
        public string ImageUrl { get; set; }
    }
}
