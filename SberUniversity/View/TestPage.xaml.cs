using SberUniversity.Model;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using SberUniversity.ViewModel;
using Microsoft.Extensions.Hosting;

namespace SberUniversity
{
    /// <summary>
    /// Логика взаимодействия для TestPage.xaml
    /// </summary>
    public partial class TestPage : Page
    {
        public TestPage(Frame frame, MainPage page)
        {

            InitializeComponent();
            DataContext = new TestViewModel(frame,page,this);
            

        }

    }

}
