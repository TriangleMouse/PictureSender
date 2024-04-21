using PictureSender.Client.ViewModels.Memento;
using PictureSender.Shared.ViewModels;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace PictureSender.Client.ViewModels
{
    public class DetailPageViewModel : INotifyPropertyChanged
    {

        private bool _isEditForm = true;
        private Visibility _editFormVisibility;

        private PictureDetail _detail;

        private PictureDetailMemento DetailMemento { get; set; }

        public bool IsEditForm
        {
            get => _isEditForm;
            set
            {
                if (Detail != default && value)
                    SaveState(Detail);
                else if (Detail != default && !value)
                    RestoreState();

                _isEditForm = value;
                EditFormVisibility = value ? Visibility.Visible : Visibility.Collapsed;
                OnPropertyChanged();
            }
        }

        public Visibility EditFormVisibility
        {
            get { return _editFormVisibility; }
            set
            {
                _editFormVisibility = value;
                OnPropertyChanged();
            }
        }

        public PictureDetail Detail
        {
            get => _detail;
            set
            {
                _detail = value;
                OnPropertyChanged();
            }
        }

        public DetailPageViewModel()
        {

        }

        private void SaveState(PictureDetail state)
        {
            DetailMemento = new PictureDetailMemento(state);
        }

        private void RestoreState()
        {
            if (DetailMemento != null)
            {
                Detail = DetailMemento.State;
                DetailMemento = null;
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
