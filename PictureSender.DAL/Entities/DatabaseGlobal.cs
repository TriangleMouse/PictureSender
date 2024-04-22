using System.Text.Json.Serialization;

namespace PictureSender.DAL.Entities
{
    public class DatabaseGlobal
    {
        [JsonPropertyName("PictureDetails")] 
        public List<PictureDetail> PictureDetails { get; set; } = new();

        [JsonPropertyName("TotalId")]
        public int TotalId { get; set; }
    }
}
