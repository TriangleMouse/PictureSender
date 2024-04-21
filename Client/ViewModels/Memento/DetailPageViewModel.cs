using PictureSender.Client.ViewModels.Memento;
using PictureSender.Shared.ViewModels;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PictureSender.Client.ViewModels
{
    public class DetailPageViewModel : INotifyPropertyChanged
    {
        #region Fields

        private bool _isEditForm = true;
        private Visibility _editFormVisibility;
        private PictureDetail _detail;

        #endregion

        #region Propertyes

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

        #endregion

        #region Commands

        public ICommand EditCommand { get; private set; }
        public ICommand BackCommand { get; private set; }
        public ICommand CancelCommand { get; private set; }
        public ICommand SaveCommand { get; private set; }

        #endregion


        public DetailPageViewModel()
        {
            EditCommand = new RelayCommand(async () => await Edit());
            BackCommand = new RelayCommand(async () => await Back());
            CancelCommand = new RelayCommand(async () => await Cancel());
            SaveCommand = new RelayCommand(async () => await Save());
        }

        #region Actions

        /// <summary>
        /// Открывает доступ к редактированию
        /// </summary>
        private async Task Edit()
        {
            IsEditForm = !IsEditForm;
        }

        /// <summary>
        /// Возвращает пользователя на главную форму
        /// </summary>
        private async Task Back()
        {
            var frame = Application.Current.MainWindow.FindName("MainFrame") as Frame;

            if (frame != null && frame.CanGoBack)
            {
                frame.GoBack();
            }
        }

        /// <summary>
        /// Отменяет процесс редактирования или возвращает на главную форму
        /// </summary>
        private async Task Cancel()
        {
            if (!Detail.Id.HasValue)
            {
                await Back();
                return;
            }

            RestoreState();
            IsEditForm = false;
        }

        /// <summary>
        /// Сохраняет состояние основного объекта
        /// </summary>
        /// <param name="state">Детализация картинки</param>
        private void SaveState(PictureDetail state)
        {
            DetailMemento = new PictureDetailMemento(state);
        }

        /// <summary>
        /// Востанавливает состояние объекта
        /// </summary>
        private void RestoreState()
        {
            if (DetailMemento != null)
            {
                Detail = DetailMemento.State;
                DetailMemento = null;
            }
        }

        /// <summary>
        /// Выполняет процесс сохранения(добавление\редактирования) объекта 
        /// </summary>
        /// <returns></returns>
        private async Task Save()
        {
            IsEditForm = false;
        }

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
