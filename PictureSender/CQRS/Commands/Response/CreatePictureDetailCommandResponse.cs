namespace PictureSender.Server.CQRS.Commands.Response
{
    public class CreatePictureDetailCommandResponse
    {
        public bool IsSuccess { get; set; }
        public int CreatedBookId { get; set; }
    }
}
