using PictureSender.Client.ViewModels;
using System.Windows.Controls;

namespace PictureSender.Client.Pages
{
    /// <summary>
    /// Логика взаимодействия для DetailPage.xaml
    /// </summary>
    public partial class DetailPage : Page
    {
        public DetailPage(DetailPageViewModel detailViewModel)
        {
            InitializeComponent();
            DataContext = detailViewModel;
        }
    }
}
