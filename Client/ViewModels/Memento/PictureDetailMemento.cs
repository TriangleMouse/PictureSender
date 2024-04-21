using PictureSender.Shared.ViewModels;

namespace PictureSender.Client.ViewModels.Memento
{
    public class PictureDetailMemento
    {
        public PictureDetail State { get; private set; }

        public PictureDetailMemento(PictureDetail detail)
        {
            State = new PictureDetail()
            {
                Id = detail.Id,
                Description = detail.Description,
                PictureContent = detail.PictureContent
            };
        }
    }
}
