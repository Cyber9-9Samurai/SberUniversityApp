using Microsoft.Extensions.Hosting;
using SberUniversity.ViewModel;
using System.Windows.Controls;

namespace SberUniversity
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage(Frame frame)
        {
            InitializeComponent();
            this.DataContext = new MainPageViewModel(frame, this);
        }

    }
}
