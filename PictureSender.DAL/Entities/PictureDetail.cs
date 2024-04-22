using System.Text.Json.Serialization;

namespace PictureSender.DAL.Entities
{
    public class PictureDetail
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [JsonPropertyName("Description")]
        public string Description { get; set; }

        [JsonPropertyName("PathToImage")]
        public string PathToImage { get; set; }
    }
}
