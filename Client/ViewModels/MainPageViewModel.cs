using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using PictureSender.Shared.ViewModels;
using System.Windows.Input;
using PictureSender.Client.Pages;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;
using System.Windows.Data;
using System.Windows.Media;

namespace PictureSender.Client.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        #region Services

        private readonly IServiceProvider _provider;

        #endregion
        #region Fields



        #endregion

        #region Properties



        #endregion

        #region Commands
        public ICommand LoadDataCommand { get; set; }
        public ICommand AddCommand { get; private set; }
        public ICommand ViewCommand { get; private set; }
        public ICommand EditCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }

        #endregion

        public MainPageViewModel(IServiceProvider provider)
        {
            _provider = provider;


            LoadDataCommand = new RelayCommand(async () => await LoadData());
            AddCommand = new RelayCommand(async () => await Add());
            ViewCommand = new RelayCommand<PictureDetail>(async (message) => await View(message));
            EditCommand = new RelayCommand<PictureDetail>(async (message) => await Edit(message));
            DeleteCommand = new RelayCommand<PictureDetail>(async (message) => await Delete(message));

        }

        #region Actions

        /// <summary>
        /// Загружает данные в таблицу
        /// </summary>
        public async Task LoadData()
        {
            //IEnumerable<ExternalRecipientDto> externalRecipients = await _externalRecipientService.GetExternalRecipients();
            //IEnumerable<OutboxMessageDto> messagesDto = await _outboxMessageService.GetOutboxMessages();
            //IEnumerable<OutboxMessageModel> messages = _mapper.Map<IEnumerable<OutboxMessageDto>, IEnumerable<OutboxMessageModel>>(messagesDto);

            //foreach (var outboxMessageModel in messages)
            //{
            //    outboxMessageModel.NameExternalRecipient = externalRecipients.FirstOrDefault(externalRecipient =>
            //        externalRecipient.Id == outboxMessageModel.ExternalRecipientId).Name;
            //}

            //Messages = new ObservableCollection<OutboxMessageModel>(messages);
            //MessagesView = CollectionViewSource.GetDefaultView(Messages);
            //MessagesView.Filter = FilterMessages;
            //Years = FillYearsFilter(messagesDto);
            //Months = FillMonthsFilter();
        }

        /// <summary>
        /// Открывает форму на добавление данных
        /// </summary>
        private async Task Add()
        {
            var frame = Application.Current.MainWindow.FindName("MainFrame") as Frame;
            if (frame != null)
            {
                var dataPage = _provider.GetService<DetailPage>();

                frame.Navigate(dataPage);
            }

        }

        /// <summary>
        /// Открывает форму на просмотр
        /// </summary>
        /// <param name="detail">Запись из таблицы</param>
        private async Task View(PictureDetail detail)
        {
            //var dataViewModel = _provider.GetRequiredService<DataViewModel>();
            //dataViewModel.Message = message;
            //dataViewModel.IsEditForm = false;
            //var dataPage = _provider.GetRequiredService<DataPage>();

            //var frame = Application.Current.MainWindow.FindName("MainFrame") as Frame;
            //if (frame != null)
            //{
            //    dataPage.DataContext = dataViewModel;

            //    frame.Navigate(dataPage);
            //}
        }


        /// <summary>
        /// Открывает форму на редактирование
        /// </summary>
        /// <param name="detail">Запись из таблицы</param>
        private async Task Edit(PictureDetail detail)
        {
            //var dataViewModel = _provider.GetRequiredService<DataViewModel>();
            //dataViewModel.Message = message;
            //dataViewModel.IsEditForm = true;
            //var dataPage = _provider.GetRequiredService<DataPage>();

            //var frame = Application.Current.MainWindow.FindName("MainFrame") as Frame;
            //if (frame != null)
            //{
            //    dataPage.DataContext = dataViewModel;

            //    frame.Navigate(dataPage);
            //}
        }

        /// <summary>
        /// Удаляет запись
        /// </summary>
        /// <param name="detail">Запись из таблицы</param>
        private async Task Delete(PictureDetail detail)
        {
            //if (MessageBox.Show("Вы уверены, что хотите удалить выбранную запись?", "Внимание!", MessageBoxButton.YesNo) == MessageBoxResult.No)
            //    return;

            //await _outboxMessageService.DeleteOutboxMessageById(message.Id.Value);
            //_baseService.Commit();
            //Messages.Remove(message);
        }


        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
