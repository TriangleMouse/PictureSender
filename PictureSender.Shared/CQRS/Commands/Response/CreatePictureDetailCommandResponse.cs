namespace PictureSender.Shared.CQRS.Commands.Response
{
    public class CreatePictureDetailCommandResponse
    {
        public bool IsSuccess { get; set; }
        public int CreatedBookId { get; set; }
    }
}
