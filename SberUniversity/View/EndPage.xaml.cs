using SberUniversity.ViewModel;
using System.Windows.Controls;

namespace SberUniversity
{
    /// <summary>
    /// Логика взаимодействия для EndPage.xaml
    /// </summary>
    public partial class EndPage : Page
    {
        public EndPage(Frame frame, MainPage main)
        {
            InitializeComponent();
            DataContext = new EndPageViewModel(frame, main);
        }


    }
}
