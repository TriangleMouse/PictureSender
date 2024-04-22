namespace PictureSender.Shared.CQRS.Queries.Response
{
    public class GetAllPictureDetailQueryResponse
    {
        public int? Id { get; set; }
        public string Description { get; set; }
        public byte[] PictureContent { get; set; }
    }
}
